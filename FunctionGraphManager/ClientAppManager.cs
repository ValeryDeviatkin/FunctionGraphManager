using System.Windows;
using Unity;
using ViewModels.Main;
using Wpf.Tools;

namespace FunctionGraphManager
{
    internal static class ClientAppManager
    {
        private static readonly IUnityContainer Container = ServiceLocator.Container;

        public static void SetMainViewModel()
        {
            Application.Current.MainWindow.DataContext = Container.Resolve<MainViewModel>();
        }
    }
}