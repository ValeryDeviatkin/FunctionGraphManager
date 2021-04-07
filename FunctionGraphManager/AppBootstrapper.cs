using Common.Interfaces;
using Database;
using DataTransfer;
using Unity;
using ViewModels;

namespace FunctionGraphManager
{
    internal static class AppBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            DatabaseModuleInitializer.Instance.Initialize(container);
            DataTransferModuleInitializer.Instance.Initialize(container);
            ViewModelsModuleInitializer.Instance.Initialize(container);

            container
               .RegisterType<IClientAppManager, ClientAppManager>()
                ;
        }
    }
}