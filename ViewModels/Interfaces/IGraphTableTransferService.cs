using ViewModels.Graph;

namespace ViewModels.Interfaces
{
    public interface IGraphTableTransferService
    {
        void Save(string path, GraphViewModel item);
        void Load(string path, GraphViewModel item);
        void SaveToClipboard(GraphViewModel item);
        bool TryLoadFromClipboard(GraphViewModel item);
    }
}