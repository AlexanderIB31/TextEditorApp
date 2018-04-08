using System.Windows;
using StructureMap;
using TextEditorApp.DAL;
using TextEditorApp.Views;

namespace TextEditorApp
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs startupEventArgs)
		{
			var container = Container.For<AppRegistry>();
			MainWindow wnd = container.GetInstance<MainWindow>();
			wnd.Show();
		}
	}
}