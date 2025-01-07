using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_QM_winform.Controller
{
    public class VKeyController
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOACTIVATE = 0x0010;

        private static Process keyboardPs;

        public static void ShowKeyboard(Form parentForm)
        {
            if (keyboardPs == null || keyboardPs.HasExited)
            {
                string filePath = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"),
                        "amd64_microsoft-windows-osk_*")[0],
                        "osk.exe");
                keyboardPs = Process.Start(filePath);

                Task.Delay(500).ContinueWith(_ =>
                {
                    if (keyboardPs.MainWindowHandle != IntPtr.Zero)
                    {
                        int x = parentForm.Location.X;
                        int y = parentForm.Location.Y + parentForm.Height / 2;
                        int width = parentForm.Width;
                        int height = parentForm.Height / 2;

                        SetWindowPos(keyboardPs.MainWindowHandle, 0, x, y, width, height, SWP_NOZORDER | SWP_NOACTIVATE);
                    }
                });
            }
        }
        public static void HideKeyboard()
        {
            if (keyboardPs != null && !keyboardPs.HasExited)
            {
                keyboardPs.Kill();
                keyboardPs = null;
            }
        }

    }
}
