using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShellIconService
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(
        string pszPath,
        uint dwFileAttributes,
        ref SHFILEINFO psfi,
        uint cbFileInfo,
        uint uFlags);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_SMALLICON = 0x1;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x10;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        public static Icon GetSmallIcon(string path, bool isFolder)
        {
            SHFILEINFO shinfo = new SHFILEINFO();

            uint flags = SHGFI_ICON | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES;
            uint attr = isFolder ? FILE_ATTRIBUTE_DIRECTORY : FILE_ATTRIBUTE_NORMAL;

            SHGetFileInfo(path, attr, ref shinfo, (uint)Marshal.SizeOf(shinfo), flags);
            return Icon.FromHandle(shinfo.hIcon);
        }
    }
}
