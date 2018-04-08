namespace TextEditorApp.BLL
{
	public interface IDialogService
	{
		string FilePath { get; set; }
		void ShowMessage(string message);
		bool OpenFileDialog();
		bool SaveFileDialog();
	}
}
