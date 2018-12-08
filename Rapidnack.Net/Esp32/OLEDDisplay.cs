namespace Rapidnack.Net.Esp32
{
	public class OLEDDisplay
	{

		public enum Color
		{
			BLACK = 0,
			WHITE = 1,
			INVERSE = 2
		}

		public enum TextAlignment
		{
			TEXT_ALIGN_LEFT = 0,
			TEXT_ALIGN_RIGHT = 1,
			TEXT_ALIGN_CENTER = 2,
			TEXT_ALIGN_CENTER_BOTH = 3
		}

		private const int OLEDDISPLAY_BASE = 20200;
		// bool init();
		private const int OLEDDISPLAY_INIT = (OLEDDISPLAY_BASE + 0);
		// void end();
		private const int OLEDDISPLAY_END = (OLEDDISPLAY_BASE + 1);
		// void resetDisplay(void);
		private const int OLEDDISPLAY_RESET_DISPLAY = (OLEDDISPLAY_BASE + 2);
		// void setColor(OLEDOLEDDISPLAY_COLOR color);
		private const int OLEDDISPLAY_SET_COLOR = (OLEDDISPLAY_BASE + 3);
		// OLEDOLEDDISPLAY_COLOR getColor();
		private const int OLEDDISPLAY_GET_COLOR = (OLEDDISPLAY_BASE + 4);
		// void setPixel(int16_t x, int16_t y);
		private const int OLEDDISPLAY_SET_PIXEL = (OLEDDISPLAY_BASE + 5);
		// void drawLine(int16_t x0, int16_t y0, int16_t x1, int16_t y1);
		private const int OLEDDISPLAY_DRAW_LINE = (OLEDDISPLAY_BASE + 6);
		// void drawRect(int16_t x, int16_t y, int16_t width, int16_t height);
		private const int OLEDDISPLAY_DRAW_RECT = (OLEDDISPLAY_BASE + 7);
		// void fillRect(int16_t x, int16_t y, int16_t width, int16_t height);
		private const int OLEDDISPLAY_FILL_RECT = (OLEDDISPLAY_BASE + 8);
		// void drawCircle(int16_t x, int16_t y, int16_t radius);
		private const int OLEDDISPLAY_DRAW_CIRCLE = (OLEDDISPLAY_BASE + 9);
		// void drawCircleQuads(int16_t x0, int16_t y0, int16_t radius, uint8_t quads);
		private const int OLEDDISPLAY_DRAW_CIRCLE_QUADS = (OLEDDISPLAY_BASE + 10);
		// void fillCircle(int16_t x, int16_t y, int16_t radius);
		private const int OLEDDISPLAY_FILL_CIRCLE = (OLEDDISPLAY_BASE + 11);
		// void drawHorizontalLine(int16_t x, int16_t y, int16_t length);
		private const int OLEDDISPLAY_DRAW_HORIZONTAL_LINE = (OLEDDISPLAY_BASE + 12);
		// void drawVerticalLine(int16_t x, int16_t y, int16_t length);
		private const int OLEDDISPLAY_DRAW_VERTICAL_LINE = (OLEDDISPLAY_BASE + 13);
		// void drawProgressBar(uint16_t x, uint16_t y, uint16_t width, uint16_t height, uint8_t progress);
		private const int OLEDDISPLAY_DRAW_PROGRESS_BAR = (OLEDDISPLAY_BASE + 14);
		// void drawFastImage(int16_t x, int16_t y, int16_t width, int16_t height, const uint8_t *image);
		private const int OLEDDISPLAY_DRAW_FAST_IMAGE = (OLEDDISPLAY_BASE + 15);
		// void drawXbm(int16_t x, int16_t y, int16_t width, int16_t height, const uint8_t *xbm);
		private const int OLEDDISPLAY_DRAW_XBM = (OLEDDISPLAY_BASE + 16);
		// void drawString(int16_t x, int16_t y, String text);
		private const int OLEDDISPLAY_DRAW_STRING = (OLEDDISPLAY_BASE + 17);
		// void drawStringMaxWidth(int16_t x, int16_t y, uint16_t maxLineWidth, String text);
		private const int OLEDDISPLAY_DRAW_STRING_MAX_WIDTH = (OLEDDISPLAY_BASE + 18);
		// uint16_t getStringWidth(const char* text, uint16_t length);
		// uint16_t getStringWidth(String text);
		private const int OLEDDISPLAY_GET_STRING_WIDTH = (OLEDDISPLAY_BASE + 19);
		// void setTextAlignment(OLEDOLEDDISPLAY_TEXT_ALIGNMENT textAlignment);
		private const int OLEDDISPLAY_SET_TEXT_ALIGNMENT = (OLEDDISPLAY_BASE + 20);
		// void setFont(const uint8_t *fontData);
		private const int OLEDDISPLAY_SET_FONT = (OLEDDISPLAY_BASE + 21);
		// void setFontTableLookupFunction(FontTableLookupFunction function);
		// void displayOn(void);
		private const int OLEDDISPLAY_OLEDDISPLAY_ON = (OLEDDISPLAY_BASE + 22);
		// void displayOff(void);
		private const int OLEDDISPLAY_OLEDDISPLAY_OFF = (OLEDDISPLAY_BASE + 23);
		// void invertDisplay(void);
		private const int OLEDDISPLAY_INVERT_DISPLAY = (OLEDDISPLAY_BASE + 24);
		// void normalDisplay(void);
		private const int OLEDDISPLAY_NORMAL_DISPLAY = (OLEDDISPLAY_BASE + 25);
		// void setContrast(uint8_t contrast, uint8_t precharge = 241, uint8_t comdetect = 64);
		private const int OLEDDISPLAY_SET_CONTRAST = (OLEDDISPLAY_BASE + 26);
		// void setBrightness(uint8_t);
		private const int OLEDDISPLAY_SET_BRIGHTNESS = (OLEDDISPLAY_BASE + 27);
		// void resetOrientation();
		private const int OLEDDISPLAY_RESET_ORIENTATION = (OLEDDISPLAY_BASE + 28);
		// void flipScreenVertically();
		private const int OLEDDISPLAY_FLIP_SCREEN_VERTICALLY = (OLEDDISPLAY_BASE + 29);
		// void mirrorScreen();
		private const int OLEDDISPLAY_MIRROR_SCREEN = (OLEDDISPLAY_BASE + 30);
		// virtual void display(void) = 0;
		private const int OLEDDISPLAY_DISPLAY = (OLEDDISPLAY_BASE + 31);
		// void clear(void);
		private const int OLEDDISPLAY_CLEAR = (OLEDDISPLAY_BASE + 32);
		// bool setLogBuffer(uint16_t lines, uint16_t chars);
		private const int OLEDDISPLAY_SET_LOG_BUFFER = (OLEDDISPLAY_BASE + 33);
		// void drawLogBuffer(uint16_t x, uint16_t y);
		private const int OLEDDISPLAY_DRAW_LOG_BUFFER = (OLEDDISPLAY_BASE + 34);
		// uint16_t getWidth(void);
		private const int OLEDDISPLAY_GET_WIDTH = (OLEDDISPLAY_BASE + 35);
		// uint16_t getHeight(void);
		private const int OLEDDISPLAY_GET_HEIGHT = (OLEDDISPLAY_BASE + 36);
		// size_t write(uint8_t c);
		private const int OLEDDISPLAY_WRITE_CHAR = (OLEDDISPLAY_BASE + 37);
		// size_t write(const char* s);
		private const int OLEDDISPLAY_WRITE_STRING = (OLEDDISPLAY_BASE + 38);
		private const int OLEDDISPLAY_PRINT = (OLEDDISPLAY_BASE + 39);
		private const int OLEDDISPLAY_PRINTLN = (OLEDDISPLAY_BASE + 40);

		private Esp32If esp32If;


		public OLEDDisplay(Esp32If esp32If)
		{
			this.esp32If = esp32If;
		}


		// bool init();
		// private const int OLEDDISPLAY_INIT = (OLEDDISPLAY_BASE + 0);
		public bool init()
		{ return esp32If.GpioCommand(OLEDDISPLAY_INIT, 0, 0) != 0; }

		// void end();
		// private const int OLEDDISPLAY_END = (OLEDDISPLAY_BASE + 1);
		public void end()
		{ esp32If.GpioCommand(OLEDDISPLAY_END, 0, 0); }

		// void resetDisplay(void);
		// private const int OLEDDISPLAY_RESET_DISPLAY = (OLEDDISPLAY_BASE + 2);
		public void resetDisplay()
		{ esp32If.GpioCommand(OLEDDISPLAY_RESET_DISPLAY, 0, 0); }

		// void setColor(OLEDOLEDDISPLAY_COLOR color);
		// private const int OLEDDISPLAY_SET_COLOR = (OLEDDISPLAY_BASE + 3);
		public void setColor(Color color)
		{ esp32If.GpioCommand(OLEDDISPLAY_SET_COLOR, (int)color, 0); }

		// OLEDOLEDDISPLAY_COLOR getColor();
		// private const int OLEDDISPLAY_GET_COLOR = (OLEDDISPLAY_BASE + 4);
		public Color getColor()
		{ return (Color)esp32If.GpioCommand(OLEDDISPLAY_GET_COLOR, 0, 0); }

		// void setPixel(int16_t x, int16_t y);
		// private const int OLEDDISPLAY_SET_PIXEL = (OLEDDISPLAY_BASE + 5);
		public void setPixel(int x, int y)
		{ esp32If.GpioCommand(OLEDDISPLAY_SET_PIXEL, x, y); }

		// void drawLine(int16_t x0, int16_t y0, int16_t x1, int16_t y1);
		// private const int OLEDDISPLAY_DRAW_LINE = (OLEDDISPLAY_BASE + 6);
		public void drawLine(int x0, int y0, int x1, int y1)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=x0
			p2=y0
			## extension ##
			int x1
			int y1
			*/

			exts[0].Contents = esp32If.IntToBytes(x1);
			exts[1].Contents = esp32If.IntToBytes(y1);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_LINE, x0, y0, exts);
		}

		// void drawRect(int16_t x, int16_t y, int16_t width, int16_t height);
		// private const int OLEDDISPLAY_DRAW_RECT = (OLEDDISPLAY_BASE + 7);
		public void drawRect(int x, int y, int width, int height)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=x
			p2=y
			## extension ##
			int width
			int height
			*/

			exts[0].Contents = esp32If.IntToBytes(width);
			exts[1].Contents = esp32If.IntToBytes(height);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_RECT, x, y, exts);
		}

		// void fillRect(int16_t x, int16_t y, int16_t width, int16_t height);
		// private const int OLEDDISPLAY_FILL_RECT = (OLEDDISPLAY_BASE + 8);
		public void fillRect(int x, int y, int width, int height)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=x
			p2=y
			## extension ##
			int width
			int height
			*/

			exts[0].Contents = esp32If.IntToBytes(width);
			exts[1].Contents = esp32If.IntToBytes(height);

			esp32If.GpioCommandExt(OLEDDISPLAY_FILL_RECT, x, y, exts);
		}

		// void drawCircle(int16_t x, int16_t y, int16_t radius);
		// private const int OLEDDISPLAY_DRAW_CIRCLE = (OLEDDISPLAY_BASE + 9);
		public void drawCircle(int x, int y, int radius)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=x
			p2=y
			## extension ##
			int radius
			*/

			exts[0].Contents = esp32If.IntToBytes(radius);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_CIRCLE, x, y, exts);
		}

		// void drawCircleQuads(int16_t x0, int16_t y0, int16_t radius, uint8_t quads);
		// private const int OLEDDISPLAY_DRAW_CIRCLE_QUADS = (OLEDDISPLAY_BASE + 10);
		public void drawCircleQuads(int x0, int y0, int radius, int quads)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=x0
			p2=y0
			## extension ##
			int radius
			int quads
			*/

			exts[0].Contents = esp32If.IntToBytes(radius);
			exts[1].Contents = esp32If.IntToBytes(quads);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_CIRCLE_QUADS, x0, y0, exts);
		}

		// void fillCircle(int16_t x, int16_t y, int16_t radius);
		// private const int OLEDDISPLAY_FILL_CIRCLE = (OLEDDISPLAY_BASE + 11);
		public void fillCircle(int x, int y, int radius)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=x
			p2=y
			## extension ##
			int radius
			*/

			exts[0].Contents = esp32If.IntToBytes(radius);

			esp32If.GpioCommandExt(OLEDDISPLAY_FILL_CIRCLE, x, y, exts);
		}

		// void drawHorizontalLine(int16_t x, int16_t y, int16_t length);
		// private const int OLEDDISPLAY_DRAW_HORIZONTAL_LINE = (OLEDDISPLAY_BASE + 12);
		public void drawHorizontalLine(int x, int y, int length)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=x
			p2=y
			## extension ##
			int length
			*/

			exts[0].Contents = esp32If.IntToBytes(length);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_HORIZONTAL_LINE, x, y, exts);
		}

		// void drawVerticalLine(int16_t x, int16_t y, int16_t length);
		// private const int OLEDDISPLAY_DRAW_VERTICAL_LINE = (OLEDDISPLAY_BASE + 13);
		public void drawVerticalLine(int x, int y, int length)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=x
			p2=y
			## extension ##
			int length
			*/

			exts[0].Contents = esp32If.IntToBytes(length);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_VERTICAL_LINE, x, y, exts);
		}

		// void drawProgressBar(uint16_t x, uint16_t y, uint16_t width, uint16_t height, uint8_t progress);
		// private const int OLEDDISPLAY_DRAW_PROGRESS_BAR = (OLEDDISPLAY_BASE + 14);
		public void drawProgressBar(int x, int y, int width, int height, int progress)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=x
			p2=y
			## extension ##
			int width
			int height
			int progress
			*/

			exts[0].Contents = esp32If.IntToBytes(width);
			exts[1].Contents = esp32If.IntToBytes(height);
			exts[2].Contents = esp32If.IntToBytes(progress);

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_PROGRESS_BAR, x, y, exts);
		}

		// void drawFastImage(int16_t x, int16_t y, int16_t width, int16_t height, const uint8_t *image);
		// private const int OLEDDISPLAY_DRAW_FAST_IMAGE = (OLEDDISPLAY_BASE + 15);

		// void drawXbm(int16_t x, int16_t y, int16_t width, int16_t height, const uint8_t *xbm);
		// private const int OLEDDISPLAY_DRAW_XBM = 1616;

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

		// void drawStringMaxWidth(int16_t x, int16_t y, uint16_t maxLineWidth, String text);
		// private const int OLEDDISPLAY_DRAW_STRING_MAX_WIDTH = (OLEDDISPLAY_BASE + 18);
		public void drawStringMaxWidth(int x, int y, int maxLineWidth, string text)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=x
			p2=y
			## extension ##
			int maxLineWidth
			char text[len]
			*/

			exts[0].Contents = esp32If.IntToBytes(maxLineWidth);
			exts[1].Contents = System.Text.Encoding.UTF8.GetBytes(text + "\0"); /* include null byte */

			esp32If.GpioCommandExt(OLEDDISPLAY_DRAW_STRING_MAX_WIDTH, x, y, exts);
		}

		// uint16_t getStringWidth(const char* text, uint16_t length);

		// uint16_t getStringWidth(String text);
		// private const int OLEDDISPLAY_GET_STRING_WIDTH = (OLEDDISPLAY_BASE + 19);
		public int getStringWidth(string text)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=0
			p2=0
			## extension ##
			char text[len]
			*/

			exts[0].Contents = System.Text.Encoding.UTF8.GetBytes(text + "\0"); /* include null byte */

			return esp32If.GpioCommandExt(OLEDDISPLAY_GET_STRING_WIDTH, 0, 0, exts);
		}

		// void setTextAlignment(OLEDOLEDDISPLAY_TEXT_ALIGNMENT textAlignment);
		// private const int OLEDDISPLAY_SET_TEXT_ALIGNMENT = (OLEDDISPLAY_BASE + 20);
		public void setTextAlignment(TextAlignment textAlignment)
		{ esp32If.GpioCommand(OLEDDISPLAY_SET_TEXT_ALIGNMENT, (int)textAlignment, 0); }

		// void setFont(const uint8_t *fontData);
		// private const int OLEDDISPLAY_SET_FONT = (OLEDDISPLAY_BASE + 21);
		public void setFont(int size)
		{ esp32If.GpioCommand(OLEDDISPLAY_SET_FONT, size, 0); }

		// void setFontTableLookupFunction(FontTableLookupFunction function);

		// void displayOn(void);
		// private const int OLEDDISPLAY_OLEDDISPLAY_ON = (OLEDDISPLAY_BASE + 22);
		public void displayOn()
		{ esp32If.GpioCommand(OLEDDISPLAY_OLEDDISPLAY_ON, 0, 0); }

		// void displayOff(void);
		// private const int OLEDDISPLAY_OLEDDISPLAY_OFF = (OLEDDISPLAY_BASE + 23);
		public void displayOff()
		{ esp32If.GpioCommand(OLEDDISPLAY_OLEDDISPLAY_OFF, 0, 0); }

		// void invertDisplay(void);
		// private const int OLEDDISPLAY_INVERT_DISPLAY = (OLEDDISPLAY_BASE + 24);
		public void invertDisplay()
		{ esp32If.GpioCommand(OLEDDISPLAY_INVERT_DISPLAY, 0, 0); }

		// void normalDisplay(void);
		// private const int OLEDDISPLAY_NORMAL_DISPLAY = (OLEDDISPLAY_BASE + 25);
		public void normalDisplay()
		{ esp32If.GpioCommand(OLEDDISPLAY_NORMAL_DISPLAY, 0, 0); }

		// void setContrast(uint8_t contrast, uint8_t precharge = 241, uint8_t comdetect = 64);
		// private const int OLEDDISPLAY_SET_CONTRAST = (OLEDDISPLAY_BASE + 26);
		public void setContrast(int contrast, int precharge = 241, int comdetect = 64)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=contrast
			p2=precharge
			## extension ##
			int comdetect
			*/

			exts[0].Contents = esp32If.IntToBytes(comdetect);

			esp32If.GpioCommandExt(OLEDDISPLAY_SET_CONTRAST, contrast, precharge, exts);
		}

		// void setBrightness(uint8_t brightness);
		// private const int OLEDDISPLAY_SET_BRIGHTNESS = (OLEDDISPLAY_BASE + 27);
		public void setBrightness(int brightness)
		{ esp32If.GpioCommand(OLEDDISPLAY_SET_BRIGHTNESS, brightness, 0); }

		// void resetOrientation();
		// private const int OLEDDISPLAY_RESET_ORIENTATION = (OLEDDISPLAY_BASE + 28);
		public void resetOrientation()
		{ esp32If.GpioCommand(OLEDDISPLAY_RESET_ORIENTATION, 0, 0); }

		// void flipScreenVertically();
		// private const int OLEDDISPLAY_FLIP_SCREEN_VERTICALLY = (OLEDDISPLAY_BASE + 29);
		public void flipScreenVertically()
		{ esp32If.GpioCommand(OLEDDISPLAY_FLIP_SCREEN_VERTICALLY, 0, 0); }

		// void mirrorScreen();
		// private const int OLEDDISPLAY_MIRROR_SCREEN = (OLEDDISPLAY_BASE + 30);
		public void mirrorScreen()
		{ esp32If.GpioCommand(OLEDDISPLAY_MIRROR_SCREEN, 0, 0); }

		// virtual void display(void) = 0;
		// private const int OLEDDISPLAY_DISPLAY = (OLEDDISPLAY_BASE + 31);
		public void display()
		{ esp32If.GpioCommand(OLEDDISPLAY_DISPLAY, 0, 0); }

		// void clear(void);
		// private const int OLEDDISPLAY_CLEAR = (OLEDDISPLAY_BASE + 32);
		public int clear()
		{ return esp32If.GpioCommand(OLEDDISPLAY_CLEAR, 0, 0); }

		// bool setLogBuffer(uint16_t lines, uint16_t chars);
		// private const int OLEDDISPLAY_SET_LOG_BUFFER = (OLEDDISPLAY_BASE + 33);
		public bool setLogBuffer(int lines, int chars)
		{ return esp32If.GpioCommand(OLEDDISPLAY_SET_LOG_BUFFER, lines, chars) != 0; }

		// void drawLogBuffer(uint16_t x, uint16_t y);
		// private const int OLEDDISPLAY_DRAW_LOG_BUFFER = (OLEDDISPLAY_BASE + 34);
		public void drawLogBuffer(int x, int y)
		{ esp32If.GpioCommand(OLEDDISPLAY_DRAW_LOG_BUFFER, x, y); }

		// uint16_t getWidth(void);
		// private const int OLEDDISPLAY_GET_WIDTH = (OLEDDISPLAY_BASE + 35);
		public int getWidth()
		{ return esp32If.GpioCommand(OLEDDISPLAY_GET_WIDTH, 0, 0); }

		// uint16_t getHeight(void);
		// private const int OLEDDISPLAY_GET_HEIGHT = (OLEDDISPLAY_BASE + 36);
		public int getHeight()
		{ return esp32If.GpioCommand(OLEDDISPLAY_GET_HEIGHT, 0, 0); }

		// size_t write(uint8_t c);
		// private const int OLEDDISPLAY_WRITE_CHAR = (OLEDDISPLAY_BASE + 37);
		public uint write(char c)
		{ return (uint)esp32If.GpioCommand(OLEDDISPLAY_WRITE_CHAR, (int)c, 0); }

		// size_t write(const char* s);
		// private const int OLEDDISPLAY_WRITE_STRING = (OLEDDISPLAY_BASE + 38);
		public uint write(string s)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=0
			p2=0
			## extension ##
			char s[len]
			*/

			exts[0].Contents = System.Text.Encoding.UTF8.GetBytes(s + "\0"); /* include null byte */

			return (uint)esp32If.GpioCommandExt(OLEDDISPLAY_WRITE_STRING, 0, 0, exts);
		}

		// private const int OLEDDISPLAY_PRINT = (OLEDDISPLAY_BASE + 39);
		public void print(string text)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=0
			p2=0
			## extension ##
			char text[len]
			*/

			exts[0].Contents = System.Text.Encoding.UTF8.GetBytes(text + "\0"); /* include null byte */

			esp32If.GpioCommandExt(OLEDDISPLAY_PRINT, 0, 0, exts);
		}

		// private const int OLEDDISPLAY_PRINTLN = (OLEDDISPLAY_BASE + 40);
		public void println(string text)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=0
			p2=0
			## extension ##
			char text[len]
			*/

			exts[0].Contents = System.Text.Encoding.UTF8.GetBytes(text + "\0"); /* include null byte */

			esp32If.GpioCommandExt(OLEDDISPLAY_PRINTLN, 0, 0, exts);
		}
	}
}
