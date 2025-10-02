using System.Windows;

namespace MousePositionWindow.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindowAtMousePosition<T>() where T : Window, new()
        {
            // Get the current mouse position relative to the screen
            Point mouseScreenPosition = GetMousePosition();

            // Create an instance of the window
            var newWindow = new T();

            // Set the WindowStartupLocation to Manual
            newWindow.WindowStartupLocation = WindowStartupLocation.Manual;

            var newWindowWidth = newWindow.Width;
            var newWindowHeight = newWindow.Height;

            // Set the Left and Top properties of the new window
            newWindow.Left = mouseScreenPosition.X - newWindowWidth / 2;
            newWindow.Top = mouseScreenPosition.Y - newWindowHeight / 2;

            // Open the new window
            newWindow.Show();
        }

        public Point GetMousePosition()
        {
            // Get the cursor position using Win32 API
            NativeMethods.POINT lpPoint;
            NativeMethods.GetCursorPos(out lpPoint);

            // Convert to WPF's device-independent pixels
            return new Point(lpPoint.X, lpPoint.Y);
        }

        // NativeMethods class to interact with Win32 API
        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool GetCursorPos(out POINT lpPoint);

            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
            internal struct POINT
            {
                public int X;
                public int Y;
            }
        }
    }
}