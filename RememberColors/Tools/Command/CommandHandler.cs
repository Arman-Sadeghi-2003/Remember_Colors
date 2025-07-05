using RememberColors.Tools.Exceptions;
using System.Windows.Input;

namespace RememberColors.Tools.Command
{
	/// <summary>
	/// A flexible ICommand implementation for WPF command binding.
	/// </summary>
	public class CommandHandler : ICommand
	{
		private readonly Action<object?> _execute;
		private readonly Func<object?, bool>? _canExecute;

		/// <summary>
		/// Initializes a new instance of the CommandHandler class.
		/// </summary>
		/// <param name="execute">The action to execute.</param>
		/// <param name="canExecute">The function that determines if the command can execute.</param>
		public CommandHandler(Action<object?> execute, Func<object?, bool>? canExecute = null)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		public event EventHandler? CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public bool CanExecute(object? parameter)
		{
			try
			{
				return _canExecute?.Invoke(parameter) ?? true;
			}
			catch (Exception)
			{
				// Optionally log or handle exception
				return false;
			}
		}

		public void Execute(object? parameter)
		{
			try
			{
				_execute(parameter);
			}
			catch (Exception ex)
			{
				// Optionally log or handle exception
				throw new CommandExecutionException("An error occurred during command execution.", ex);
			}
		}
	}
}