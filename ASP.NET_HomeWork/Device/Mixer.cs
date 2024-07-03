using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_HomeWork.Device
{
    internal class Mixer:IDeviceInfo
    {
        public string GetDeviceInfo()
        {
            return "Миксер: Миксер смешивает.";
        }
    }
}
