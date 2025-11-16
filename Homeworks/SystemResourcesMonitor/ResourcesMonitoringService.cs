
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
        public long LastBytesSent { get; private set; } = 0;
        public long LastBytesReceived { get; private set; } = 0;

        public long PrevBytesSent { get; private set; }
        public long PrevBytesReceived { get; private set; }

        private NetworkInterface _networkInterface;

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
            double recvRate = (LastBytesReceived - PrevBytesReceived) / 1024.0 / intervalSeconds;
            double sentRate = (LastBytesSent - PrevBytesSent) / 1024.0 / intervalSeconds;
            return (recvRate, sentRate);
        }

        /// <summary>
        /// Определяет загруженность RAM
        /// </summary>
        /// <returns>Загруженность RAM</returns>
        public float UpdateRAMInfo()
        {
            ComputerInfo info = new ComputerInfo();
            float totalMemory = info.TotalPhysicalMemory / (1024 * 1024);
            float availableMemory = info.AvailablePhysicalMemory / (1024 * 1024);
            return (1 - (availableMemory / totalMemory)) * 100f;
        }
    }

}
