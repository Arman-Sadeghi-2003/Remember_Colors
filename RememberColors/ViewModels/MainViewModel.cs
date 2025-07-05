using RememberColors.Tools.Command;
using RememberColors.Tools.Navigators;
using System.Windows;
using System.Windows.Input;

namespace RememberColors.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		#region Fields

		private Visibility startButtonVisibility;

		private bool mediumButtonEnabled;
		private bool hardButtonEnabled;

		#endregion

		#region Properties

		public Visibility StartButtonVisibility
		{
			get => startButtonVisibility;
			set
			{
				startButtonVisibility = value;
				OnPropertyChanged();
			}
		}

		public bool MediumButtonEnabled
		{
			get => mediumButtonEnabled;
			set
			{
				mediumButtonEnabled = value;
				OnPropertyChanged();
			}
		}

		public bool HardButtonEnabled
		{
			get => hardButtonEnabled;
			set
			{
				hardButtonEnabled = value;
				OnPropertyChanged();
			}
		}

		#endregion

		// ----> Constructor

		public MainViewModel()
		{
			SettingsCommand = new CommandHandler(SettingsAction);
		}

		#region Commands

		public ICommand? SettingsCommand { get; set; }

		#endregion

		#region Methods

		void SettingsAction(object? obj)
		{
			MainViewNavigator.Instance.NavigateTo(Tools.Enums.MainViews.Settings);
		}

		#endregion
	}
}
