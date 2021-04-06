using Common.Interfaces;
using Unity;
using ViewModels.Main;

namespace ViewModels
{
    public class ViewModelsModuleInitializer : IModuleInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container
               .RegisterType<MainViewModel>()
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