using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_HomeWork.Device
{
    internal class DeviceInfoManager
    {
        private readonly IDeviceInfo[] _devices;

        public DeviceInfoManager(IDeviceInfo[] devices)
        {
            _devices = devices;
        }

        public void PrintDeviceInfo()
        {
            foreach (var device in _devices)
            {
                Console.WriteLine(device.GetDeviceInfo());
            }
        }

        public void WriteDeviceInfoToFile()
        {
            string filePath = "device_info.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var device in _devices)
                {
                    sw.WriteLine(device.GetDeviceInfo());
                }
            }

            Console.WriteLine($"Информация сохранена в {filePath}.");
        }
    }
}
