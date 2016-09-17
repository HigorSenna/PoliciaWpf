using System;
using System.Windows.Input;

namespace Cronometrage.WPF.Property
{
    public class Command : ICommand
    {
        #pragma warning disable
        public event EventHandler CanExecuteChanged;
        #pragma warning enable

        private Action<object> execute;

        public Command(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (execute != null)
                execute(parameter);
        }
    }
}
