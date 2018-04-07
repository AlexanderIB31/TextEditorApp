using System;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using TextEditorApp.Annotations;
using TextEditorApp.Commands;
using TextEditorApp.DAL;

namespace TextEditorApp.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged, IMainViewModel
	{
		private readonly ITextProvider _textProvider;
		private readonly IDialogProvider _dialogProvider;
		private string _text = string.Empty;
		private string _selectedText;
		private RelayCommand _openCommand;
		private RelayCommand _saveCommand;
		[NotifyPropertyChangedInvocator]
		private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public string Text
		{
			get => _text;
			set
			{
				_text = value;
				RaisePropertyChanged(nameof(Text));
			}
		}
		public string SelectedText
		{
			get => _selectedText;
			set
			{
				_selectedText = value;
				RaisePropertyChanged(nameof(SelectedText));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public RelayCommand OpenCommand
		{
			get
			{
				return _openCommand ??
					   (_openCommand = new RelayCommand(obj =>
					   {
						   try
						   {
							   if (_dialogProvider.OpenFileDialog() == true)
							   {
								   _text = _textProvider.Load(_dialogProvider.FilePath);
								   _dialogProvider.ShowMessage("Файл открыт");
							   }
						   }
						   catch (Exception ex)
						   {
							   _dialogProvider.ShowMessage(ex.Message);
						   }
					   }, obj => true));
			}
		}
		public RelayCommand SaveCommand
		{
			get
			{
				return _saveCommand ??
					   (_saveCommand = new RelayCommand(obj =>
					   {
						   var sfd = new SaveFileDialog
						   {
							   Filter = "txt files (*.txt)|*.txt",
							   RestoreDirectory = true
						   };

						   if (sfd.ShowDialog() == true)
						   {
							   _textProvider.Save(sfd.FileName, _text);
						   }
					   }, obj => true));
			}
		}

		public MainViewModel(ITextProvider textProvider, IDialogProvider dialogProvider)
		{
			_textProvider = textProvider;
			_dialogProvider = dialogProvider;
		}

	}
}