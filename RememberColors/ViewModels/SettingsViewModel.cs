using RememberColors.Models.Settings;

namespace RememberColors.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		private SettingsModel model;

		public SettingsViewModel(SettingsModel model)
		{
			this.model = model;
		}
	}
}