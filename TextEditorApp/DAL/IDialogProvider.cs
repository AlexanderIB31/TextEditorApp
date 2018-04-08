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
