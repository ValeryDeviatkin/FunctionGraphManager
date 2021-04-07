using ViewModels.Graph;

namespace ViewModels.Interfaces
{
    public interface IStateHub
    {
        public bool HasChanged(GraphViewModel graph);
    }
}