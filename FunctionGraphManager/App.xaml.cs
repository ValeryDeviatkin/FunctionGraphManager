using System.Windows;
using Wpf.Tools;

namespace FunctionGraphManager
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppBootstrapper.RegisterTypes(ServiceLocator.Container);
            ClientAppManager.SetMainViewModel();
        }
    }
}