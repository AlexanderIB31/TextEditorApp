using System.Windows.Input;

namespace TextEditorApp.ViewModels
{
	public interface IMainViewModel
	{
		ICommand OpenCommand { get; }
		ICommand SaveCommand { get; }
		ICommand UndoCommand { get; }
		ICommand RedoCommand { get; }
		ICommand ExitCommand { get; }
		ICommand NewCommand { get; }
		ICommand CutCommand { get; }
		ICommand CopyCommand { get; }
		ICommand PasteCommand { get; }
		ICommand SelectAllCommand { get; }

		string Text { get; set; }
	}
}