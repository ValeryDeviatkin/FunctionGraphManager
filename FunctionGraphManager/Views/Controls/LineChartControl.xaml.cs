using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ViewModels.Graph;
using Wpf.Tools.Helpers;

namespace FunctionGraphManager.Views.Controls
{
    public partial class LineChartControl
    {
        public LineChartControl()
        {
            InitializeComponent();

            ((INotifyCollectionChanged) PointList.Items).CollectionChanged += PointListOnCollectionChanged;
        }

        public ObservableCollection<GraphLineViewModel> Lines { get; } = new ObservableCollection<GraphLineViewModel>();

        private void PointListOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                Lines.Clear();

                for (var i = 0; i < PointList.Items.Count - 1; i++)
                {
                    var start = (GraphPointViewModel) PointList.Items[i];
                    var end = (GraphPointViewModel) PointList.Items[i + 1];

                    Lines.Add(new GraphLineViewModel(start, end));
                }
            }
            catch (Exception ex)
            {
                this.LogCriticalException(ex);
            }
        }
    }
}