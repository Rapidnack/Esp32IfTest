using System;
using System.Collections.Generic;

namespace Rapidnack.Net.Esp32
{
	public class SPIClass : IDisposable
	{
		// esp32-hal-spi.h (SPI.h): 1200~

		public enum SPIBus
		{
			FSPI = 1,
			HSPI = 2,
			VSPI = 3
		}

		public enum SPIClockDiv
		{
			DIV2 = 0x00101001, //8 MHz
			DIV4 = 0x00241001, //4 MHz
			DIV8 = 0x004c1001, //2 MHz
			DIV16 = 0x009c1001, //1 MHz
			DIV32 = 0x013c1001, //500 KHz
			DIV64 = 0x027c1001, //250 KHz
			DIV128 = 0x04fc1001 //125 KHz
		}

		public enum SPIMode
		{
			MODE0 = 0,
			MODE1 = 1,
			MODE2 = 2,
			MODE3 = 3
		}

		public enum SPICS
		{
			CS0 = 0,
			CS1 = 1,
			CS2 = 2,
			CS_MASK_ALL = 0x7
		}

		public enum SPIBitOrder
		{
			LSBFIRST = 0,
			MSBFIRST = 1
		}

		// void begin(int8_t sck = -1, int8_t miso = -1, int8_t mosi = -1, int8_t ss = -1);
		private const int SPI_BEGIN = 1200;
		// void end();
		private const int SPI_END = 1201;
		// void setHwCs(bool use);
		private const int SPI_SET_HW_CS = 1202;
		// void setBitOrder(uint8_t bitOrder);
		private const int SPI_SET_BIT_ORDER = 1203;
		// void setDataMode(uint8_t dataMode);
		private const int SPI_SET_DATA_MODE = 1204;
		// void setFrequency(uint32_t freq);
		private const int SPI_SET_FREQUENCY = 1205;
		// void setClockDivider(uint32_t clockDiv);
		private const int SPI_SET_CLOCK_DIVIDER = 1206;
		// uint32_t getClockDivider();
		private const int SPI_GET_CLOCK_DIVIDER = 1207;
		// void beginTransaction(SPISettings settings);
		private const int SPI_BEGIN_TRANSACTION = 1208;
		// void endTransaction(void);
		private const int SPI_END_TRANSACTION = 1209;
		// uint8_t transfer(uint8_t data);
		private const int SPI_TRANSFER = 1210;
		// uint16_t transfer16(uint16_t data);
		private const int SPI_TRANSFER16 = 1211;
		// uint32_t transfer32(uint32_t data);
		private const int SPI_TRANSFER32 = 1212;
		// void transferBytes(uint8_t* data, uint8_t* out, uint32_t size);
		private const int SPI_TRANSFER_BYTES = 1213;
		// void transferBits(uint32_t data, uint32_t* out, uint8_t bits);
		private const int SPI_TRANSFER_BITS = 1214;
		// void write(uint8_t data);
		private const int SPI_WRITE = 1215;
		// void write16(uint16_t data);
		private const int SPI_WRITE16 = 1216;
		// void write32(uint32_t data);
		private const int SPI_WRITE32 = 1217;
		// void writeBytes(uint8_t* data, uint32_t size);
		private const int SPI_WRITE_BYTES = 1218;
		// void writePixels(const void* data, uint32_t size);//ili9341 compatible
		private const int SPI_WRITE_PIXELS = 1219;
		// void writePattern(uint8_t* data, uint8_t size, uint32_t repeat);
		private const int SPI_WRITE_PATTERN = 1220;

		private static List<SPIBus> inUse = new List<SPIBus>();
		private Esp32If esp32If;
		private SPIBus spiBus;


		public SPIClass(Esp32If esp32If, SPIBus spiBus = SPIBus.HSPI)
		{
			if ((int)spiBus < 1 || 3 < (int)spiBus)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (inUse.Contains(spiBus))
			{
				throw new ArgumentException("SPI bus already in use");
			}
			inUse.Add(spiBus);

			this.esp32If = esp32If;
			this.spiBus = spiBus;
		}

		public void Dispose()
		{
			inUse.Remove(spiBus);
		}


		// void begin(int8_t sck = -1, int8_t miso = -1, int8_t mosi = -1, int8_t ss = -1);
		// private const int SPI_BEGIN = 1200;
		public void begin(int sck = -1, int miso = -1, int mosi = -1, int ss = -1)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=spiBus
			p2=sck
			## extension ##
			int miso
			int mosi
			int ss
			*/

			exts[0].Contents = esp32If.IntToBytes(miso);
			exts[1].Contents = esp32If.IntToBytes(mosi);
			exts[2].Contents = esp32If.IntToBytes(ss);

			esp32If.GpioCommandExt(SPI_BEGIN, (int)spiBus, sck, exts);
		}

		// void end();
		// private const int SPI_END = 1201;
		public void end()
		{ esp32If.GpioCommand(SPI_END, (int)spiBus, 0); }

		// void setHwCs(bool use);
		// private const int SPI_SET_HW_CS = 1202;
		public void setHwCs(bool hwCs)
		{ esp32If.GpioCommand(SPI_SET_HW_CS, (int)spiBus, hwCs ? 1 : 0); }

		// void setBitOrder(uint8_t bitOrder);
		// private const int SPI_SET_BIT_ORDER = 1203;
		public void setBitOrder(SPIBitOrder bitOrder)
		{ esp32If.GpioCommand(SPI_SET_BIT_ORDER, (int)spiBus, (int)bitOrder); }

