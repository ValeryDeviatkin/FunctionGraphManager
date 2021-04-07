using System.Threading.Tasks;
using System.Windows;
using Common.Interfaces;
using Unity;
using ViewModels.Interfaces;
using ViewModels.Main;

namespace ViewModels.Services
{
    internal class AppLifecycleService : IAppLifecycleService
    {
        private readonly IUnityContainer _container;

        public AppLifecycleService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public async Task SaveGraphsAsync()
        {
            var mainViewModel = _container.Resolve<MainViewModel>();
            var database = _container.Resolve<IDatabaseService>();

            foreach (var graph in mainViewModel.Graphs)
            {
                if (_container.Resolve<IStateHub>().HasChanged(graph))
                {
                    var result = MessageBox.Show("Save graph?", graph.Name, MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        await database.SaveAsync(graph);
                    }
                }
            }
        }

        public async Task LoadGraphsAsync()
        {
            var vm = _container.Resolve<MainViewModel>();
            var graphs = await _container.Resolve<IDatabaseService>().GetAllAsync();

            foreach (var graph in graphs)
            {
                vm.Graphs.Add(graph);
            }
        }
    }
}