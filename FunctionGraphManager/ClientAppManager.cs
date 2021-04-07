using System.Windows;
using Common.Interfaces;
using Unity;

namespace FunctionGraphManager
{
    internal class ClientAppManager : IClientAppManager
    {
        public ClientAppManager(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public void ExitApp()
        {
            Application.Current.Shutdown();
        }
    }
}