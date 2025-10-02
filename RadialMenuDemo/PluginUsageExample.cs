using System;
using System.Windows;

namespace RadialMenuDemo
{
    /// <summary>
    /// Example of how to use RadialMenuPlugin in a 3rd party application
    /// </summary>
    public class PluginUsageExample
    {
        private RadialMenuPlugin _radialMenuPlugin;

        public void InitializePlugin()
        {
            // Create the plugin instance
            _radialMenuPlugin = new RadialMenuPlugin();

            // Optional: Subscribe to menu item selection events
            _radialMenuPlugin.MenuItemSelected += OnMenuItemSelected;
        }

        /// <summary>
        /// Call this method to show the radial menu at mouse position
        /// For example, when user presses a hotkey or right-clicks
        /// </summary>
        public void ShowRadialMenu()
        {
            _radialMenuPlugin?.ShowAtMouse();
        }

        /// <summary>
        /// Call this method to show the radial menu at specific coordinates
        /// </summary>
        /// <param name="x">Screen X coordinate</param>
        /// <param name="y">Screen Y coordinate</param>
        public void ShowRadialMenuAt(double x, double y)
        {
            _radialMenuPlugin?.ShowAt(x, y);
        }

        /// <summary>
        /// Handle menu item selections
        /// </summary>
        private void OnMenuItemSelected(object sender, string menuItemId)
        {
            switch (menuItemId)
            {
                case "Test1": // Ajouter
                    // Handle add action
                    MessageBox.Show("Add action triggered!");
                    break;
                case "Test2": // Édition
                    // Handle edit action
                    MessageBox.Show("Edit action triggered!");
                    break;
                case "Test3": // Sauvegarder
                    // Handle save action
                    MessageBox.Show("Save action triggered!");
                    break;
                case "Test4": // Supprimer
                    // Handle delete action
                    MessageBox.Show("Delete action triggered!");
                    break;
                case "Test5": // Nouvelle page
                    // Handle new page action
                    MessageBox.Show("New page action triggered!");
                    break;
                case "Test6": // Partager
                    // Handle share action
                    MessageBox.Show("Share action triggered!");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Clean up the plugin when your application shuts down
        /// </summary>
        public void Cleanup()
        {
            _radialMenuPlugin?.Close();
            _radialMenuPlugin = null;
        }
    }
}