namespace Rapidnack.Net.Esp32
{
	public class AD9833
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

		private const int AD9833_BASE = 20000;
		private const int AD9833_BEGIN = (AD9833_BASE + 0);
		private const int AD9833_APPLY_SIGNAL = (AD9833_BASE + 1);
		private const int AD9833_RESET = (AD9833_BASE + 2);
		private const int AD9833_SET_FREQUENCY = (AD9833_BASE + 3);
		private const int AD9833_INCREMENT_FREQUENCY = (AD9833_BASE + 4);
		private const int AD9833_SET_PHASE = (AD9833_BASE + 5);
		private const int AD9833_INCREMENT_PHASE = (AD9833_BASE + 6);
		private const int AD9833_SET_WAVEFORM = (AD9833_BASE + 7);
		private const int AD9833_SET_OUTPUT_SOURCE = (AD9833_BASE + 8);
		private const int AD9833_ENABLE_OUTPUT = (AD9833_BASE + 9);
		private const int AD9833_SLEEP_MODE = (AD9833_BASE + 10);
		private const int AD9833_DISABLE_DAC = (AD9833_BASE + 11);
		private const int AD9833_DISABLE_INTERNAL_CLOCK = (AD9833_BASE + 12);
		private const int AD9833_GET_ACTUAL_PROGRAMMED_FREQUENCY = (AD9833_BASE + 13);
		private const int AD9833_GET_ACTUAL_PROGRAMMED_PHASE = (AD9833_BASE + 14);
		private const int AD9833_GET_RESOLUTION = (AD9833_BASE + 15);


		private Esp32If esp32If;


		public AD9833(Esp32If esp32If)
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

		// private const int AD9833_RESET = (AD9833_BASE + 2);
		public void Reset()
		{
			esp32If.GpioCommand(AD9833_RESET, 0, 0);
		}

		// private const int AD9833_SET_FREQUENCY = (AD9833_BASE + 3);
		public void SetFrequency(Registers freqReg, double freqInHz)
		{
			esp32If.GpioCommand(AD9833_SET_FREQUENCY, (int)freqReg, (int)(freqInHz * 10));
		}

		// private const int AD9833_INCREMENT_FREQUENCY = (AD9833_BASE + 4);
		public void IncrementFrequency(Registers freqReg, double freqInHz)
		{
			esp32If.GpioCommand(AD9833_INCREMENT_FREQUENCY, (int)freqReg, (int)(freqInHz * 10));
		}

		// private const int AD9833_SET_PHASE = (AD9833_BASE + 5);
		public void SetPhase(Registers phaseReg, double phaseInDeg)
		{
			esp32If.GpioCommand(AD9833_SET_PHASE, (int)phaseReg, (int)(phaseInDeg * 1000));
		}

		// private const int AD9833_INCREMENT_PHASE = (AD9833_BASE + 6);
		public void IncrementPhase(Registers phaseReg, double phaseInDeg)
		{
			esp32If.GpioCommand(AD9833_INCREMENT_PHASE, (int)phaseReg, (int)(phaseInDeg * 1000));
		}

		// private const int AD9833_SET_WAVEFORM = (AD9833_BASE + 7);
		public void SetWaveform(Registers waveFormReg, WaveformType waveType)
		{
			esp32If.GpioCommand(AD9833_SET_WAVEFORM, (int)waveFormReg, (int)waveType);
		}

		// private const int AD9833_SET_OUTPUT_SOURCE = (AD9833_BASE + 8);
		public void SetOutputSource(Registers freqReg, Registers phaseReg = Registers.SAME_AS_REG0)
		{
			esp32If.GpioCommand(AD9833_SET_OUTPUT_SOURCE, (int)freqReg, (int)phaseReg);
		}

		// private const int AD9833_ENABLE_OUTPUT = (AD9833_BASE + 9);
		public void EnableOutput(bool enable)
		{
			esp32If.GpioCommand(AD9833_ENABLE_OUTPUT, enable ? 1 : 0, 0);
		}

		// private const int AD9833_SLEEP_MODE = (AD9833_BASE + 10);
		public void SleepMode(bool enable)
		{
			esp32If.GpioCommand(AD9833_SLEEP_MODE, enable ? 1 : 0, 0);
		}

		// private const int AD9833_DISABLE_DAC = (AD9833_BASE + 11);
		public void DisableDAC(bool enable)
		{
			esp32If.GpioCommand(AD9833_DISABLE_DAC, enable ? 1 : 0, 0);
		}

		// private const int AD9833_DISABLE_INTERNAL_CLOCK = (AD9833_BASE + 12);
		public void DisableInternalClock(bool enable)
		{
			esp32If.GpioCommand(AD9833_DISABLE_INTERNAL_CLOCK, enable ? 1 : 0, 0);
		}

		// private const int AD9833_GET_ACTUAL_PROGRAMMED_FREQUENCY = (AD9833_BASE + 13);
		public double GetActualProgrammedFrequency(Registers reg)
		{
			return (double)esp32If.GpioCommand(AD9833_GET_ACTUAL_PROGRAMMED_FREQUENCY, (int)reg, 0) / 10;
		}

		// private const int AD9833_GET_ACTUAL_PROGRAMMED_PHASE = (AD9833_BASE + 14);
		public double GetActualProgrammedPhase(Registers reg)
		{
			return (double)esp32If.GpioCommand(AD9833_GET_ACTUAL_PROGRAMMED_PHASE, (int)reg, 0) / 1000;
		}

		// private const int AD9833_GET_RESOLUTION = (AD9833_BASE + 15);
		public double GetResolution()
		{
			return (double)esp32If.GpioCommand(AD9833_GET_RESOLUTION, 0, 0) / 1000;
		}
	}
}
