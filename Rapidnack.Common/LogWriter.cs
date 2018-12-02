using System;

namespace Rapidnack.Common
{
	public class LogWriter : System.IO.TextWriter
	{
		public event EventHandler<string> TextChanged;


		public override System.Text.Encoding Encoding
		{
			get { return System.Text.Encoding.UTF8; }
		}


		public override void WriteLine(string value)
		{
			Write(value + "\r\n");
		}

		public override void Write(string value)
		{
			if (TextChanged != null)
			{
				TextChanged.Invoke(this, value);
			}
		}
	}
}
