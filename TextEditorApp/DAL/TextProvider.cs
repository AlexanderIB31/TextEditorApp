using System;
using System.IO;

namespace TextEditorApp.DAL
{
	public class TextProvider : ITextProvider
	{
		public string Load(string path)
		{
			if (!File.Exists(path)) throw new IOException($"File {path} is not exist.");
			using (var sr = new StreamReader(path))
			{
				return sr.ReadToEnd();
			}
		}

		public void Save(string path, string text)
		{
			using (var sw = new StreamWriter(path))
			{
				sw.Write(text);
			}
		}
	}
}