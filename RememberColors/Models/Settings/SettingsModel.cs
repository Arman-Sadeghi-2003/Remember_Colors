using System.Drawing;

namespace RememberColors.Models.Settings
{
	public class SettingsModel
	{
		#region Fields

		private int showColorsNumber = 3;
		private bool isRandom = true;
		private List<Color> selectedColors = new();

		#endregion
	}
}
