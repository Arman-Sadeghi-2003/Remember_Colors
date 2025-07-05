using RememberColors.Tools.Enums;
using RememberColors.Tools.Navigators;
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
			// Set initial view
			MainView = new MainView(new());

			// Set the navigation action
			MainViewNavigator.Instance.SetAction(NavigateToView);
		}

		/// <summary>
		/// Changes the MainView property based on the given MainViews enum value.
		/// </summary>
		/// <param name="view">The target view enum.</param>
		public void NavigateToView(MainViews view)
		{
			try
			{
				switch (view)
				{
					case MainViews.Home:
						MainView = new MainView(new());
						break;

					case MainViews.Settings:
						MainView = new SettingsView();
						break;

					case MainViews.Gameplay:
						break;
					// Add more cases as needed for other views
					default:
						throw new ArgumentOutOfRangeException(nameof(view), $"No view defined for {view}.");
				}
			}
			catch (Exception ex)
			{
				// Optionally log or handle the exception
				throw new InvalidOperationException($"Failed to navigate to {view}.", ex);
			}
		}
	}
}