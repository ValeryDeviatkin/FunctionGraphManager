using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;
using ViewModels.Graph;
using ViewModels.Helpers;
using ViewModels.Interfaces;
using Wpf.Tools.Base;

namespace ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }

        public ObservableCollection<GraphViewModel> Graphs { get; } = new ObservableCollection<GraphViewModel>();

        #region SelectedGraph: GraphViewModel

        public GraphViewModel SelectedGraph
        {
            get => _propertyName;
            set => SetProperty(ref _propertyName, value, null, OnSelectedGraphChanging);
        }

        private void OnSelectedGraphChanging()
        {
            if (SelectedGraph != null)
            {
                SelectedGraph.SelectedPoint = null;
            }
        }

        private GraphViewModel _propertyName;

        #endregion

        #region CreateGraph command

        public ICommand CreateGraphCommand => _createGraphCommand ??= new Command(ExecuteCreateGraphAsync);

        private Command _createGraphCommand;

        private async Task ExecuteCreateGraphAsync(object parameter)
        {
            var graph = GraphViewModelCreator.Create();
            await Container.Resolve<IDatabaseService>().SaveAsync(graph);
            Graphs.Add(graph);
            SelectedGraph = graph;
        }

        #endregion

        #region DeleteGraph command

        public ICommand DeleteGraphCommand => _deleteGraphCommand ??= new Command(ExecuteDeleteGraphAsync);

        private Command _deleteGraphCommand;

        private async Task ExecuteDeleteGraphAsync(object parameter)
        {
            if (SelectedGraph == null)
            {
                throw new NotSupportedException();
            }

            var id = SelectedGraph.Id;
            Graphs.Remove(SelectedGraph);
            await Container.Resolve<IDatabaseService>().DeleteAsync(id);
        }

        #endregion

        #region SaveToFile command

        public ICommand SaveToFileCommand => _saveToFileCommand ??= new Command(ExecuteSaveToFileAsync);

        private Command _saveToFileCommand;

        private async Task ExecuteSaveToFileAsync(object parameter)
        {
            if (SelectedGraph == null)
            {
                throw new NotSupportedException();
            }

            var dialog = MessageBoxHelper.CreateCsvSaveDialog();

            if (dialog.ShowDialog() == true)
            {
                Container.Resolve<IGraphTableTransferService>().Save(dialog.FileName, SelectedGraph);
            }
        }

        #endregion

        #region LoadFromFile command

        public ICommand LoadFromFileCommand => _loadFromFileCommand ??= new Command(ExecuteLoadFromFileAsync);

        private Command _loadFromFileCommand;

        private async Task ExecuteLoadFromFileAsync(object parameter)
        {
            if (SelectedGraph == null)
            {
                throw new NotSupportedException();
            }

            var dialog = MessageBoxHelper.CreateCsvOpenDialog();

            if (dialog.ShowDialog() == true)
            {
                Container.Resolve<IGraphTableTransferService>().Load(dialog.FileName, SelectedGraph);
            }
        }

        #endregion

        #region SaveToClipboard command

        public ICommand SaveToClipboardCommand => _saveToClipboardCommand ??= new Command(ExecuteSaveToClipboardAsync);

        private Command _saveToClipboardCommand;

        private async Task ExecuteSaveToClipboardAsync(object parameter)
        {
            if (SelectedGraph == null)
            {
                throw new NotSupportedException();
            }

            Container.Resolve<IGraphTableTransferService>().SaveToClipboard(SelectedGraph);
        }

        #endregion

        #region LoadFromClipboard command

        public ICommand LoadFromClipboardCommand =>
            _loadFromClipboardCommand ??= new Command(ExecuteLoadFromClipboardAsync);

        private Command _loadFromClipboardCommand;

        private async Task ExecuteLoadFromClipboardAsync(object parameter)
        {
            if (SelectedGraph == null)
            {
                throw new NotSupportedException();
            }

            var isTableLoaded = Container.Resolve<IGraphTableTransferService>().TryLoadFromClipboard(SelectedGraph);

            if (!isTableLoaded)
            {
                MessageBox.Show("Nothing loaded.", "", MessageBoxButton.OK);
            }
        }

        #endregion
    }
}