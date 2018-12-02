using System;
using System.Windows.Forms;

namespace Esp32IfTest
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.ThreadException += (s, e) =>
			{
				Console.WriteLine(
					"{0}, {1}\r\n{2}\r\n", e.Exception.TargetSite, e.Exception.Message, e.Exception.StackTrace);
			};
			AppDomain.CurrentDomain.UnhandledException += (s, e) =>
			{
				Exception ex = e.ExceptionObject as Exception;
				if (ex != null)
				{
					Console.WriteLine(
						"{0}, {1}\r\n{2}\r\n", ex.TargetSite, ex.Message, ex.StackTrace);
				}
			};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
