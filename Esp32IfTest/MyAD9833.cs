using Rapidnack.Net.Esp32;

namespace Esp32IfTest
{
	public class MyAD9833
	{
		public enum WaveformType
		{
			SINE_WAVE = 0x2000,
			TRIANGLE_WAVE = 0x2002,
			SQUARE_WAVE = 0x2028,
			HALF_SQUARE_WAVE = 0x2020
		}

		public enum Registers
		{
			REG0, REG1,
			SAME_AS_REG0
		}

		private const int AD9833_BASE = 20100;
		private const int AD9833_BEGIN = (AD9833_BASE + 0);
		private const int AD9833_APPLY_SIGNAL = (AD9833_BASE + 1);
		private const int AD9833_SET_FREQUENCY = (AD9833_BASE + 3);
		private const int AD9833_ENABLE_OUTPUT = (AD9833_BASE + 9);


		private Esp32If esp32If;


		public MyAD9833(Esp32If esp32If)
		{
			this.esp32If = esp32If;
		}


		// private const int AD9833_BEGIN = (AD9833_BASE + 0);
		public void Begin()
		{
			esp32If.GpioCommand(AD9833_BEGIN, 0, 0);
		}

		// private const int AD9833_APPLY_SIGNAL = (AD9833_BASE + 1);
		public void ApplySignal(WaveformType waveType, Registers freqReg,
			double frequencyInHz,
			Registers phaseReg = Registers.SAME_AS_REG0, double phaseInDeg = 0.0)
		{
			Esp32If.GpioExtent[] exts = new Esp32If.GpioExtent[] {
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent(),
				new Esp32If.GpioExtent()
			};

			/*
			p1=waveType
			p2=freqReg
			## extension ##
			double frequencyInHz
			Registers phaseReg
			double phaseInDeg
			*/

			exts[0].Contents = esp32If.IntToBytes((int)(frequencyInHz * 10));
			exts[1].Contents = esp32If.IntToBytes((int)phaseReg);
			exts[2].Contents = esp32If.IntToBytes((int)(phaseInDeg * 1000));

			esp32If.GpioCommandExt(AD9833_APPLY_SIGNAL, (int)waveType, (int)freqReg, exts);
		}

		// private const int AD9833_SET_FREQUENCY = (AD9833_BASE + 3);
		public void SetFrequency(Registers freqReg, double freqInHz)
		{
			esp32If.GpioCommand(AD9833_SET_FREQUENCY, (int)freqReg, (int)(freqInHz * 10));
		}

		// private const int AD9833_ENABLE_OUTPUT = (AD9833_BASE + 9);
		public void EnableOutput(bool enable)
		{
			esp32If.GpioCommand(AD9833_ENABLE_OUTPUT, enable ? 1 : 0, 0);
		}
	}
}
