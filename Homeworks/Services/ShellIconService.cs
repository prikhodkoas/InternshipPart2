using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShellIconService
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_SMALLICON = 0x1;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x10;

        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        public static Icon GetSmallIcon(string path)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            uint flags = SHGFI_ICON | SHGFI_SMALLICON;
            uint attr = FILE_ATTRIBUTE_NORMAL;

            string normalizedPath = path;

            // Диски должны иметь слэш, иначе Windows считает их логическим устройством
            if (normalizedPath.EndsWith(":"))
                normalizedPath += "\\";

            bool isDir = Directory.Exists(normalizedPath);
            bool isFile = File.Exists(normalizedPath);

            // Если это папка (существует)
            if (isDir)
            {
                attr = FILE_ATTRIBUTE_DIRECTORY;
            }
            // Если путь не существует — определяем по расширению
            else if (!isFile)
            {
                flags |= SHGFI_USEFILEATTRIBUTES;
                attr = GuessDirectory(path) ? FILE_ATTRIBUTE_DIRECTORY : FILE_ATTRIBUTE_NORMAL;
            }

            SHGetFileInfo(normalizedPath, attr, ref shinfo, (uint)Marshal.SizeOf(shinfo), flags);

            if (shinfo.hIcon == IntPtr.Zero)
            {
                // fallback — стандартная иконка папки
                return Icon.ExtractAssociatedIcon(Environment.SystemDirectory);
            }

            Icon icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
            DestroyIcon(shinfo.hIcon);
            return icon;
        }

        private static bool GuessDirectory(string path)
        {
            string ext = Path.GetExtension(path);
            return string.IsNullOrEmpty(ext);
        }
    }
}
