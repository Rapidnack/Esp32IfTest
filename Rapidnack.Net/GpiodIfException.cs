using System;

namespace Rapidnack.Net
{
	public class GpiodIfException : Exception
	{
		public GpiodIfException(string message)
			: base(message)
		{
		}
	}
}
