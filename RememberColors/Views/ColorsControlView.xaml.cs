using RememberColors.ViewModels;
using System.Windows.Controls;

namespace RememberColors.Views
{
	/// <summary>
	/// Interaction logic for ColorsControlView.xaml
	/// </summary>
	public partial class ColorsControlView : UserControl
	{
		public ColorsControlView(ColorsControlViewModel vm)
		{
			InitializeComponent();
			DataContext = vm;
		}
	}
}
