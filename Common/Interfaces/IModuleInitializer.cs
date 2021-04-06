using Unity;

namespace Common.Interfaces
{
    public interface IModuleInitializer
    {
        void Initialize(IUnityContainer container);
    }
}