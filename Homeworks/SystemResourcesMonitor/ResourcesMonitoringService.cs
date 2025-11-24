
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SystemResourcesMonitor
{
    public class ResourcesMonitoringService
    {
        private const ushort BYTES_TO_KILOBYTES = 1024;
        private const int BYTES_TO_MEGABYTES = 1024 * 1024;
        public long LastBytesSent { get; private set; } = 0;
        public long LastBytesReceived { get; private set; } = 0;

        public long PrevBytesSent { get; private set; }
        public long PrevBytesReceived { get; private set; }

        private NetworkInterface _networkInterface;

        /// <summary>
        /// Получение доступного сетевого интерфейса
        /// </summary>
        public void InitializeNetworkInterface()
        {
            _networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n =>
                    n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    n.OperationalStatus == OperationalStatus.Up);

            UpdateStatistics();
        }

        /// <summary>
        /// Обновление данных о скачанных и отправленных байтах 
        /// </summary>
        public void UpdateStatistics()
        {
            if (_networkInterface == null)
                return;

            var stats = _networkInterface.GetIPv4Statistics();

            // предыдущие значения
            PrevBytesSent = LastBytesSent;
            PrevBytesReceived = LastBytesReceived;

            // новые значения
            LastBytesSent = stats.BytesSent;
            LastBytesReceived = stats.BytesReceived;
        }

        /// <summary>
        /// Определяет скорость скачивания и отправки
        /// </summary>
        /// <param name="intervalSeconds">Временной интервал</param>
        /// <returns>Скорость скачивания и отправки</returns>
        public (double recvRate, double sentRate) GetNetworkSpeed(double intervalSeconds)
        {
            double recvRate = (LastBytesReceived - PrevBytesReceived) / BYTES_TO_KILOBYTES / intervalSeconds;
            double sentRate = (LastBytesSent - PrevBytesSent) / BYTES_TO_KILOBYTES / intervalSeconds;
            return (recvRate, sentRate);
        }

        /// <summary>
        /// Определяет загруженность RAM
        /// </summary>
        /// <returns>Загруженность RAM</returns>
        public float UpdateRAMInfo()
        {
            ComputerInfo info = new ComputerInfo();
            float totalMemory = info.TotalPhysicalMemory / BYTES_TO_MEGABYTES;
            float availableMemory = info.AvailablePhysicalMemory / BYTES_TO_MEGABYTES;
            return (1 - (availableMemory / totalMemory));
        }
    }

}
