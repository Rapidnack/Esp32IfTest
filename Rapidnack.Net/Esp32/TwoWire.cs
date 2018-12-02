using System;
using System.Collections.Generic;
using System.Text;

namespace Rapidnack.Net.Esp32
{
	public class TwoWire : IDisposable
	{
		// esp32-hal-i2c.h (Wire.h): 600~

		public enum I2CError
		{
			OK = 0,
			DEV,
			ACK,
			TIMEOUT,
			BUS,
			BUSY,
			MEMORY,
			CONTINUE,
			NO_BEGIN
		}

		// void begin(int sda = -1, int scl = -1, uint32_t frequency = 0);
		private const int I2C_BEGIN = 600;
		// void setClock(uint32_t frequency); // change bus clock without initing hardware
		private const int I2C_SET_CLOCK = 601;
		// size_t getClock(); // current bus clock rate in hz
		private const int I2C_GET_CLOCK = 602;
		// void setTimeOut(uint16_t timeOutMillis);
		private const int I2C_SET_TIME_OUT = 603;
		// uint16_t getTimeOut();
		private const int I2C_GET_TIME_OUT = 604;
		// uint8_t lastError();
		private const int I2C_LAST_ERROR = 605;
		// char* getErrorText(uint8_t err);
		private const int I2C_GET_ERROR_TEXT = 606;
		// i2c_err_t writeTransmission(uint16_t address, uint8_t* buff, uint16_t size, bool sendStop = true);
		private const int I2C_WRITE_TRANSMISSION = 607;
		// i2c_err_t readTransmission(uint16_t address, uint8_t* buff, uint16_t size, bool sendStop = true, uint32_t* readCount = NULL);
		private const int I2C_READ_TRANSMISSION = 608;
		// void beginTransmission(uint16_t address);
		private const int I2C_BEGIN_TRANSMISSION16 = 609;
		// void beginTransmission(uint8_t address);
		private const int I2C_BEGIN_TRANSMISSION8 = 610;
		// void beginTransmission(int address);
		private const int I2C_BEGIN_TRANSMISSION = 611;
		// uint8_t endTransmission(bool sendStop);
		private const int I2C_END_TRANSMISSION_BOOL = 612;
		// uint8_t endTransmission(uint8_t sendStop);
		private const int I2C_END_TRANSMISSION_BYTE = 613;
		// uint8_t endTransmission(void);
		private const int I2C_END_TRANSMISSION = 614;
		// uint8_t requestFrom(uint16_t address, uint8_t size, bool sendStop);
		private const int I2C_REQUEST_FROM16_BOOL = 615;
		// uint8_t requestFrom(uint16_t address, uint8_t size, uint8_t sendStop);
		private const int I2C_REQUEST_FROM16_BYTE = 616;
		// uint8_t requestFrom(uint16_t address, uint8_t size);
		private const int I2C_REQUEST_FROM16 = 617;
		// uint8_t requestFrom(uint8_t address, uint8_t size, uint8_t sendStop);
		private const int I2C_REQUEST_FROM8_BYTE = 618;
		// uint8_t requestFrom(uint8_t address, uint8_t size);
		private const int I2C_REQUEST_FROM8 = 619;
		// uint8_t requestFrom(int address, int size, int sendStop);
		private const int I2C_REQUEST_FROM_INT = 620;
		// uint8_t requestFrom(int address, int size);
		private const int I2C_REQUEST_FROM = 621;
		// size_t write(uint8_t);
		private const int I2C_WRITE = 622;
		// size_t write(const uint8_t*, size_t);
		private const int I2C_WRITE_BYTES = 623;
		// int available(void);
		private const int I2C_AVAILABLE = 624;
		// int read(void);
		private const int I2C_READ = 625;
		// int peek(void);
		private const int I2C_PEEK = 626;
		// void flush(void);
		private const int I2C_FLUSH = 627;
		// inline size_t write(const char* s)
		private const int I2C_WRITE_TEXT = 628;
		// inline size_t write(unsigned long n)
		private const int I2C_WRITE_UINT32 = 629;
		// inline size_t write(long n)
		private const int I2C_WRITE_INT32 = 630;
		// inline size_t write(unsigned int n)
		private const int I2C_WRITE_UINT16 = 631;
		// inline size_t write(int n)
		private const int I2C_WRITE_INT16 = 632;
		// void onReceive(void (*)(int) );
		// void onRequest(void (*)(void) );
		// void dumpInts();
		private const int I2C_DUMP_INTS = 635;
		// void dumpI2C();
		private const int I2C_DUMP_I2C = 636;

