using Unity;
using ViewModels.Main;
using Wpf.Tools;

namespace FunctionGraphManager.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ServiceLocator.Container.Resolve<MainViewModel>();
        }
    }
}