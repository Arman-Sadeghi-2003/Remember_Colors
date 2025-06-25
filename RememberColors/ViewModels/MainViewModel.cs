using System.Windows;

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

	}
}
