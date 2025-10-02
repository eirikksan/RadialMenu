using System;
using System.Windows;
using MousePositionWindow.Services;

namespace RadialMenuDemo
{
    /// <summary>
    /// Simple plugin interface for integrating RadialMenu into 3rd party applications
    /// </summary>
    public class RadialMenuPlugin
    {
        private RadialMenuWindow _currentWindow;
        private readonly IWindowService _windowService;

        public RadialMenuPlugin()
        {
            _windowService = new WindowService();
        }

        /// <summary>
        /// Show the radial menu at the current mouse position
        /// </summary>
        public void ShowAtMouse()
        {
            var mousePos = _windowService.GetMousePosition();
            ShowAt(mousePos.X, mousePos.Y);
        }

        /// <summary>
        /// Show the radial menu at specific screen coordinates
        /// </summary>
        /// <param name="x">Screen X coordinate</param>
        /// <param name="y">Screen Y coordinate</param>
        public void ShowAt(double x, double y)
        {
            // Close any existing window
            Close();

            // Create and show new window
            _currentWindow = new RadialMenuWindow(_windowService);
            _currentWindow.ShowAtPosition(x, y);
            
            // Auto-close when window loses focus (useful for plugin scenarios)
            _currentWindow.Deactivated += (s, e) => Close();
        }

        /// <summary>
        /// Close the radial menu if it's currently open
        /// </summary>
        public void Close()
        {
            if (_currentWindow != null)
            {
                try
                {
                    _currentWindow.Close();
                }
                catch (InvalidOperationException)
                {
                    // Window may already be closed
                }
                finally
                {
                    _currentWindow = null;
                }
            }
        }

        /// <summary>
        /// Check if the radial menu is currently open
        /// </summary>
        public bool IsOpen => _currentWindow != null && _currentWindow.IsVisible;

        /// <summary>
        /// Event fired when a menu item is selected
        /// You can subscribe to this to handle menu actions in your application
        /// </summary>
        public event EventHandler<string> MenuItemSelected;

        /// <summary>
        /// Configure custom menu actions
        /// </summary>
        /// <param name="menuItemId">The menu item identifier</param>
        /// <param name="action">The action to execute</param>
        public void SetMenuAction(string menuItemId, Action action)
        {
            // This would require extending the ViewModel to support custom actions
            // For now, you can handle actions through the MenuItemSelected event
        }
    }
}