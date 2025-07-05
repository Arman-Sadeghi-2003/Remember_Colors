using RememberColors.Tools.Enums;
using RememberColors.Tools.Exceptions;

namespace RememberColors.Tools.Navigators
{
	internal class MainViewNavigator
	{
		public static MainViewNavigator Instance { get; } = new MainViewNavigator();

		private MainViewNavigator()
		{
			// Private constructor to prevent instantiation
		}

		private Action<MainViews>? navigateAction;

		/// <summary>
		/// Sets the navigation action to be invoked when navigating to a view.
		/// </summary>
		/// <param name="action">The action to perform navigation.</param>
		public void SetAction(Action<MainViews> action)
		{
			navigateAction = action ?? throw new ArgumentNullException(nameof(action));
		}

		/// <summary>
		/// Navigates to the specified view, handling exceptions gracefully.
		/// </summary>
		/// <param name="view">The target view to navigate to.</param>
		public void NavigateTo(MainViews view)
		{
			if (navigateAction == null)
				throw new InvalidOperationException("Navigation action has not been set.");

			try
			{
				navigateAction.Invoke(view);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed for your application.
				// For now, rethrowing with additional context.
				throw new NavigationException($"Failed to navigate to {view}.", ex);
			}
		}
	}
}