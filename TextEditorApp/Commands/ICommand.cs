using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorApp.Commands
{
	public interface ICommand
	{
		event EventHandler CanExecuteChanged;
		void Execute(object parameter);
		bool CanExecute(object parameter);
	}
}
