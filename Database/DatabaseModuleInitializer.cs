using Common.Interfaces;
using Database.Services;
using Unity;
using ViewModels.Interfaces;

namespace Database
{
    public class DatabaseModuleInitializer : IModuleInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container
               .RegisterType<IDatabaseService, DatabaseService>()
               .RegisterType<StateHub>()
               .RegisterType<IStateHub, StateHub>()
                ;
        }

        #region singleton

        private DatabaseModuleInitializer()
        {
        }

        private static DatabaseModuleInitializer _instance;

        public static DatabaseModuleInitializer Instance => _instance ??= new DatabaseModuleInitializer();

        #endregion
    }
}