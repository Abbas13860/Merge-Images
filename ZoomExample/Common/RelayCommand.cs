using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZoomExample.Common
{
    public class RelayCommand : ICommand
    {

        public Action<object> MyAction { get; set; }

        public RelayCommand(Action<object> MyAction)
        {
            this.MyAction = MyAction;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MyAction(parameter);
        }
    }
}
