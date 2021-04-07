using Unity;

namespace Wpf.Tools.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        protected ViewModelBase(IUnityContainer container)
        {
            Container = container;
        }

        protected IUnityContainer Container { get; }
    }
}