using StructureMap;
using TextEditorApp.BLL;
using TextEditorApp.DAL;
using TextEditorApp.ViewModels;
using TextEditorApp.Views;

namespace TextEditorApp
{
	public class AppRegistry : Registry
	{
		public AppRegistry()
		{
			Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.WithDefaultConventions();
			});
			For<ITextProvider>().Use<TextProvider>();
			For<IDialogService>().Use<DialogService>();
			For<IMainViewModel>().Use<MainViewModel>();
			ForConcreteType<MainWindow>().Configure.Singleton();
		}
	}
}
