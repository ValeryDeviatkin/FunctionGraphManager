using ViewModels.Graph;

namespace FunctionGraphManager.Views.Controls
{
    public class GraphLineViewModel
    {
        public GraphLineViewModel(GraphPointViewModel start, GraphPointViewModel end)
        {
            Start = start;
            End = end;
        }

        public GraphPointViewModel Start { get; }
        public GraphPointViewModel End { get; }
    }
}