using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RadialMenuDemo.Utils;
using MousePositionWindow.Services;

namespace MousePositionWindow.ViewModels
{
    public class PopUpWindowViewModel : INotifyPropertyChanged
    {
        private readonly IWindowService _windowService;

        public ICommand OpenNewWindowCommand { get; }

        public PopUpWindowViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            OpenNewWindowCommand = new RelayCommand(OpenNewWindow);
        }

        private void OpenNewWindow()
        {
            _windowService.ShowWindowAtMousePosition<NewWindow>();
        }

        // RadialMenu properties and commands from MainWindow
        private bool _isOpen1 = false;
        public bool IsOpen1
        {
            get
            {
                return _isOpen1;
            }
            set
            {
                _isOpen1 = value;
                RaisePropertyChanged();
            }
        }

        private bool _isOpen2 = false;
        public bool IsOpen2
        {
            get
            {
                return _isOpen2;
            }
            set
            {
                _isOpen2 = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CloseRadialMenu1
        {
            get
            {
                return new RelayCommand(() => IsOpen1 = false);
            }
        }
        
        public ICommand OpenRadialMenu1
        {
            get
            {
                return new RelayCommand(() => { IsOpen1 = true; IsOpen2 = false; });
            }
        }

        public ICommand CloseRadialMenu2
        {
            get
            {
                return new RelayCommand(() => IsOpen2 = false);
            }
        }
        
        public ICommand OpenRadialMenu2
        {
            get
            {
                return new RelayCommand(() => { IsOpen2 = true; IsOpen1 = false; });
            }
        }

        public ICommand Test1
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("1"));
            }
        }

        public ICommand Test2
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("2"));
            }
        }

        public ICommand Test3
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("3"));
            }
        }

        public ICommand Test4
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("4"));
            }
        }

        public ICommand Test5
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("5"));
            }
        }

        public ICommand Test6
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        System.Diagnostics.Debug.WriteLine("6");
                    },
                    () =>
                    {
                        return false; // To disable the 6th item
                    }
                );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}