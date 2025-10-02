using System.Windows;
using System.Windows.Input;
using MousePositionWindow.ViewModels;
using MousePositionWindow.Services;

namespace MousePositionWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        private readonly IWindowService _windowService;
        private PopUpWindowViewModel _viewModel;

        public NewWindow() : this(new WindowService())
        {
        }

        public NewWindow(IWindowService windowService)
        {
            _windowService = windowService;

            this.WindowStartupLocation = WindowStartupLocation.Manual;

            // Explicitly set the same values as in XAML
            this.Width = 650;
            this.Height = 430;

            // Set the DataContext to the ViewModel with dependency injection
            _viewModel = new PopUpWindowViewModel(_windowService);
            this.DataContext = _viewModel;

            SetWindowPositionCentre();

            InitializeComponent();
        }

        private void SetWindowPositionCentre()
        {
            // Use the service to get mouse position for consistency
            Point mouseScreenPosition = _windowService.GetMousePosition();
            
            // Calculate the centered position
            // Use Width and Height if set in XAML, otherwise use default values
            double windowWidth = this.Width > 0 ? this.Width : 650;  // fallback width
            double windowHeight = this.Height > 0 ? this.Height : 430; // fallback height

            this.Left = mouseScreenPosition.X - windowWidth / 2;
            this.Top = mouseScreenPosition.Y - windowHeight / 2;
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _viewModel.OpenRadialMenu1.Execute(null);
        }
    }
}