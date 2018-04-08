using System.Windows.Input;
using TextEditorApp.Commands;

namespace TextEditorApp.ViewModels
{
	public interface IMainViewModel
	{
		ICommand OpenCommand { get; }
		ICommand SaveCommand { get; }
		ICommand UndoCommand { get; }
		ICommand RedoCommand { get; }
		ICommand ExitCommand { get; }
		ICommand CreateNewCommand { get; }
		ICommand CutCommand { get; }
		ICommand CopyCommand { get; }
		ICommand PasteCommand { get; }
		ICommand SelectAllCommand { get; }

		string SelectedText { get; set; }
		string Text { get; set; }
	}
}