		private static List<int> inUse = new List<int>();
		private Esp32If esp32If;
		private int busNum;


		public TwoWire(Esp32If esp32If, int busNum)
		{
			if (busNum < 0 || 1 < busNum)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (inUse.Contains(busNum))
			{
				throw new ArgumentException("I2C bus already in use");
			}
			inUse.Add(busNum);

			this.esp32If = esp32If;
			this.busNum = busNum;
		}

		public void Dispose()
		{
			inUse.Remove(busNum);
		}


		// void begin(int sda = -1, int scl = -1, uint32_t frequency = 0);
		// private const int I2C_BEGIN = 600;
		public void begin(int sda = -1, int scl = -1, uint frequency = 0)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=busNum
			p2=sda
			## extension ##
			int scl
			uint frequency
			*/

			exts[0].Contents = esp32If.IntToBytes(scl);
			exts[1].Contents = esp32If.IntToBytes((int)frequency);

			esp32If.GpioCommandExt(I2C_BEGIN, busNum, sda, exts);
		}

		// void setClock(uint32_t frequency); // change bus clock without initing hardware
		// private const int I2C_SET_CLOCK = 601;
		public void setClock(uint frequency)
		{ esp32If.GpioCommand(I2C_SET_CLOCK, busNum, (int)frequency); }

		// size_t getClock(); // current bus clock rate in hz
		// private const int I2C_GET_CLOCK = 602;
		public uint getClock(uint frequency)
		{ return (uint)esp32If.GpioCommand(I2C_GET_CLOCK, busNum, 0); }

		// void setTimeOut(uint16_t timeOutMillis);
		// private const int I2C_SET_TIME_OUT = 603;
		public void setTimeOut(int timeOutMillis)
		{ esp32If.GpioCommand(I2C_SET_TIME_OUT, busNum, timeOutMillis); }

		// uint16_t getTimeOut();
		// private const int I2C_GET_TIME_OUT = 604;
		public int getTimeOut()
		{ return esp32If.GpioCommand(I2C_GET_TIME_OUT, busNum, 0); }

		// uint8_t lastError();
		// private const int I2C_LAST_ERROR = 605;
		public int lastError()
		{ return esp32If.GpioCommand(I2C_LAST_ERROR, busNum, 0); }

		// char* getErrorText(uint8_t err);
		// private const int I2C_GET_ERROR_TEXT = 606;
		public string getErrorText(int err)
		{
			byte[] rxBuf;
			esp32If.GpioCommand(I2C_GET_ERROR_TEXT, busNum, err, out rxBuf);

			return Encoding.UTF8.GetString(rxBuf);
		}

		// i2c_err_t writeTransmission(uint16_t address, uint8_t* buff, uint16_t size, bool sendStop = true);
		// private const int I2C_WRITE_TRANSMISSION = 607;
		public I2CError writeTransmission(int address, byte[] buff, bool sendStop = true)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=busNum
			p2=address
			## extension ##
			bool sendStop
			byte[] buff
			*/

			exts[0].Contents = esp32If.IntToBytes(sendStop ? 1 : 0);
			exts[1].Contents = buff;

