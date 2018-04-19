using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CurrencyMidterm.ViewModels
{
    public class BaseCommand : ICommand
    {
        private Action commandAction;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public BaseCommand(Action action)
        {
            commandAction = action;
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {
            commandAction();
        }
    }
}
