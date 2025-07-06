using RememberColors.Models.Settings;
using RememberColors.Tools.Command;
using RememberColors.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace RememberColors.ViewModels
{
	/// <summary>
	/// ViewModel for the SettingsView, handles logic for settings manipulation and persistence.
	/// </summary>
	public class SettingsViewModel : ViewModelBase
	{
		private const string SettingsFileName = "settings.json";

		private static readonly string SettingsFilePath =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RememberColors", SettingsFileName);

		private SettingsModel model;
		private int showSpeed = 1;

		public SettingsModel Model => model;

		public int ShowSpeed
		{
			get => showSpeed;
			set
			{
				showSpeed = value;
				OnPropertyChanged();
			}
		}

		public ICommand SaveCommand { get; }
		public ICommand LoadCommand { get; }
		public ICommand HomeCommand { get; }
		public ICommand SelectColorCommand { get; }

		/// <summary>
		/// Initializes a new instance of the SettingsViewModel class.
		/// </summary>
		/// <param name="model">The settings model to use.</param>
		public SettingsViewModel(SettingsModel model)
		{
			this.model = model;
			SaveCommand = new CommandHandler(_ => SaveSettings());
			LoadCommand = new CommandHandler(_ => LoadSettings());
			HomeCommand = new CommandHandler(_ => GoHome());
			SelectColorCommand = new CommandHandler(param => SelectColor(param as string));
		}

		/// <summary>
		/// Saves the current settings to the local application data directory.
		/// </summary>
		public void SaveSettings()
		{
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(SettingsFilePath)!);
				FileHelper.SaveToFile(SettingsFilePath, model);
			}
			catch (Exception ex)
			{
				// Handle or log exception as needed
				// Optionally notify the user
			}
		}

		/// <summary>
		/// Loads settings from the local application data directory.
		/// </summary>
		public void LoadSettings()
		{
			try
			{
				var loaded = FileHelper.OpenFromFile<SettingsModel>(SettingsFilePath);
				if (loaded != null)
				{
					model.ShowColorsNumber = loaded.ShowColorsNumber;
					model.IsRandom = loaded.IsRandom;
					model.SelectedColors = loaded.SelectedColors;
					OnPropertyChanged(nameof(Model));
				}
			}
			catch (Exception ex)
			{
				// Handle or log exception as needed
			}
		}

		/// <summary>
		/// Handles navigation to the home view.
		/// </summary>
		public void GoHome()
		{
			// Implement navigation logic as needed
		}

		/// <summary>
		/// Selects or deselects a color for the SelectedColors list.
		/// </summary>
		/// <param name="color">The color name to select or deselect.</param>
		public void SelectColor(string? color)
		{
			if (string.IsNullOrEmpty(color) || model.IsRandom)
				return;

			if (model.SelectedColors.Contains(color))
				model.SelectedColors.Remove(color);
			else if (model.SelectedColors.Count < model.ShowColorsNumber)
				model.SelectedColors.Add(color);

			// Ensure the list does not exceed the allowed number
			if (model.SelectedColors.Count > model.ShowColorsNumber)
				model.SelectedColors = model.SelectedColors.Take(model.ShowColorsNumber).ToList();

			OnPropertyChanged(nameof(Model));
		}
	}
}