using TextEditorApp.Commands;

namespace TextEditorApp.ViewModels
{
	public interface IMainViewModel
	{
		RelayCommand OpenCommand { get; }
		RelayCommand SaveCommand { get; }
		string SelectedText { get; set; }
		string Text { get; set; }
	}
}