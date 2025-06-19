using RememberColors.ViewModels;
using System.Windows.Controls;

namespace RememberColors.Views
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : UserControl
	{
		public MainView(MainViewModel vm)
		{
			InitializeComponent();
			DataContext = vm;
		}
	}
}
