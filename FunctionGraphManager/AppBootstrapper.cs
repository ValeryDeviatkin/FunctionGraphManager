using Unity;
using ViewModels;

namespace FunctionGraphManager
{
    internal static class AppBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            ViewModelsModuleInitializer.Instance.Initialize(container);
        }
    }
}