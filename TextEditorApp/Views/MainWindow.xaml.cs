using StructureMap;
using TextEditorApp.DAL;
using TextEditorApp.ViewModels;

namespace TextEditorApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();
			DataContext = mainViewModel;
        }
    }
}