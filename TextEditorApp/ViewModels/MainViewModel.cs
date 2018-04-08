using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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
		private ICommand _openCommand;
		private ICommand _saveCommand;

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
		public ICommand OpenCommand
		{
			get
			{
				return _openCommand ??
					   (_openCommand = new RelayCommand(obj =>
					   {
						   try
						   {
							   if (_dialogProvider.OpenFileDialog())
							   {
								   _text = _textProvider.Load(_dialogProvider.FilePath);
								   _dialogProvider.ShowMessage("Файл открыт");
							   }
						   }
						   catch (Exception ex)
						   {
							   _dialogProvider.ShowMessage(ex.Message);
						   }
					   }));
			}
		}
		public ICommand SaveCommand
		{
			get
			{
				return _saveCommand ??
					   (_saveCommand = new RelayCommand(obj =>
					   {
						   if (_dialogProvider.SaveFileDialog())
						   {
							   _textProvider.Save(_dialogProvider.FilePath, _text);
						   }
					   }));
			}
		}

		public MainViewModel(ITextProvider textProvider, IDialogProvider dialogProvider)
		{
			_textProvider = textProvider;
			_dialogProvider = dialogProvider;
		}

	}
}