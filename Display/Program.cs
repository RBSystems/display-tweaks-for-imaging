using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Display
{
    class Program
    {

        static void printValues()
        {
            int curID = 0;
            bool done = false;

            do
            {
                WinApi.DISPLAY_DEVICE ddOne = new WinApi.DISPLAY_DEVICE();
                WinApi.DISPLAY_DEVICE ddTwo = new WinApi.DISPLAY_DEVICE();

                ddOne.cb = Marshal.SizeOf(ddOne);
                ddTwo.cb = Marshal.SizeOf(ddTwo);
                bool t = WinApi.User_32.EnumDisplayDevices(null, curID, ref ddOne, 0);

                if (!t)
                    return;

                t = WinApi.User_32.EnumDisplayDevices(ddOne.DeviceName, 0, ref ddTwo, 0);

                ddOne.DeviceString = ddTwo.DeviceString;

                WinApi.DEVMODE test = new WinApi.DEVMODE();

                WinApi.User_32.EnumDisplaySettings("Test", 4, ref test);

                int succ = WinApi.User_32.EnumDisplaySettings(ddOne.DeviceName, (-1), ref test);

                Console.WriteLine(test);
                Console.WriteLine(ddOne);
                curID++;

            } while (!done);

        }

        static void Main(string[] args)
        {
            List<WinApi.DISPLAY_DEVICE> devices = new List<WinApi.DISPLAY_DEVICE>();
            List<WinApi.DEVMODE> devModes = new List<WinApi.DEVMODE>();

            bool done = false;
            int curID = 0; 

            do
            {
                WinApi.DISPLAY_DEVICE ddOne = new WinApi.DISPLAY_DEVICE();
                WinApi.DISPLAY_DEVICE ddTwo = new WinApi.DISPLAY_DEVICE();

                ddOne.cb = Marshal.SizeOf(ddOne);
                ddTwo.cb = Marshal.SizeOf(ddTwo);
                bool t =  WinApi.User_32.EnumDisplayDevices(null, curID, ref ddOne, 0);
                
                if (!t)
                    break;

                t = WinApi.User_32.EnumDisplayDevices(ddOne.DeviceName, 0, ref ddTwo, 0);
                
                ddOne.DeviceString = ddTwo.DeviceString;

                WinApi.DEVMODE test = new WinApi.DEVMODE();

                WinApi.User_32.EnumDisplaySettings("Test", 4, ref test);

                int succ = WinApi.User_32.EnumDisplaySettings(ddOne.DeviceName, (-1), ref test);

                devModes.Add(test);
                devices.Add(ddOne);
                curID++;

            } while (!done);
            
            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine(devices.ElementAt(i));
                Console.WriteLine(devModes.ElementAt(i));
            }

            foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens)
            {
                Console.WriteLine(screen.DeviceName);

            }

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Changing: " + devices.ElementAt(1));
            Console.WriteLine(devModes.ElementAt(1));
            Console.WriteLine("---------------------------------------------------------------------------");

            Console.ReadKey();

            WinApi.DEVMODE d = devModes.ElementAt(1);
            

            //d.dmFields = WinApi.DEVMODE_Flags.DM_PELSWIDTH | WinApi.DEVMODE_Flags.DM_PELSHEIGHT;
            d.dmPelsHeight = 0;
            d.dmPelsWidth = 0;

            //d.dmFields |= WinApi.DEVMODE_Flags.DM_POSITION;
            d.dmPosition.x = 0;
            
            Console.WriteLine("Changing the location to: " + d.dmPosition);

            WinApi.DisplaySetting_Results success = (WinApi.DisplaySetting_Results)WinApi.User_32.ChangeDisplaySettingsEx(devices.ElementAt(1).DeviceName, ref d, 
                (IntPtr)null, ((int)WinApi.DeviceFlags.CDS_UPDATEREGISTRY | (int)WinApi.DeviceFlags.CDS_NORESET), (IntPtr)null);

            Console.WriteLine("Success: " + success);

            printValues();
            Console.ReadKey();
        }
    }
}
