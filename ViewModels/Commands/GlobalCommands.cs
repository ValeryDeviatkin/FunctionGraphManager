using System.Threading.Tasks;
using System.Windows.Input;
using Common.Interfaces;
using Unity;
using Wpf.Tools;
using Wpf.Tools.Base;

namespace ViewModels.Commands
{
    public class GlobalCommands
    {
        private static readonly IUnityContainer Container = ServiceLocator.Container;

        #region singleton

        private GlobalCommands()
        {
        }

        private static GlobalCommands _instance;

        public static GlobalCommands Instance => _instance ??= new GlobalCommands();

        #endregion

        #region ExitApp command

        public ICommand ExitAppCommand => _exitAppCommand ??= new Command(ExecuteExitAppAsync);

        private Command _exitAppCommand;

        private static async Task ExecuteExitAppAsync(object parameter) =>
            Container.Resolve<IClientAppManager>().ExitApp();

        #endregion
    }
}