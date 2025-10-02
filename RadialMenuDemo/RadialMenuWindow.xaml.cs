using System.Windows;
using System.Windows.Input;
using MousePositionWindow.ViewModels;
using MousePositionWindow.Services;

namespace RadialMenuDemo
{
    /// <summary>
    /// Interaction logic for RadialMenuWindow.xaml
    /// </summary>
    public partial class RadialMenuWindow : Window
    {
        private readonly IWindowService _windowService;
        private RadialMenuWindowViewModel _viewModel;

        public RadialMenuWindow() : this(new WindowService())
        {
        }

        public RadialMenuWindow(IWindowService windowService)
        {
            _windowService = windowService;

            this.WindowStartupLocation = WindowStartupLocation.Manual;

            // Use smaller dimensions for plugin mode
            this.Width = 400;
            this.Height = 400;

            // Set the DataContext to the correct ViewModel with dependency injection
            _viewModel = new RadialMenuWindowViewModel(_windowService);
            this.DataContext = _viewModel;

            SetWindowPositionAtMouse();

            InitializeComponent();

            // Auto-open the radial menu when window is shown (for plugin mode)
            this.Loaded += (s, e) => 
            {
                _viewModel.OpenRadialMenu1.Execute(null);
            };

            // Close window when radial menu is closed (for plugin mode)
            _viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_viewModel.IsOpen1) && !_viewModel.IsOpen1)
                {
                    this.Close();
                }
            };
        }

        private void SetWindowPositionAtMouse()
        {
            // Position window at mouse cursor for plugin usage
            Point mouseScreenPosition = _windowService.GetMousePosition();
            
            // Calculate the centered position around mouse cursor
            double windowWidth = this.Width > 0 ? this.Width : 400;
            double windowHeight = this.Height > 0 ? this.Height : 400;

            this.Left = mouseScreenPosition.X - windowWidth / 2;
            this.Top = mouseScreenPosition.Y - windowHeight / 2;

            // Ensure window stays within screen bounds
            var workingArea = SystemParameters.WorkArea;
            
            if (this.Left < workingArea.Left)
                this.Left = workingArea.Left;
            if (this.Top < workingArea.Top)
                this.Top = workingArea.Top;
            if (this.Left + windowWidth > workingArea.Right)
                this.Left = workingArea.Right - windowWidth;
            if (this.Top + windowHeight > workingArea.Bottom)
                this.Top = workingArea.Bottom - windowHeight;
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Optional: Allow right-click to open menu if it's closed
            if (!_viewModel.IsOpen1)
            {
                _viewModel.OpenRadialMenu1.Execute(null);
            }
        }

        /// <summary>
        /// Public method to show radial menu at specific coordinates (for plugin integration)
        /// </summary>
        /// <param name="x">Screen X coordinate</param>
        /// <param name="y">Screen Y coordinate</param>
        public void ShowAtPosition(double x, double y)
        {
            this.Left = x - this.Width / 2;
            this.Top = y - this.Height / 2;
            
            // Ensure window stays within screen bounds
            var workingArea = SystemParameters.WorkArea;
            
            if (this.Left < workingArea.Left)
                this.Left = workingArea.Left;
            if (this.Top < workingArea.Top)
                this.Top = workingArea.Top;
            if (this.Left + this.Width > workingArea.Right)
                this.Left = workingArea.Right - this.Width;
            if (this.Top + this.Height > workingArea.Bottom)
                this.Top = workingArea.Bottom - this.Height;

            this.Show();
            _viewModel.OpenRadialMenu1.Execute(null);
        }
    }
}