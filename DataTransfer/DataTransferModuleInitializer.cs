using Common.Interfaces;
using DataTransfer.Services;
using Unity;
using ViewModels.Interfaces;

namespace DataTransfer
{
    public class DataTransferModuleInitializer : IModuleInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container
               .RegisterType<IGraphTableTransferService, GraphTableTransferService>()
                ;
        }

        #region singleton

        private DataTransferModuleInitializer()
        {
        }

        private static DataTransferModuleInitializer _instance;

        public static DataTransferModuleInitializer Instance => _instance ??= new DataTransferModuleInitializer();

        #endregion
    }
}