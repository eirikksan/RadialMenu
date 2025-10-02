using System.Windows;

namespace MousePositionWindow.Services
{
    public interface IWindowService
    {
        void ShowWindowAtMousePosition<T>() where T : Window, new();
        Point GetMousePosition();
    }
}