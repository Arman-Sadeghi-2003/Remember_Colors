using RememberColors.ViewModels;
using RememberColors.Views;
using System.Windows;

namespace RememberColors
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			var vm = new MainWindowModel();

			var main = new MainWindow(vm);
			main.Show();
		}
	}

}
