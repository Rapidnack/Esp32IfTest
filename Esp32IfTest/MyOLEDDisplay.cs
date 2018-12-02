using Rapidnack.Net.Esp32;

namespace Esp32IfTest
{
	public class MyOLEDDisplay
	{
		private const int OLEDDISPLAY_BASE = 20200;
		// void drawString(int16_t x, int16_t y, String text);
		private const int OLEDDISPLAY_DRAW_STRING = (OLEDDISPLAY_BASE + 17);
		// void setFont(const uint8_t *fontData);
		private const int OLEDDISPLAY_SET_FONT = (OLEDDISPLAY_BASE + 21);
		// virtual void display(void) = 0;
		private const int OLEDDISPLAY_DISPLAY = (OLEDDISPLAY_BASE + 31);
		// void clear(void);
		private const int OLEDDISPLAY_CLEAR = (OLEDDISPLAY_BASE + 32);

		private Esp32If esp32If;


		public MyOLEDDisplay(Esp32If esp32If)
		{
			this.esp32If = esp32If;
		}


		// void drawString(int16_t x, int16_t y, String text);
		// private const int OLEDDISPLAY_DRAW_STRING = 1617;
		public void drawString(int x, int y, string text)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=x
			p2=y
			## extension ##
			char text[len]
			*/

			exts[0].Contents = System.Text.Encoding.UTF8.GetBytes(text + "\0"); /* include null byte */

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_STRING, x, y, exts);
		}

		// void setFont(const uint8_t *fontData);
		// private const int OLEDDISPLAY_SET_FONT = (OLEDDISPLAY_BASE + 21);
		public void setFont(int size)
		{ esp32If.GpioCommand(OLEDDISPLAY_SET_FONT, size, 0); }

		// virtual void display(void) = 0;
		// private const int OLEDDISPLAY_DISPLAY = (OLEDDISPLAY_BASE + 31);
		public void display()
		{ esp32If.GpioCommand(OLEDDISPLAY_DISPLAY, 0, 0); }

		// void clear(void);
		// private const int OLEDDISPLAY_CLEAR = (OLEDDISPLAY_BASE + 32);
		public int clear()
		{ return esp32If.GpioCommand(OLEDDISPLAY_CLEAR, 0, 0); }
	}
}
