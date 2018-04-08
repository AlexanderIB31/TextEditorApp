using StructureMap;
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
			For<IDialogProvider>().Use<DialogProvider>();
			For<IMainViewModel>().Use<MainViewModel>();
			ForConcreteType<MainWindow>().Configure.Singleton();
		}
	}
}
