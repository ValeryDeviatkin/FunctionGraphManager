using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Tools.Helpers;

namespace Wpf.Tools.Base
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isDisabled;

        public bool CanExecute(object parameter = null) => !_isDisabled;

        public async void Execute(object parameter)
        {
            Disable();

            try
            {
                await ExecuteExternal(parameter);
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }

            Enable();
        }

        public event EventHandler CanExecuteChanged;

        protected abstract Task ExecuteExternal(object parameter);

        private void ChangeCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        private void Disable()
        {
            _isDisabled = true;

            ChangeCanExecute();
        }

        private void Enable()
        {
            _isDisabled = false;

            ChangeCanExecute();
        }
    }

    public class Command : AsyncCommandBase
    {
        private readonly Func<object, Task> _execute;

        public Command(Func<object, Task> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        protected override Task ExecuteExternal(object parameter) => _execute(parameter);
    }
}