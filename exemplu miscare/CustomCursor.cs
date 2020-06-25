using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exemplu_miscare
{    public struct IconInfo {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;

    }
    class CustomCursor
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hincon, ref IconInfo piconinfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
        public static System.Windows.Forms.Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot) {
            IntPtr ptr = bmp.GetHicon();
            IconInfo iconInfo = new IconInfo();
            GetIconInfo(ptr, ref iconInfo);
            iconInfo.xHotspot = xHotSpot;
            iconInfo.yHotspot = yHotSpot;
            iconInfo.fIcon = false;
            ptr = CreateIconIndirect(ref iconInfo);
            return new System.Windows.Forms.Cursor(ptr);



        }


    }
}
