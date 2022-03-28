using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace EcoPOSv2
{
    public class RawPrinterHelper
    {
        public void OpenCashDrawer()
        {
            Encoding enc = Encoding.Unicode;
            SerialPort sp = new SerialPort();
            sp.PortName = "USB003";

            sp.Encoding = enc;
            sp.BaudRate = 38400;
            sp.Parity = System.IO.Ports.Parity.None;
            sp.DataBits = 8;
            sp.StopBits = System.IO.Ports.StopBits.One;
            sp.DtrEnable = true;
            sp.Open();
            sp.Write(char.ConvertFromUtf32(28699) + char.ConvertFromUtf32(9472) + char.ConvertFromUtf32(3365));
            sp.Close();
        }
    }
}
