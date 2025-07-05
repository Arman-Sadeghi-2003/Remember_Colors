using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberColors.Tools.Exceptions
{
	/// <summary>
	/// Custom exception for navigation errors.
	/// </summary>
	public class NavigationException : Exception
	{
		public NavigationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}