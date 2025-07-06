namespace RememberColors.Models.Settings
{
	public class SettingsModel
	{
		#region Fields

		private int showColorsNumber = 3;
		private bool isRandom = true;
		private List<string> selectedColors = new();

		#endregion Fields

		#region Properties

		public int ShowColorsNumber
		{
			get => showColorsNumber;
			set
			{
				var s = SelectableColors.Values;
				showColorsNumber = value;
				selectedColors = new();
			}
		}

		public bool IsRandom
		{
			get => isRandom;
			set
			{
				isRandom = value;
				selectedColors = new();
			}
		}

		public List<string> SelectedColors
		{
			get => selectedColors;
			set => selectedColors = value;
		}

		public Dictionary<string, string> SelectableColors = new()
		{
			{"Red", "#FFFF0000"},
			{"Green", "#FF00FF00"},
			{"Blue", "#FF0000FF"},
			{"Pink", "#FFFF0080"},
			{"Purple", "#FF8000FF"},
			{"Yellow", "#FFFFD000"},
			{"Brown", "#FF864111"},
			{"Gray", "#FF808080"},
		};

		#endregion Properties
	}
}