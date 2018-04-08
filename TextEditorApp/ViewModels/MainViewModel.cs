using System;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TextEditorApp.Annotations;
using TextEditorApp.BLL;
using TextEditorApp.Commands;
using TextEditorApp.DAL;

namespace TextEditorApp.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged, IMainViewModel
	{
		private readonly ITextProvider _textProvider;
		private readonly IDialogService _dialogService;
		private ICommand _newCommand;
		private ICommand _openCommand;
		private ICommand _saveCommand;
		private ICommand _exitCommand;
		private string _text = string.Empty;

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
							   if (_dialogService.OpenFileDialog())
							   {
								   _text = _textProvider.Load(_dialogService.FilePath);
								   _dialogService.ShowMessage("Файл открыт");
							   }
						   }
						   catch (Exception ex)
						   {
							   _dialogService.ShowMessage(ex.Message);
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
						   if (_dialogService.SaveFileDialog())
						   {
							   _textProvider.Save(_dialogService.FilePath, _text);
						   }
					   }));
			}
		}
		public ICommand ExitCommand
		{
			get
			{
				return _exitCommand ??
					   (_exitCommand = new RelayCommand(obj =>
					   {
						   var messageBoxResult = MessageBox.Show(Properties.Resources.ResourceManager.GetString("ExitMessage"),
							   Properties.Resources.ResourceManager.GetString("Title"),
							   MessageBoxButton.YesNoCancel);
						   if (messageBoxResult == MessageBoxResult.Yes)
						   {
							   SaveCommand.Execute(obj);
						   }
						   if (messageBoxResult != MessageBoxResult.Cancel)
						   {
							   Application.Current.Shutdown();
						   }
					   }));
			}
		}
		public ICommand NewCommand
		{
			get
			{
				return _newCommand ??
					   (_newCommand = new RelayCommand(obj => { Text = string.Empty; }));
			}
		}
		public ICommand UndoCommand { get; } = ApplicationCommands.Undo;
		public ICommand RedoCommand { get; } = ApplicationCommands.Redo;
		public ICommand CutCommand { get; } = ApplicationCommands.Cut;
		public ICommand CopyCommand { get; } = ApplicationCommands.Copy;
		public ICommand PasteCommand { get; } = ApplicationCommands.Paste;
		public ICommand SelectAllCommand { get; } = ApplicationCommands.SelectAll;


		public MainViewModel(ITextProvider textProvider, IDialogService dialogService)
		{
			_textProvider = textProvider;
			_dialogService = dialogService;
		}

	}
}