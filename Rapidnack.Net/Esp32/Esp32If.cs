using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapidnack.Net.Esp32
{
	public class Esp32If : GpiodIf
	{
		// esp32-hal.h: 100~

		// float temperatureRead()
		private const int TEMPERATURE_READ = 100;
		// unsigned long micros();
		private const int MICROS = 101;
		// unsigned long millis();
		private const int MILLIS = 102;
		// void delay(uint32_t);
		private const int DELAY = 103;
		// void delayMicroseconds(uint32_t us);
		private const int DELAY_MICROSECONDS = 104;


		// esp32-hal-adc.h: 200~

		public enum AdcAttenuation
		{
			ADC_0db = 0,
			ADC_2_5db = 1,
			ADC_6db = 2,
			ADC_11db = 3
		}

		// uint16_t analogRead(uint8_t pin);
		private const int ANALOG_READ = 200;
		// void analogReadResolution(uint8_t bits);
		private const int ANALOG_READ_RESOLUTION = 201;
		// void analogSetWidth(uint8_t bits);
		private const int ANALOG_SET_WIDTH = 202;
		// void analogSetCycles(uint8_t cycles);
		private const int ANALOG_SET_CYCLES = 203;
		// void analogSetSamples(uint8_t samples);
		private const int ANALOG_SET_SAMPLES = 204;
		// void analogSetClockDiv(uint8_t clockDiv);
		private const int ANALOG_SET_CLOCK_DIV = 205;
		// void analogSetAttenuation(adc_attenuation_t attenuation);
		private const int ANALOG_SET_ATTENUATION = 206;
		// void analogSetPinAttenuation(uint8_t pin, adc_attenuation_t attenuation);
		private const int ANALOG_SET_PIN_ATTENUATION = 207;
		// int hallRead();
		private const int HALL_READ = 208;
		// bool adcAttachPin(uint8_t pin);
		private const int ADC_ATTACH_PIN = 209;
		// bool adcStart(uint8_t pin);
		private const int ADC_START = 210;
		// bool adcBusy(uint8_t pin);
		private const int ADC_BUSY = 211;
		// uint16_t adcEnd(uint8_t pin);
		private const int ADC_END = 212;


		// esp32-hal-bt.h: 300~


		// esp32-hal-dac.h: 400~

		// void dacWrite(uint8_t pin, uint8_t value);
		private const int DAC_WRITE = 400;


		// esp32-hal-gpio.h: 500~

		public const int LOW = 0;
		public const int HIGH = 1;

		//GPIO FUNCTIONS
		public enum GpioFunction
		{
			INPUT = 0x01,
			OUTPUT = 0x02,
			PULLUP = 0x04,
			INPUT_PULLUP = 0x05,
			PULLDOWN = 0x08,
			INPUT_PULLDOWN = 0x09,
			OPEN_DRAIN = 0x10,
			OUTPUT_OPEN_DRAIN = 0x12,
			SPECIAL = 0xF0,
			FUNCTION_1 = 0x00,
			FUNCTION_2 = 0x20,
			FUNCTION_3 = 0x40,
			FUNCTION_4 = 0x60,
			FUNCTION_5 = 0x80,
			FUNCTION_6 = 0xA0,
			ANALOG = 0xC0
		}

		//Interrupt Modes
		public enum InterruptMode
		{
			DISABLED = 0x00,
			RISING = 0x01,
			FALLING = 0x02,
			CHANGE = 0x03,
			ONLOW = 0x04,
			ONHIGH = 0x05,
			ONLOW_WE = 0x0C,
			ONHIGH_WE = 0x0D
		}

		// void pinMode(uint8_t pin, uint8_t mode);
		private const int PIN_MODE = 500;
		// void digitalWrite(uint8_t pin, uint8_t val);
		private const int DIGITAL_WRITE = 501;
		// int digitalRead(uint8_t pin);
		private const int DIGITAL_READ = 502;
		// void attachInterrupt(uint8_t pin, void (*)(void), int mode);
		private const int ATTACH_INTERRUPT = 503;
		// void attachInterruptArg(uint8_t pin, void (*)(void), void* arg, int mode);
		// void detachInterrupt(uint8_t pin);
		private const int DETACH_INTERRUPT = 505;


		// esp32-hal-i2c.h: 600~


		// esp32-hal-ledc.h: 700~

		public enum Note
		{
			NOTE_C, NOTE_Cs, NOTE_D, NOTE_Eb, NOTE_E, NOTE_F, NOTE_Fs, NOTE_G, NOTE_Gs, NOTE_A, NOTE_Bb, NOTE_B, NOTE_MAX
		}

		// double ledcSetup(uint8_t channel, double freq, uint8_t resolution_bits);
		private const int LEDC_SETUP = 700;
		// void ledcWrite(uint8_t channel, uint32_t duty);
		private const int LEDC_WRITE = 701;
		// double ledcWriteTone(uint8_t channel, double freq);
		private const int LEDC_WRITE_TONE = 702;
		// double ledcWriteNote(uint8_t channel, note_t note, uint8_t octave);
		private const int LEDC_WRITE_NOTE = 703;
		// uint32_t ledcRead(uint8_t channel);
		private const int LEDC_READ = 704;
		// double ledcReadFreq(uint8_t channel);
		private const int LEDC_READ_FREQ = 705;
		// void ledcAttachPin(uint8_t pin, uint8_t channel);
		private const int LEDC_ATTACH_PIN = 706;
		// void ledcDetachPin(uint8_t pin);
		private const int LEDC_DETACH_PIN = 707;


		// esp32-hal-log.h: 800~


		// esp32-hal-matrix.h: 900~


		// esp32-hal-psram.h: 1000~


		// esp32-hal-sigmadelta.h: 1100~

		// uint32_t sigmaDeltaSetup(uint8_t channel, uint32_t freq);
		private const int SIGMA_DELTA_SETUP = 1100;
		// void sigmaDeltaWrite(uint8_t channel, uint8_t duty);
		private const int SIGMA_DELTA_WRITE = 1101;
		// uint8_t sigmaDeltaRead(uint8_t channel);
		private const int SIGMA_DELTA_READ = 1102;
		// void sigmaDeltaAttachPin(uint8_t pin, uint8_t channel);
		private const int SIGMA_DELTA_ATTACH_PIN = 1103;
		// void sigmaDeltaDetachPin(uint8_t pin);
		private const int SIGMA_DELTA_DETACH_PIN = 1104;


		// esp32-hal-spi.h: 1200~


		// esp32-hal-timer.h: 1300~


		// esp32-hal-touch.h: 1400~

		// void touchSetCycles(uint16_t measure, uint16_t sleep);
		private const int TOUCH_SET_CYCLES = 1400;
		// uint16_t touchRead(uint8_t pin);
		private const int TOUCH_READ = 1401;
		// void touchAttachInterrupt(uint8_t pin, void (*userFunc)(void), uint16_t threshold);
		private const int TOUCH_ATTACH_INTERRUPT = 1402;


		// esp32-hal-uart.h: 1500~


		public TwoWire Wire;
		public TwoWire Wire1;
		public SPIClass SPI;
		public SPIClass SPI1;


		public Esp32If()
		{
			Wire = new TwoWire(this, 0);
			Wire1 = new TwoWire(this, 1);
			SPI = new SPIClass(this, SPIClass.SPIBus.VSPI);
			SPI1 = new SPIClass(this, SPIClass.SPIBus.HSPI);
		}


		// esp32-hal.h: 100~

		// float temperatureRead()
		// private const int TEMPERATURE_READ = 100;
		public double temperatureRead()
		{ return GpioCommand(TEMPERATURE_READ, 0, 0) / 10.0; }

		// unsigned long micros();
		// private const int MICROS = 101;
		public uint micros()
		{ return (uint)GpioCommand(MICROS, 0, 0); }

		// unsigned long millis();
		// private const int MILLIS = 102;
		public uint millis()
		{ return (uint)GpioCommand(MILLIS, 0, 0); }

		// void delay(uint32_t ms);
		// private const int DELAY = 103;
		public void delay(uint ms)
		{ GpioCommand(DELAY, (int)ms, 0); }

		// void delayMicroseconds(uint32_t us);
		// private const int DELAY_MICROSECONDS = 104;
		public void delayMicroseconds(uint us)
		{ GpioCommand(DELAY_MICROSECONDS, (int)us, 0); }


		// esp32-hal-adc.h: 200~

		// uint16_t analogRead(uint8_t pin);
		// private const int ANALOG_READ = 200;
		public int analogRead(int pin)
		{ return GpioCommand(ANALOG_READ, pin, 0); }

		// void analogReadResolution(uint8_t bits);
		// private const int ANALOG_READ_RESOLUTION = 201;
		public void analogReadResolution(int bits)
		{ GpioCommand(ANALOG_READ_RESOLUTION, bits, 0); }

		// void analogSetWidth(uint8_t bits);
		// private const int ANALOG_SET_WIDTH = 202;
		public void analogSetWidth(int bits)
		{ GpioCommand(ANALOG_SET_WIDTH, bits, 0); }

		// void analogSetCycles(uint8_t cycles);
		// private const int ANALOG_SET_CYCLES = 203;
		public void analogSetCycles(int cycles)
		{ GpioCommand(ANALOG_SET_CYCLES, cycles, 0); }

		// void analogSetSamples(uint8_t samples);
		// private const int ANALOG_SET_SAMPLES = 204;
		public void analogSetSamples(int samples)
		{ GpioCommand(ANALOG_SET_SAMPLES, samples, 0); }

		// void analogSetClockDiv(uint8_t clockDiv);
		// private const int ANALOG_SET_CLOCK_DIV = 205;
		public void analogSetClockDiv(int clockDiv)
		{ GpioCommand(ANALOG_SET_CLOCK_DIV, clockDiv, 0); }

		// void analogSetAttenuation(adc_attenuation_t attenuation);
		// private const int ANALOG_SET_ATTENUATION = 206;
		public void analogSetAttenuation(AdcAttenuation attenuation)
		{ GpioCommand(ANALOG_SET_ATTENUATION, (int)attenuation, 0); }

		// void analogSetPinAttenuation(uint8_t pin, adc_attenuation_t attenuation);
		// private const int ANALOG_SET_PIN_ATTENUATION = 207;
		public void analogSetPinAttenuation(int pin, AdcAttenuation adcAttenuation)
		{ GpioCommand(ANALOG_SET_PIN_ATTENUATION, pin, (int)adcAttenuation); }

		// int hallRead();
		// private const int HALL_READ = 208;
		public int hallRead()
		{ return GpioCommand(HALL_READ, 0, 0); }

		// bool adcAttachPin(uint8_t pin);
		// private const int ADC_ATTACH_PIN = 209;
		public bool adcAttachPin(int pin)
		{ return GpioCommand(ADC_ATTACH_PIN, pin, 0) != 0; }

		// bool adcStart(uint8_t pin);
		// private const int ADC_START = 210;
		public bool adcStart(int pin)
		{ return GpioCommand(ADC_START, pin, 0) != 0; }

		// bool adcBusy(uint8_t pin);
		// private const int ADC_BUSY = 211;
		public bool adcBusy(int pin)
		{ return GpioCommand(ADC_BUSY, pin, 0) != 0; }

		// uint16_t adcEnd(uint8_t pin);
		// private const int ADC_END = 212;
		public int adcEnd(int pin)
		{ return GpioCommand(ADC_END, pin, 0); }


		// esp32-hal-bt.h: 300~


		// esp32-hal-dac.h: 400~

		// void dacWrite(uint8_t pin, uint8_t value);
		// private const int DAC_WRITE = 400;
		public void dacWrite(int pin, int value)
		{ GpioCommand(DAC_WRITE, pin, value); }


		// esp32-hal-gpio.h: 500~

		// void pinMode(uint8_t pin, uint8_t mode);
		// private const int PIN_MODE = 500;
		public void pinMode(int pin, GpioFunction mode)
		{ GpioCommand(PIN_MODE, pin, (int)mode); }

		// void digitalWrite(uint8_t pin, uint8_t val);
		// private const int DIGITAL_WRITE = 501;
		public void digitalWrite(int pin, int val)
		{ GpioCommand(DIGITAL_WRITE, pin, val); }

		// int digitalRead(uint8_t pin);
		// private const int DIGITAL_READ = 502;
		public int digitalRead(int pin)
		{ return GpioCommand(DIGITAL_READ, pin, 0); }

		// void attachInterrupt(uint8_t pin, void (*)(void), int mode);
		// private const int ATTACH_INTERRUPT = 503;
		public void attachInterrupt(int pin, Action<int, UInt32> f, InterruptMode mode)
		{
			if (InternalCallback(pin, f) != 0)
				return;

			if (GpioCommand(ATTACH_INTERRUPT, pin, (int)mode) != 0)
			{
				InternalCallbackCancel(pin);
				return;
			}
		}

		// void attachInterruptArg(uint8_t pin, void (*)(void), void* arg, int mode);

		// void detachInterrupt(uint8_t pin);
		// private const int DETACH_INTERRUPT = 505;
		public void detachInterrupt(int pin)
		{
			if (GpioCommand(DETACH_INTERRUPT, pin, 0) != 0)
				return;

			InternalCallbackCancel(pin);
		}


		// esp32-hal-ledc.h: 700~

		// double ledcSetup(uint8_t channel, double freq, uint8_t resolution_bits);
		// private const int LEDC_SETUP = 700;
		public double ledcSetup(int channel, double freq, int resolution_bits)
		{
			GpioExtent[] exts = new GpioExtent[] { new GpioExtent() };

			/*
			p1=channel
			p2=freq
			## extension ##
			int resolution_bits
			*/

			exts[0].Contents = IntToBytes(resolution_bits);

			return (double)GpioCommandExt(LEDC_SETUP, channel, (int)Math.Round(freq), exts);
		}

		// void ledcWrite(uint8_t channel, uint32_t duty);
		// private const int LEDC_WRITE = 701;
		public void ledcWrite(int channel, int duty)
		{ GpioCommand(LEDC_WRITE, channel, duty); }

		// double ledcWriteTone(uint8_t channel, double freq);
		// private const int LEDC_WRITE_TONE = 702;
		public double ledcWriteTone(int channel, double freq)
		{ return (double)GpioCommand(LEDC_WRITE_TONE, channel, (int)Math.Round(freq)); }

		// double ledcWriteNote(uint8_t channel, note_t note, uint8_t octave);
		// private const int LEDC_WRITE_NOTE = 703;
		public double ledcWriteNote(int channel, Note note, int octave)
		{
			GpioExtent[] exts = new GpioExtent[] { new GpioExtent() };

			/*
			p1=channel
			p2=note
			## extension ##
			int octave
			*/

			exts[0].Contents = IntToBytes(octave);

			return (double)GpioCommandExt(LEDC_WRITE_NOTE, channel, (int)note, exts);
		}

		// uint32_t ledcRead(uint8_t channel);
		// private const int LEDC_READ = 704;
		public uint ledcRead(int channel)
		{ return (uint)GpioCommand(LEDC_READ, channel, 0); }

		// double ledcReadFreq(uint8_t channel);
		// private const int LEDC_READ_FREQ = 705;
		public double ledcReadFreq(int channel)
		{ return (double)GpioCommand(LEDC_READ_FREQ, channel, 0); }

		// void ledcAttachPin(uint8_t pin, uint8_t channel);
		// private const int LEDC_ATTACH_PIN = 706;
		public void ledcAttachPin(int pin, int channel)
		{ GpioCommand(LEDC_ATTACH_PIN, pin, channel); }

		// void ledcDetachPin(uint8_t pin);
		// private const int LEDC_DETACH_PIN = 707;
		public void ledcDetachPin(int pin)
		{ GpioCommand(LEDC_DETACH_PIN, pin, 0); }


		// esp32-hal-log.h: 800~


		// esp32-hal-matrix.h: 900~


		// esp32-hal-psram.h: 1000~


		// esp32-hal-sigmadelta.h: 1100~

		// uint32_t sigmaDeltaSetup(uint8_t channel, uint32_t freq);
		// private const int SIGMA_DELTA_SETUP = 1100;
		public uint sigmaDeltaSetup(int channel, uint freq)
		{ return (uint)GpioCommand(SIGMA_DELTA_SETUP, channel, (int)freq); }

		// void sigmaDeltaWrite(uint8_t channel, uint8_t duty);
		// private const int SIGMA_DELTA_WRITE = 1101;
		public void sigmaDeltaWrite(int channel, int duty)
		{ GpioCommand(SIGMA_DELTA_WRITE, channel, duty); }

		// uint8_t sigmaDeltaRead(uint8_t channel);
		// private const int SIGMA_DELTA_READ = 1102;
		public int sigmaDeltaRead(int channel)
		{ return GpioCommand(SIGMA_DELTA_READ, channel, 0); }

		// void sigmaDeltaAttachPin(uint8_t pin, uint8_t channel);
		// private const int SIGMA_DELTA_ATTACH_PIN = 1103;
		public void sigmaDeltaAttachPin(int pin, int channel)
		{ GpioCommand(SIGMA_DELTA_ATTACH_PIN, pin, channel); }

		// void sigmaDeltaDetachPin(uint8_t pin);
		// private const int SIGMA_DELTA_DETACH_PIN = 1104;
		public void sigmaDeltaDetachPin(int pin)
		{ GpioCommand(SIGMA_DELTA_DETACH_PIN, pin, 0); }


		// esp32-hal-timer.h: 1300~


		// esp32-hal-touch.h: 1400~

		// void touchSetCycles(uint16_t measure, uint16_t sleep);
		// private const int TOUCH_SET_CYCLES = 1400;
		public void touchSetCycles(int measure, int sleep)
		{ GpioCommand(TOUCH_SET_CYCLES, measure, sleep); }

		// uint16_t touchRead(uint8_t pin);
		// private const int TOUCH_READ = 1401;
		public int touchRead(int pin)
		{ return GpioCommand(TOUCH_READ, pin, 0); }

		// void touchAttachInterrupt(uint8_t pin, void (*userFunc)(void), uint16_t threshold);
		// private const int TOUCH_ATTACH_INTERRUPT = 1402;
		public void touchAttachInterrupt(int pin, Action<int, UInt32> f, int threshold)
		{
			if (GpioCommand(TOUCH_ATTACH_INTERRUPT, pin, threshold) != 0)
				return;

			InternalCallback(pin, f);
		}


		// esp32-hal-uart.h: 1500~
	}
}
