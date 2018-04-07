using System.Configuration;
using System.Net.Mime;
using System.Windows;
using StructureMap;
using TextEditorApp.Views;

namespace TextEditorApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		private void OnStartup(object sender, StartupEventArgs startupEventArgs)
		{
			var container = Container.For<AppRegistry>();
			MainWindow wnd = container.GetInstance<MainWindow>();
			wnd.Show();
		}
	}
}