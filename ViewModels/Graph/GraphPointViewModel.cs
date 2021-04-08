using Common;
using Common.Helpers;
using Wpf.Tools.Base;

namespace ViewModels.Graph
{
    public class GraphPointViewModel : ObservableObject
    {
        #region X: double

        public double X
        {
            get => _x;
            set => SetProperty(ref _x, RangeValueHelper.GetInRange(value, GlobalConstants.MinX, GlobalConstants.MaxX));
        }

        private double _x;

        #endregion

        #region Y: double

        public double Y
        {
            get => _y;
            set => SetProperty(ref _y, RangeValueHelper.GetInRange(value, GlobalConstants.MinY, GlobalConstants.MaxY));
        }

        private double _y;

        #endregion
    }
}