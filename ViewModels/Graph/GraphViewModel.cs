using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;
using Wpf.Tools.Base;

namespace ViewModels.Graph
{
    public class GraphViewModel : ViewModelBase
    {
        public GraphViewModel(IUnityContainer container, Guid id) : base(container)
        {
            Id = id;
        }

        public Guid Id { get; }

        public ObservableCollection<GraphPointViewModel> Points { get; } =
            new ObservableCollection<GraphPointViewModel>();

        #region SelectedPoint: GraphPointViewModel

        public GraphPointViewModel SelectedPoint
        {
            get => _selectedPoint;
            set => SetProperty(ref _selectedPoint, value);
        }

        private GraphPointViewModel _selectedPoint;

        #endregion

        #region Name: string

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _name;

        #endregion

        #region AddPoint command

        public ICommand AddPointCommand => _addPointCommand ??= new Command(ExecuteAddPointAsync);

        private Command _addPointCommand;

        private async Task ExecuteAddPointAsync(object parameter)
        {
            var point = new GraphPointViewModel();
            Points.Add(point);
            SelectedPoint = point;
        }

        #endregion

        #region DeletePoint command

        public ICommand DeletePointCommand => _deletePointCommand ??= new Command(ExecuteDeletePointAsync);

        private Command _deletePointCommand;

        private async Task ExecuteDeletePointAsync(object parameter)
        {
            if (SelectedPoint == null)
            {
                throw new NotSupportedException();
            }

            Points.Remove(SelectedPoint);
        }

        #endregion
    }
}