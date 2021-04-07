using System;
using System.Windows;
using Common.Interfaces;
using Unity;
using Wpf.Tools;
using Wpf.Tools.Helpers;

namespace FunctionGraphManager
{
    public partial class App
    {
        private static readonly IUnityContainer Container = ServiceLocator.Container;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DispatcherUnhandledException += (_, args) => this.LogCriticalException(args.Exception);
            AppBootstrapper.RegisterTypes(Container);
            await Container.Resolve<IAppLifecycleService>().LoadGraphsAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            try
            {
                await Container.Resolve<IAppLifecycleService>().SaveGraphsAsync();
            }
            catch (Exception ex)
            {
                this.LogCriticalException(ex);
            }

            base.OnExit(e);
        }
    }
}