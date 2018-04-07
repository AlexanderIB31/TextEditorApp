using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorApp.Annotations;

namespace TextEditorApp.DAL
{
	public interface IDialogProvider
	{
		string FilePath { get; set; }
		void ShowMessage(string message);
		bool OpenFileDialog();
		bool SaveFileDialog();
	}
}
