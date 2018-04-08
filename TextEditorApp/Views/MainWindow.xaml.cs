using TextEditorApp.ViewModels;

namespace TextEditorApp.Views
{
	public partial class MainWindow
	{
		public MainWindow(IMainViewModel mainViewModel)
		{
			InitializeComponent();
			DataContext = mainViewModel;
		}

	}
}