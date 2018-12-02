using Rapidnack.Net.Esp32;

namespace Esp32IfTest
{
	public class MyADXL345
	{
		public enum range_t
		{
			ADXL345_RANGE_16_G = 0b11,   // +/- 16g
			ADXL345_RANGE_8_G = 0b10,   // +/- 8g
			ADXL345_RANGE_4_G = 0b01,   // +/- 4g
			ADXL345_RANGE_2_G = 0b00    // +/- 2g (default value)
		}


		private const int ADXL345_BASE = 20000;
		private const int ADXL345_BEGIN = (ADXL345_BASE + 0);
		private const int ADXL345_SET_RANGE = (ADXL345_BASE + 1);
		private const int ADXL345_GET_EVENT = (ADXL345_BASE + 2);


		private Esp32If esp32If;


		public MyADXL345(Esp32If esp32If)
		{
			this.esp32If = esp32If;
		}


		// private const int ADXL345_BEGIN = (ADXL345_BASE + 0);
		public int Begin()
		{
			return esp32If.GpioCommand(ADXL345_BEGIN, 0, 0);
		}

		// private const int ADXL345_SET_RANGE = (ADXL345_BASE + 1);
		public int SetRange(range_t range)
		{
			return esp32If.GpioCommand(ADXL345_SET_RANGE, (int)range, 0);
		}

		// private const int ADXL345_GET_EVENT = (ADXL345_BASE + 2);
		public double[] GetEvent()
		{
			byte[] rxBuf;
			esp32If.GpioCommand(ADXL345_GET_EVENT, 0, 0, out rxBuf);
			int[] ints = esp32If.BytesToIntArray(rxBuf);
			double[] doubles = new double[ints.Length];
			for (int i = 0; i < ints.Length; i++)
			{
				doubles[i] = (double)ints[i] / 100;
			}
			return doubles;
		}
	}
}
