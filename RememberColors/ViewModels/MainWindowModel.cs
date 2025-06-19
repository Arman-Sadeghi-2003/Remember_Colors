using RememberColors.Views;
using System.Windows.Controls;

namespace RememberColors.ViewModels
{
	public class MainWindowModel : ViewModelBase
	{
		#region Fields

		private Control mainView;

		#endregion Fields

		#region Properties

		public Control MainView
		{
			get => mainView;
			set
			{
				mainView = value;
				OnPropertyChanged();
			}
		}

		#endregion Properties

		public MainWindowModel()
		{
			MainView = new MainView(new());
		}
	}
}