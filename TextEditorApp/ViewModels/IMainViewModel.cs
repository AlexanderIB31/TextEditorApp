using TextEditorApp.Commands;

namespace TextEditorApp.ViewModels
{
	public interface IMainViewModel
	{
		ICommand OpenCommand { get; }
		ICommand SaveCommand { get; }
		string SelectedText { get; set; }
		string Text { get; set; }
	}
}