			return (I2CError)esp32If.GpioCommandExt(I2C_WRITE_TRANSMISSION, busNum, address, exts);
		}

		// i2c_err_t readTransmission(uint16_t address, uint8_t* buff, uint16_t size, bool sendStop = true, uint32_t* readCount = NULL);
		// private const int I2C_READ_TRANSMISSION = 608;
		public I2CError readTransmission(int address, byte[] buff, bool sendStop, out uint readCount)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=busNum
			p2=address
			## extension ##
			bool sendStop
			byte[] buff
			*/

			exts[0].Contents = esp32If.IntToBytes(sendStop ? 1 : 0);
			exts[1].Contents = buff;

			byte[] rxBuf;
			var ret = (I2CError)esp32If.GpioCommandExt(I2C_READ_TRANSMISSION, busNum, address, exts, out rxBuf);
			readCount = (uint)esp32If.BytesToInt(rxBuf);

			return ret;
		}

		// void beginTransmission(uint16_t address);
		// private const int I2C_BEGIN_TRANSMISSION16 = 609;
		public void beginTransmission(UInt16 address)
		{ esp32If.GpioCommand(I2C_BEGIN_TRANSMISSION16, busNum, address); }

		// void beginTransmission(uint8_t address);
		// private const int I2C_BEGIN_TRANSMISSION8 = 610;
		public void beginTransmission(byte address)
		{ esp32If.GpioCommand(I2C_BEGIN_TRANSMISSION8, busNum, address); }

		// void beginTransmission(int address);
		// private const int I2C_BEGIN_TRANSMISSION = 611;
		public void beginTransmission(int address)
		{ esp32If.GpioCommand(I2C_BEGIN_TRANSMISSION, busNum, address); }

		// uint8_t endTransmission(bool sendStop);
		// private const int I2C_END_TRANSMISSION_BOOL = 612;
		public int endTransmission(bool sendStop)
		{ return esp32If.GpioCommand(I2C_END_TRANSMISSION_BOOL, busNum, sendStop ? 1 : 0); }

		// uint8_t endTransmission(uint8_t sendStop);
		// private const int I2C_END_TRANSMISSION_BYTE = 613;
		public int endTransmission(int sendStop)
		{ return esp32If.GpioCommand(I2C_END_TRANSMISSION_BYTE, busNum, sendStop); }

		// uint8_t endTransmission(void);
		// private const int I2C_END_TRANSMISSION = 614;
		public int endTransmission()
		{ return esp32If.GpioCommand(I2C_END_TRANSMISSION, busNum, 0); }

		// uint8_t requestFrom(uint16_t address, uint8_t size, bool sendStop);
		// private const int I2C_REQUEST_FROM16_BOOL = 615;
		public int requestFrom(UInt16 address, int size, bool sendStop)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			bool sendStop
			*/

			exts[0].Contents = esp32If.IntToBytes(size);
			exts[1].Contents = esp32If.IntToBytes(sendStop ? 1 : 0);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM16_BOOL, busNum, address, exts);
		}

		// uint8_t requestFrom(uint16_t address, uint8_t size, uint8_t sendStop);
		// private const int I2C_REQUEST_FROM16_BYTE = 616;
		public int requestFrom(UInt16 address, int size, int sendStop)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			int sendStop
			*/

			exts[0].Contents = esp32If.IntToBytes(size);
			exts[1].Contents = esp32If.IntToBytes(sendStop);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM16_BYTE, busNum, address, exts);
		}

		// uint8_t requestFrom(uint16_t address, uint8_t size);
		// private const int I2C_REQUEST_FROM16 = 617;
		public int requestFrom(UInt16 address, int size)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			*/

			exts[0].Contents = esp32If.IntToBytes(size);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM16, busNum, address, exts);
		}

		// uint8_t requestFrom(uint8_t address, uint8_t size, uint8_t sendStop);
		// private const int I2C_REQUEST_FROM8_BYTE = 618;
		public int requestFrom(byte address, int size, int sendStop)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			int sendStop
			*/

			exts[0].Contents = esp32If.IntToBytes(size);
			exts[1].Contents = esp32If.IntToBytes(sendStop);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM8_BYTE, busNum, address, exts);
		}

		// uint8_t requestFrom(uint8_t address, uint8_t size);
		// private const int I2C_REQUEST_FROM8 = 619;
		public int requestFrom(byte address, int size)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			*/

			exts[0].Contents = esp32If.IntToBytes(size);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM8, busNum, address, exts);
		}

		// uint8_t requestFrom(int address, int size, int sendStop);
		// private const int I2C_REQUEST_FROM_INT = 620;
		public int requestFrom(int address, int size, int sendStop)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			int sendStop
			*/

			exts[0].Contents = esp32If.IntToBytes(size);
			exts[1].Contents = esp32If.IntToBytes(sendStop);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM_INT, busNum, address, exts);
		}

		// uint8_t requestFrom(int address, int size);
		// private const int I2C_REQUEST_FROM = 621;
		public int requestFrom(int address, int size)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=address
			## extension ##
			int size
			*/

			exts[0].Contents = esp32If.IntToBytes(size);

			return esp32If.GpioCommandExt(I2C_REQUEST_FROM, busNum, address, exts);
		}

		// size_t write(uint8_t data);
		// private const int I2C_WRITE = 622;
		public uint write(byte data)
		{ return (uint)esp32If.GpioCommand(I2C_WRITE, busNum, data); }

		// size_t write(const uint8_t* buff, size_t);
		// private const int I2C_WRITE_BYTES = 623;
		public uint write(byte[] buff)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=0
			## extension ##
			byte[] buff
			*/

			exts[0].Contents = buff;

			return (uint)esp32If.GpioCommandExt(I2C_WRITE_BYTES, busNum, 0, exts);
		}

		// int available(void);
		// private const int I2C_AVAILABLE = 624;
		public int available()
		{ return esp32If.GpioCommand(I2C_AVAILABLE, busNum, 0); }

		// int read(void);
		// private const int I2C_READ = 625;
		public int read()
		{ return esp32If.GpioCommand(I2C_READ, busNum, 0); }

		// int peek(void);
		// private const int I2C_PEEK = 626;
		public int peek()
		{ return esp32If.GpioCommand(I2C_PEEK, busNum, 0); }

		// void flush(void);
		// private const int I2C_FLUSH = 627;
		public void flush()
		{ esp32If.GpioCommand(I2C_FLUSH, busNum, 0); }

		// inline size_t write(const char* s)
		// private const int I2C_WRITE_TEXT = 628;
		public uint write(string s)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=busNum
			p2=0
			## extension ##
			char* s
			*/

			exts[0].Contents = System.Text.Encoding.UTF8.GetBytes(s + "\0"); /* include null byte */

			return (uint)esp32If.GpioCommandExt(I2C_WRITE_TEXT, busNum, 0, exts);
		}

		// inline size_t write(unsigned long n)
		// private const int I2C_WRITE_UINT32 = 629;
		public uint write(uint n)
		{ return (uint)esp32If.GpioCommand(I2C_WRITE_UINT32, busNum, (int)n); }

		// inline size_t write(long n)
		// private const int I2C_WRITE_INT32 = 630;
		public uint write(int n)
		{ return (uint)esp32If.GpioCommand(I2C_WRITE_INT32, busNum, n); }

		// inline size_t write(unsigned int n)
		// private const int I2C_WRITE_UINT16 = 631;
		public uint write(UInt16 n)
		{ return (uint)esp32If.GpioCommand(I2C_WRITE_UINT16, busNum, n); }

		// inline size_t write(int n)
		// private const int I2C_WRITE_INT16 = 632;
		public uint write(Int16 n)
		{ return (uint)esp32If.GpioCommand(I2C_WRITE_INT16, busNum, n); }

		// void onReceive(void (*)(int));

		// void onRequest(void (*)(void));

		// void dumpInts();
		// private const int I2C_DUMP_INTS = 635;
		public void dumpInts()
		{ esp32If.GpioCommand(I2C_DUMP_INTS, busNum, 0); }

		// void dumpI2C();
		// private const int I2C_DUMP_I2C = 636;
		public void dumpI2C()
		{ esp32If.GpioCommand(I2C_DUMP_I2C, busNum, 0); }
	}
}
