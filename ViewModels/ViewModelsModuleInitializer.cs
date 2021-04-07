using Common.Interfaces;
using Unity;
using ViewModels.Main;
using ViewModels.Services;

namespace ViewModels
{
    public class ViewModelsModuleInitializer : IModuleInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container

                // ViewModels
               .RegisterType<MainViewModel>()

                // Services
               .RegisterType<IAppLifecycleService, AppLifecycleService>()
                ;
        }

        #region singleton

        private ViewModelsModuleInitializer()
        {
        }

        private static ViewModelsModuleInitializer _instance;

        public static ViewModelsModuleInitializer Instance => _instance ??= new ViewModelsModuleInitializer();

        #endregion
    }
}