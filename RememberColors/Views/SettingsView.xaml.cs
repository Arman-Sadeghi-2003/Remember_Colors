using RememberColors.Models.Settings;
using RememberColors.ViewModels;
using System.Windows.Controls;

namespace RememberColors.Views
{
	/// <summary>
	/// Interaction logic for SettingsView.xaml
	/// </summary>
	public partial class SettingsView : UserControl
	{
		public SettingsView()
		{
			InitializeComponent();
			DataContext = new SettingsViewModel(new SettingsModel());
		}
	}
}