namespace TextEditorApp.DAL
{
	public interface ITextProvider
	{
		string Load(string path);
		void Save(string path, string text);
	}
}