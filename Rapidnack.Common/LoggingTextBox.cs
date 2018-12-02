using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Rapidnack.Common
{
	public partial class LoggingTextBox : TextBox
	{
		private LogWriter logWriter;

		[DefaultValue(10000), Category("Logging"), Description("Maximum number of characters")]
		public int Limit { get; set; } = 10000;

		public LoggingTextBox()
		{
			InitializeComponent();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			logWriter = new LogWriter();
			Console.SetOut(logWriter);
			Console.SetError(logWriter);
			logWriter.TextChanged += (s, evt) =>
			{
				try
				{
					Invoke(new Action(() =>
					{
						int limit = Limit;
						if (Text.Length + evt.Length > limit * 2)
						{
							Select(0, Math.Min(Text.Length, Text.Length + evt.Length - limit));
							SelectedText = string.Empty;
						}
						AppendText(evt);
					}));
				}
				catch (InvalidOperationException)
				{
					// nothing to do
				}
			};
		}
	}
}
