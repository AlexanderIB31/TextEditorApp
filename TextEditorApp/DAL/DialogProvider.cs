using System.Windows;
using Microsoft.Win32;

namespace TextEditorApp.DAL
{
	public class DialogProvider : IDialogProvider
	{
		public string FilePath { get; set; }

		public bool OpenFileDialog()
		{
			var ofd = new OpenFileDialog();
			if (ofd.ShowDialog() == true)
			{
				FilePath = ofd.FileName;
				return true;
			}
			return false;
		}

		public bool SaveFileDialog()
		{
			var sfd = new SaveFileDialog
			{
				Filter = "txt files (*.txt)|*.txt",
				RestoreDirectory = true
			};

			if (sfd.ShowDialog() == true)
			{
				FilePath = sfd.FileName;
				return true;
			}
			return false;
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

	}
}
