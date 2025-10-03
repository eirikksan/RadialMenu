using System.Windows;
using System.Windows.Forms; // Add this for Screen class

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

        /// <summary>
        /// Get the working area bounds of the screen containing the specified point
        /// </summary>
        /// <param name="point">Point in screen coordinates</param>
        /// <returns>Working area bounds of the screen containing the point</returns>
        public Rect GetScreenWorkingArea(Point point)
        {
            // Convert WPF point to System.Drawing.Point for Screen class
            var drawingPoint = new System.Drawing.Point((int)point.X, (int)point.Y);

            // Get the screen that contains the point
            var screen = Screen.FromPoint(drawingPoint);

            // Return the working area as a WPF Rect
            return new Rect(
                screen.WorkingArea.Left,
                screen.WorkingArea.Top,
                screen.WorkingArea.Width,
                screen.WorkingArea.Height);
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