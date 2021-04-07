using Wpf.Tools.Base;

namespace ViewModels.Graph
{
    public class GraphPointViewModel : ObservableObject
    {
        #region X: double

        public double X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        private double _x;

        #endregion

        #region Y: double

        public double Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }

        private double _y;

        #endregion
    }
}