		// void setDataMode(uint8_t dataMode);
		// private const int SPI_SET_DATA_MODE = 1204;
		public void setDataMode(SPIMode mode)
		{ esp32If.GpioCommand(SPI_SET_DATA_MODE, (int)spiBus, (int)mode); }

		// void setFrequency(uint32_t freq);
		// private const int SPI_SET_FREQUENCY = 1205;
		public void setFrequency(uint frequency)
		{ esp32If.GpioCommand(SPI_SET_FREQUENCY, (int)spiBus, (int)frequency); }

		// void setClockDivider(uint32_t clockDiv);
		// private const int SPI_SET_CLOCK_DIVIDER = 1206;
		public void setClockDivider(uint clockDiv)
		{ esp32If.GpioCommand(SPI_SET_CLOCK_DIVIDER, (int)spiBus, (int)clockDiv); }

		// uint32_t getClockDivider();
		// private const int SPI_GET_CLOCK_DIVIDER = 1207;
		public uint getClockDivider()
		{ return (uint)esp32If.GpioCommand(SPI_GET_CLOCK_DIVIDER, (int)spiBus, 0); }

		// void beginTransaction(SPISettings settings);
		// private const int SPI_BEGIN_TRANSACTION = 1208;
		public void beginTransaction(
			uint clock = 1000000, SPIBitOrder bitOrder = SPIBitOrder.MSBFIRST, SPIMode dataMode = SPIMode.MODE0)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=spiBus
			p2=clock
			## extension ##
			int bitOrder
			int dataMode
			*/

			exts[0].Contents = esp32If.IntToBytes((int)bitOrder);
			exts[1].Contents = esp32If.IntToBytes((int)dataMode);

			esp32If.GpioCommandExt(SPI_BEGIN_TRANSACTION, (int)spiBus, (int)clock, exts);
		}

		// void endTransaction(void);
		// private const int SPI_END_TRANSACTION = 1209;
		public void endTransaction()
		{ esp32If.GpioCommand(SPI_END_TRANSACTION, (int)spiBus, 0); }

		// uint8_t transfer(uint8_t data);
		// private const int SPI_TRANSFER = 1210;
		public int transfer(int data)
		{ return esp32If.GpioCommand(SPI_TRANSFER, (int)spiBus, data); }

		// uint16_t transfer16(uint16_t data);
		// private const int SPI_TRANSFER16 = 1211;
		public int transfer16(int data)
		{ return esp32If.GpioCommand(SPI_TRANSFER16, (int)spiBus, data); }

		// uint32_t transfer32(uint32_t data);
		// private const int SPI_TRANSFER32 = 1212;
		public uint transfer32(uint data)
		{ return (uint)esp32If.GpioCommand(SPI_TRANSFER32, (int)spiBus, (int)data); }

		// void transferBytes(uint8_t* data, uint8_t* out, uint32_t size);
		// private const int SPI_TRANSFER_BYTES = 1213;
		public byte[] transferBytes(byte[] txBuf)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=spiBus
			p2=0
			## extension ##
			char buf[count]
			*/

			exts[0].Contents = txBuf;

			byte[] rxBuf;
			esp32If.GpioCommandExt(SPI_TRANSFER_BYTES, (int)spiBus, 0, exts, out rxBuf);

			return rxBuf;
		}

		// void transferBits(uint32_t data, uint32_t* out, uint8_t bits);
		// private const int SPI_TRANSFER_BITS = 1214;
		public uint transferBits(uint data, int bits)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=spiBus
			p2=data
			## extension ##
			int bits
			*/

			exts[0].Contents = esp32If.IntToBytes(bits);

			return (uint)esp32If.GpioCommandExt(SPI_TRANSFER_BITS, (int)spiBus, (int)data, exts);
		}

		// void write(uint8_t data);
		// private const int SPI_WRITE = 1215;
		public void write(int data)
		{ esp32If.GpioCommand(SPI_WRITE, (int)spiBus, data); }

		// void write16(uint16_t data);
		// private const int SPI_WRITE16 = 1216;
		public void write16(int data)
		{ esp32If.GpioCommand(SPI_WRITE16, (int)spiBus, data); }

		// void write32(uint32_t data);
		// private const int SPI_WRITE32 = 1217;
		public void write32(uint data)
		{ esp32If.GpioCommand(SPI_WRITE32, (int)spiBus, (int)data); }

		// void writeBytes(uint8_t* data, uint32_t size);
		// private const int SPI_WRITE_BYTES = 1218;
		public void writeBytes(byte[] data)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=spiBus
			p2=0
			## extension ##
			char buf[count]
			*/

			exts[0].Contents = data;

			esp32If.GpioCommandExt(SPI_WRITE_BYTES, (int)spiBus, 0, exts);
		}

		// void writePixels(const void* data, uint32_t size);//ili9341 compatible
		// private const int SPI_WRITE_PIXELS = 1219;
		public void writePixels(byte[] data)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=spiBus
			p2=0
			## extension ##
			char buf[count]
			*/

			exts[0].Contents = data;

			esp32If.GpioCommandExt(SPI_WRITE_PIXELS, (int)spiBus, 0, exts);
		}

		// void writePattern(uint8_t* data, uint8_t size, uint32_t repeat);
		// private const int SPI_WRITE_PATTERN = 1220;
		public void writePattern(byte[] data, uint repeat)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] { new Esp32If.GpioExtent() };

			/*
			p1=spiBus
			p2=repeat
			## extension ##
			char buf[count]
			*/

			exts[0].Contents = data;

			esp32If.GpioCommandExt(SPI_WRITE_PATTERN, (int)spiBus, (int)repeat, exts);
		}
	}
}
