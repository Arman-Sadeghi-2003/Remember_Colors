namespace RememberColors.Tools.Exceptions
{
	/// <summary>
	/// Exception thrown when command execution fails.
	/// </summary>
	public class CommandExecutionException : Exception
	{
		public CommandExecutionException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}