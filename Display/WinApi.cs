using System;
using System.Runtime.InteropServices;

public class WinApi
{
    public const Int32 CCHDEVICENAME = 32;
    public const Int32 CCHFORMNAME = 32;

    public enum DEVMODE_SETTINGS
    {
        ENUM_CURRENT_SETTINGS = (-1),
        ENUM_REGISTRY_SETTINGS = (-2)
    }

    public enum Display_Device_Stateflags
    {
        DISPLAY_DEVICE_ATTACHED_TO_DESKTOP = 0x1,
        DISPLAY_DEVICE_MIRRORING_DRIVER = 0x8,
        DISPLAY_DEVICE_MODESPRUNED = 0x8000000,
        DISPLAY_DEVICE_MULTI_DRIVER = 0x2,
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x4,
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x10
    }

    public enum DeviceFlags
    {
        CDS_FULLSCREEN = 0x4,
        CDS_GLOBAL = 0x8,
        CDS_NORESET = 0x10000000,
        CDS_RESET = 0x40000000,
        CDS_SET_PRIMARY = 0x10,
        CDS_TEST = 0x2,
        CDS_UPDATEREGISTRY = 0x1,
        CDS_VIDEOPARAMETERS = 0x20,
    }

    public enum DEVMODE_Flags
    {
        DM_BITSPERPEL = 0x40000,
        DM_DISPLAYFLAGS = 0x200000,
        DM_DISPLAYFREQUENCY = 0x400000,
        DM_PELSHEIGHT = 0x100000,
        DM_PELSWIDTH = 0x80000,
        DM_POSITION = 0x20
    }

    public enum DisplaySetting_Results
    {
        DISP_CHANGE_BADFLAGS = -4,
        DISP_CHANGE_BADMODE = -2,
        DISP_CHANGE_BADPARAM = -5,
        DISP_CHANGE_FAILED = -1,
        DISP_CHANGE_NOTUPDATED = -3,
        DISP_CHANGE_RESTART = 1,
        DISP_CHANGE_SUCCESSFUL = 0
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINTL
    {
        [MarshalAs(UnmanagedType.I4)]
        public int x;
        [MarshalAs(UnmanagedType.I4)]
        public int y;

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", this.x, this.y);
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmSpecVersion;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmDriverVersion;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmSize;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmDriverExtra;

        [MarshalAs(UnmanagedType.U4)]
        public DEVMODE_Flags dmFields;

        public POINTL dmPosition;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayOrientation;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFixedOutput;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmColor;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmDuplex;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmYResolution;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmTTOption;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmCollate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmLogPixels;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmBitsPerPel;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPelsWidth;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPelsHeight;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFlags;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFrequency;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmICMMethod;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmICMIntent;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmMediaType;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDitherType;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmReserved1;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmReserved2;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPanningWidth;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPanningHeight;

        public override string ToString() 
        {
            return String.Format("DeviceName: {0}\n SpecVersion: {1}\n DriverVersion: {2}\n DmSize: {3}\n DmDriverExtra: {4}\n dmFields: {5}\n dmPosition: {6}\n dmDisplayOrientation: {7}\n dmDisplayFixedOutput: {8}\n " +
            "dmColor: {9}\n dmDuplex: {10}\n dmYResolution: {11}\n dmTTOption: {12}\n dmCollate: {13}\n dmFormName: {14}\n dmLogPixels: {15}\n  dmBitsPerPel: {16}\n  dmPelsWidth: {17}\n  dmPelsHeight: {18}\n  dmDisplayFlags: {19}\n "+
            "  dmDisplayFrequency: {20}\n  dmICMMethod: {21}\n  dmICMIntent: {22}\n" +
            "dmMediaType: {23}\n   dmReserved1: {24}\n   dmReserved2: {25}\n    dmPanningWidth: {26}\n    dmPanningHeight: {27}\n",
                this.dmDeviceName, this.dmSpecVersion, this.dmDriverVersion, this.dmSize, this.dmDriverExtra, this.dmFields, this.dmPosition, this.dmDisplayOrientation, this.dmDisplayFixedOutput, this.dmColor, this.dmDuplex,
                this.dmYResolution, this.dmTTOption, this.dmCollate, this.dmFormName, this.dmLogPixels, this.dmBitsPerPel, this.dmPelsWidth, this.dmPelsHeight, this.dmDisplayFlags,this.dmDisplayFrequency, this.dmICMMethod, this.dmICMIntent,
                this.dmMediaType, this.dmReserved1, this.dmReserved2, this.dmPanningWidth, this.dmPanningHeight);
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DISPLAY_DEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public Display_Device_Stateflags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;

        public override string ToString()
        {
            return String.Format("cb: {0}, DeviceName: {1}, DeviceString: {2}, StateFlags: {3}, DeviceID: {4}, DeviceKey{5}", this.cb, this.DeviceName, this.DeviceString, this.StateFlags, this.DeviceID, this.DeviceKey);
        }
    }

    public class User_32
    {
        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);

        //[DllImport("user32.dll")]
        //public static extern int ChangeDisplaySettingsEx(ref DEVMODE devMode, int flags);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettingsEx(string lpszDeviceName, [In] ref DEVMODE lpDevMode, IntPtr hwnd, int dwFlags, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string lpDevice, int iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);

        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

    }

}
