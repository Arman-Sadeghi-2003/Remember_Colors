using RememberColors.ViewModels;
using System.Windows;

namespace RememberColors.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(MainWindowModel vm)
		{
			InitializeComponent();
			DataContext = vm;
		}
	}
}
