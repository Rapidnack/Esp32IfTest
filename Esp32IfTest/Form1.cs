using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Rapidnack.Net;
using Rapidnack.Net.Esp32;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esp32IfTest
{
	public partial class Form1 : Form
	{
		private const int LED_PIN = 16;
		private const int INTERRUPT_PIN = 4;
		private const int ROLL_ADC_PIN = 39;
		private const int FAST_ADC_PIN = 36;
		private const int SERVO_1_PIN = 27;
		private const int SERVO_1_CH = 0;
		private const int SERVO_2_PIN = 17;
		private const int SERVO_2_CH = 1;

		private Esp32If esp32If;
		private MyAD9833 ad9833;
		private MyADXL345 adxl345;
		private MyOLEDDisplay oledDisplay;

		private CancellationTokenSource ledCts;
		private CancellationTokenSource rollCts;
		private CancellationTokenSource rollMultiCts;
		private CancellationTokenSource fastCts;
		private CancellationTokenSource i2cCts;
		private CancellationTokenSource i2cLibCts;
		private CancellationTokenSource spiCts;
		private CancellationTokenSource spiLibCts;

		private bool repeatRequested;

		public Form1()
		{
			InitializeComponent();
		}

		private void CloseConnection()
		{
			if (ledCts != null)
			{
				ledCts.Cancel();
				while (ledCts != null)
				{
					Application.DoEvents();
				}
			}
			if (rollCts != null)
			{
				rollCts.Cancel();
				while (rollCts != null)
				{
					Application.DoEvents();
				}
			}
			if (rollMultiCts != null)
			{
				rollMultiCts.Cancel();
				while (rollMultiCts != null)
				{
					Application.DoEvents();
				}
			}
			if (fastCts != null)
			{
				fastCts.Cancel();
				while (fastCts != null)
				{
					Application.DoEvents();
				}
			}
			if (i2cCts != null)
			{
				i2cCts.Cancel();
				while (i2cCts != null)
				{
					Application.DoEvents();
				}
			}
			if (i2cLibCts != null)
			{
				i2cLibCts.Cancel();
				while (i2cLibCts != null)
				{
					Application.DoEvents();
				}
			}
			if (spiCts != null)
			{
				spiCts.Cancel();
				while (spiCts != null)
				{
					Application.DoEvents();
				}
			}
			if (spiLibCts != null)
			{
				spiLibCts.Cancel();
				while (spiLibCts != null)
				{
					Application.DoEvents();
				}
			}

			esp32If.GpioStop();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			esp32If = new Esp32If();
			ad9833 = new MyAD9833(esp32If);
			adxl345 = new MyADXL345(esp32If);
			oledDisplay = new MyOLEDDisplay(esp32If);

			esp32If.StreamConnected += (s, evt) =>
			{
				Invoke(new Action(() =>
				{
					panelOperation.Enabled = true;
				}));

				oledDisplay.drawString(0, 48, "Connected");
				oledDisplay.display();

				esp32If.ledcSetup(SERVO_1_CH, 50, 16);
				esp32If.ledcAttachPin(SERVO_1_PIN, SERVO_1_CH);
				esp32If.ledcSetup(SERVO_2_CH, 50, 16);
				esp32If.ledcAttachPin(SERVO_2_PIN, SERVO_2_CH);

			};

			panelOperation.Enabled = false;
			buttonClose.Enabled = false;

			buttonLedStop.Enabled = false;
			buttonTouchStop.Enabled = false;
			buttonRollStop.Enabled = false;
			buttonRollMultiStop.Enabled = false;
			buttonFastStop.Enabled = false;
			buttonI2cStop.Enabled = false;
			buttonI2cLibStop.Enabled = false;
			buttonSpiStop.Enabled = false;
			buttonSpiLibStop.Enabled = false;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseConnection();
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			esp32If.GpioStart(textBoxAddress.Text, "8888");

			buttonOpen.Enabled = false;
			buttonClose.Enabled = true;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			CloseConnection();

			panelOperation.Enabled = false;
			buttonOpen.Enabled = true;
			buttonClose.Enabled = false;
		}

		private async void buttonLedStart_Click(object sender, EventArgs e)
		{
			buttonLedStart.Enabled = false;
			buttonLedStop.Enabled = true;

			try
			{
				ledCts = new CancellationTokenSource();
				var ct = ledCts.Token;

				try
				{
					esp32If.attachInterrupt(INTERRUPT_PIN, (gpio, millis) =>
					{
						Console.WriteLine($"{gpio}, {esp32If.digitalRead(gpio)}, {millis}");
					}, Esp32If.InterruptMode.CHANGE);

					await Task.Run(async () =>
					{
						esp32If.pinMode(LED_PIN, Esp32If.GpioFunction.OUTPUT);

						while (!ct.IsCancellationRequested)
						{
							esp32If.digitalWrite(LED_PIN, Esp32If.HIGH);
							await Task.Delay(500, ct);
							esp32If.digitalWrite(LED_PIN, Esp32If.LOW);
							await Task.Delay(500, ct);
						}
					}, ct);
				}
				finally
				{
					esp32If.detachInterrupt(INTERRUPT_PIN);
				}
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				ledCts = null;

				buttonLedStart.Enabled = true;
				buttonLedStop.Enabled = false;
			}
		}

		private void buttonLedStop_Click(object sender, EventArgs e)
		{
			ledCts.Cancel();
		}

		private void buttonTouchStart_Click(object sender, EventArgs e)
		{
			buttonTouchStart.Enabled = false;
			buttonTouchStop.Enabled = true;

			esp32If.touchAttachInterrupt(12, (gpio, millis) =>
			{
				Console.WriteLine($"{gpio}, {esp32If.touchRead(gpio)}, {millis}");
			}, 30);
			esp32If.touchAttachInterrupt(13, (gpio, millis) =>
			{
				Console.WriteLine($"{gpio}, {esp32If.touchRead(gpio)}, {millis}");
			}, 30);
			esp32If.touchAttachInterrupt(14, (gpio, millis) =>
			{
				Console.WriteLine($"{gpio}, {esp32If.touchRead(gpio)}, {millis}");
			}, 30);
			esp32If.touchAttachInterrupt(15, (gpio, millis) =>
			{
				Console.WriteLine($"{gpio}, {esp32If.touchRead(gpio)}, {millis}");
			}, 30);
		}

		private void buttonTouchStop_Click(object sender, EventArgs e)
		{
			buttonTouchStart.Enabled = true;
			buttonTouchStop.Enabled = false;

			esp32If.detachInterrupt(12);
			esp32If.detachInterrupt(13);
			esp32If.detachInterrupt(14);
			esp32If.detachInterrupt(15);
		}

		private async void buttonRollStart_Click(object sender, EventArgs e)
		{
			buttonRollStart.Enabled = false;
			buttonRollStop.Enabled = true;

			double ADC_SCALE = 3.3;
			int NUM_SAMPLES = 200;

			PlotModel plotModel = new PlotModel();
			LineSeries lineSeries = new LineSeries() { Title = "ADC3" };
			LinearAxis linearAxis = new LinearAxis() { Position = AxisPosition.Left, Minimum = 0 - 0.1, Maximum = ADC_SCALE + 0.1 };
			plotModel.Series.Add(lineSeries);
			plotModel.Axes.Add(linearAxis);
			plotView1.Model = plotModel;

			try
			{
				rollCts = new CancellationTokenSource();
				var ct = rollCts.Token;
				await Task.Run(() =>
				{
					esp32If.analogSetPinAttenuation(ROLL_ADC_PIN, Esp32If.AdcAttenuation.ADC_11db);

					lineSeries.Points.Clear();
					DateTime start = DateTime.Now;

					while (!ct.IsCancellationRequested)
					{
						TimeSpan ts = DateTime.Now - start;
						double volt = ADC_SCALE * esp32If.analogRead(ROLL_ADC_PIN) / 4096.0;
						DataPoint dataPoint = new DataPoint(ts.TotalSeconds, volt);

						if (ct.IsCancellationRequested)
							break;

						Console.WriteLine("{0}", volt.ToString("0.0"));

						Invoke(new Action(() =>
						{
							if (lineSeries.Points.Count >= NUM_SAMPLES)
							{
								lineSeries.Points.RemoveAt(0);
							}
							lineSeries.Points.Add(dataPoint);

							plotModel.InvalidatePlot(true);
							plotView1.Invalidate();
						}));
					}
				}, ct);
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				rollCts = null;

				buttonRollStart.Enabled = true;
				buttonRollStop.Enabled = false;
			}
		}

		private void buttonRollStop_Click(object sender, EventArgs e)
		{
			rollCts.Cancel();
		}

		private const int ANALOG_READ_4 = 10000;
		public int[] analogRead4()
		{
			byte[] rxBuf;
			esp32If.GpioCommand(ANALOG_READ_4, 0, 0, out rxBuf);
			return esp32If.BytesToIntArray(rxBuf);
		}

		private async void buttonRollMultiStart_Click(object sender, EventArgs e)
		{
			buttonRollMultiStart.Enabled = false;
			buttonRollMultiStop.Enabled = true;

			double ADC_SCALE = 3.6;
			int[] adcPins = { 32, 33, 34, 35 };
			int[] adcCHs = { 4, 5, 6, 7 };
			int NUM_CHANNELS = 4;
			int NUM_SAMPLES = 200;

			PlotModel plotModel = new PlotModel();
			LineSeries[] lineSeries = new LineSeries[NUM_CHANNELS];
			for (int ch = 0; ch < NUM_CHANNELS; ch++)
			{
				lineSeries[ch] = new LineSeries();
				lineSeries[ch].Title = string.Format("ADC{0}", adcCHs[ch]);
				plotModel.Series.Add(lineSeries[ch]);
			}
			plotModel.Axes.Add(
				new LinearAxis() { Position = AxisPosition.Left, Minimum = 0 - 0.1, Maximum = ADC_SCALE + 0.1 }
			);
			plotView1.Model = plotModel;

			try
			{
				rollMultiCts = new CancellationTokenSource();
				var ct = rollMultiCts.Token;
				await Task.Run(() =>
				{
					for (int ch = 0; ch < NUM_CHANNELS; ch++)
					{
						esp32If.analogSetPinAttenuation(adcPins[ch], Esp32If.AdcAttenuation.ADC_11db);
					}

					for (int ch = 0; ch < NUM_CHANNELS; ch++)
					{
						lineSeries[ch].Points.Clear();
					}
					DateTime start = DateTime.Now;

					while (!ct.IsCancellationRequested)
					{
						double[] volts = new double[NUM_CHANNELS];
						DataPoint[] dataPoints = new DataPoint[NUM_CHANNELS];

						int[] ints = analogRead4();
						if (ints.Length != NUM_CHANNELS * 2)
							break;

						TimeSpan ts = DateTime.Now - start;
						for (int ch = 0; ch < NUM_CHANNELS; ch++)
						{
							double volt = ADC_SCALE * ints[ch * 2] / 4096.0;
							volts[ch] = volt;
							dataPoints[ch] = new DataPoint(ts.TotalSeconds, volt);
						}

						if (ct.IsCancellationRequested)
							break;

						//string s = volts[0].ToString("0.0");
						//for (int ch = 1; ch < NUM_CHANNELS; ch++)
						//{
						//	s += string.Format(", {0:0.0}", volts[ch]);
						//}
						//Console.WriteLine("{0}", s);

						Invoke(new Action(() =>
						{
							for (int ch = 0; ch < NUM_CHANNELS; ch++)
							{
								if (lineSeries[ch].Points.Count >= NUM_SAMPLES)
								{
									lineSeries[ch].Points.RemoveAt(0);
								}
								lineSeries[ch].Points.Add(dataPoints[ch]);
							}

							plotModel.InvalidatePlot(true);
							plotView1.Invalidate();
						}));
					}
				}, ct);
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				rollMultiCts = null;

				buttonRollMultiStart.Enabled = true;
				buttonRollMultiStop.Enabled = false;
			}
		}

		private void buttonRollMultiStop_Click(object sender, EventArgs e)
		{
			rollMultiCts.Cancel();
		}

		private void trackBarDac1_Scroll(object sender, EventArgs e)
		{
			esp32If.dacWrite(25, trackBarDac1.Value);
		}

		private void trackBarDac2_Scroll(object sender, EventArgs e)
		{
			esp32If.dacWrite(26, trackBarDac2.Value);
		}

		private const int ANALOG_FAST_READ = 10001;
		public int[] analogFastRead(int pin, int samples)
		{
			byte[] rxBuf;
			esp32If.GpioCommand(ANALOG_FAST_READ, pin, samples, out rxBuf);
			return esp32If.BytesToIntArray(rxBuf);
		}

		private async void buttonFastStart_Click(object sender, EventArgs e)
		{
			do
			{
				repeatRequested = false;

				buttonFastStart.Enabled = false;
				buttonFastStop.Enabled = true;

				double ADC_SCALE;
				Esp32If.AdcAttenuation att;
				if (radioButton1v.Checked)
				{
					ADC_SCALE = 1.1;
					att = Esp32If.AdcAttenuation.ADC_0db;
				}
				else
				{
					ADC_SCALE = 3.3;
					att = Esp32If.AdcAttenuation.ADC_11db;
				}
				int NUM_SAMPLES = 200;

				PlotModel plotModel = new PlotModel();
				LineSeries lineSeries = new LineSeries() { Title = "ADC0" };
				LinearAxis linearAxis = new LinearAxis() { Position = AxisPosition.Left, Minimum = 0 - 0.1, Maximum = ADC_SCALE + 0.1 };
				plotModel.Series.Add(lineSeries);
				plotModel.Axes.Add(linearAxis);
				plotView1.Model = plotModel;

				try
				{
					fastCts = new CancellationTokenSource();
					var ct = fastCts.Token;
					await Task.Run(() =>
					{
						esp32If.analogSetPinAttenuation(FAST_ADC_PIN, att);

						lineSeries.Points.Clear();

						while (!ct.IsCancellationRequested)
						{
							int[] ints = analogFastRead(FAST_ADC_PIN, NUM_SAMPLES);
							if (ints.Length != 2 * NUM_SAMPLES)
								return;

							DataPoint[] dataPoints = new DataPoint[NUM_SAMPLES];
							for (int i = 0; i < NUM_SAMPLES; i++)
							{
								double volt = ADC_SCALE * ints[2 * i] / 4096.0;
								double seconds = (uint)(ints[2 * i + 1] - ints[1]) / 1e6;
								dataPoints[i] = new DataPoint(seconds, volt);
								//Console.WriteLine($"{i}: {seconds}, {volt}");
							}

							if (ct.IsCancellationRequested)
								break;

							Invoke(new Action(() =>
							{
								lineSeries.Points.Clear();
								lineSeries.Points.AddRange(dataPoints);

								plotModel.InvalidatePlot(true);
								plotView1.Invalidate();
							}));
						}
					}, ct);
				}
				catch (OperationCanceledException)
				{
					// nothing to do
				}
				catch (GpiodIfException ex)
				{
					Console.WriteLine(ex.Message);
				}
				finally
				{
					fastCts = null;

					buttonFastStart.Enabled = true;
					buttonFastStop.Enabled = false;
				}
			} while (repeatRequested);
		}

		private void buttonFastStop_Click(object sender, EventArgs e)
		{
			fastCts.Cancel();
		}

		private void radioButton1v_CheckedChanged(object sender, EventArgs e)
		{
			if (fastCts == null)
				return;

			repeatRequested = true;
			fastCts.Cancel();
		}

		private void trackBarServo1_Scroll(object sender, EventArgs e)
		{
			int duty = (0x0000ffff * trackBarServo1.Value) / 20000;
			esp32If.ledcWrite(SERVO_1_CH, duty);
		}

		private void trackBarServo2_Scroll(object sender, EventArgs e)
		{
			int duty = (0x0000ffff * trackBarServo2.Value) / 20000;
			esp32If.ledcWrite(SERVO_2_CH, duty);
		}

		private void writeI2c(byte device_addr, byte register_addr, byte value)
		{
			esp32If.Wire.beginTransmission(device_addr);
			esp32If.Wire.write(register_addr);
			esp32If.Wire.write(value);
			esp32If.Wire.endTransmission();
		}

		private byte[] readI2c(byte device_addr, byte register_addr, int num)
		{
			byte[] buffer = new byte[num];

			esp32If.Wire.beginTransmission(device_addr);
			esp32If.Wire.write(register_addr);
			esp32If.Wire.endTransmission();

			esp32If.Wire.beginTransmission(device_addr);
			esp32If.Wire.requestFrom(device_addr, num);

			int i = 0;
			while (esp32If.Wire.available() != 0)
			{
				buffer[i++] = (byte)esp32If.Wire.read();
			}
			esp32If.Wire.endTransmission();

			return buffer;
		}

		private async void buttonI2cStart_Click(object sender, EventArgs e)
		{
			buttonI2cStart.Enabled = false;
			buttonI2cStop.Enabled = true;

			byte DEVICE_ADDR = 0x53;

			try
			{
				i2cCts = new CancellationTokenSource();
				var ct = i2cCts.Token;
				await Task.Run(async () =>
				{					
					writeI2c(DEVICE_ADDR, 0x31, 0x00); // DATA_FORMAT
					writeI2c(DEVICE_ADDR, 0x2d, 0x08); // POWER_TCL

					while (!ct.IsCancellationRequested)
					{
						byte[] axis_buff = readI2c(DEVICE_ADDR, 0x32, 6);
						int x = (axis_buff[1] << 8) + axis_buff[0];
						int y = (axis_buff[3] << 8) + axis_buff[2];
						int z = (axis_buff[5] << 8) + axis_buff[4];
						if (x > 0x8000) x -= 0x10000;
						if (y > 0x8000) y -= 0x10000;
						if (z > 0x8000) z -= 0x10000;

						if (ct.IsCancellationRequested)
							break;

						Console.WriteLine($"x: {x} y: {y} z: {z}");
						await Task.Delay(100, ct);
					}
				}, ct);
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				i2cCts = null;

				buttonI2cStart.Enabled = true;
				buttonI2cStop.Enabled = false;
			}
		}

		private void buttonI2cStop_Click(object sender, EventArgs e)
		{
			i2cCts.Cancel();
		}

		private async void buttonI2cLibStart_Click(object sender, EventArgs e)
		{
			buttonI2cLibStart.Enabled = false;
			buttonI2cLibStop.Enabled = true;

			try
			{
				i2cLibCts = new CancellationTokenSource();
				var ct = i2cLibCts.Token;
				await Task.Run(async () =>
				{
					if (adxl345.Begin() == 0)
					{
						/* There was a problem detecting the ADXL345 ... check your connections */
						Console.WriteLine("Ooops, no ADXL345 detected ... Check your wiring!");
						return;
					}
					adxl345.SetRange(MyADXL345.range_t.ADXL345_RANGE_16_G);

					while (!ct.IsCancellationRequested)
					{
						double[] xyz = adxl345.GetEvent();

						if (ct.IsCancellationRequested)
							break;

						Console.WriteLine($"x: {xyz[0]} y: {xyz[1]} z: {xyz[2]}");
						await Task.Delay(100, ct);
					}
				}, ct);
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				i2cLibCts = null;

				buttonI2cLibStart.Enabled = true;
				buttonI2cLibStop.Enabled = false;
			}
		}

		private void buttonI2cLibStop_Click(object sender, EventArgs e)
		{
			i2cLibCts.Cancel();
		}

		private void WriteRegister(ushort data)
		{
			esp32If.digitalWrite(5, Esp32If.LOW);

			byte[] bytes = new byte[2];
			bytes[0] = (byte)((data >> 8) & 0xff);
			bytes[1] = (byte)(data & 0xff);
			esp32If.SPI.transferBytes(bytes);

			esp32If.digitalWrite(5, Esp32If.HIGH);
		}

		private ushort[] GetFrequencyData(double frequency)
		{
			ushort[] data = new ushort[2];
			uint freqData = (uint)((frequency * Math.Pow(2, 28)) / 25e6);
			data[0] = (ushort)((freqData & 0x3fff) | 0x4000);
			data[1] = (ushort)(((freqData >> 14) & 0x3fff) | 0x4000);
			return data;
		}

		private async void buttonSpiStart_Click(object sender, EventArgs e)
		{
			buttonSpiStart.Enabled = false;
			buttonSpiStop.Enabled = true;

			try
			{
				spiCts = new CancellationTokenSource();
				var ct = spiCts.Token;
				await Task.Run(async () =>
				{
					double freq = 1000;
					bool up = true;

					esp32If.SPI.begin();
					esp32If.SPI.setDataMode(SPIClass.SPIMode.MODE2);
					esp32If.SPI.setFrequency(1000000);
					esp32If.pinMode(5, Esp32If.GpioFunction.OUTPUT);

					WriteRegister(0x0100);
					await Task.Delay(100, ct);

					WriteRegister(0x2000);
					ushort[] data = GetFrequencyData(freq);
					WriteRegister(data[0]);
					WriteRegister(data[1]);
					WriteRegister(0xc000);

					while (!ct.IsCancellationRequested)
					{
						WriteRegister(0x2000);
						data = GetFrequencyData(freq);
						WriteRegister(data[0]);
						WriteRegister(data[1]);

						if (up)
						{
							freq *= 1.1;
							if (freq > 10e3)
							{
								up = false;
							}
						}
						else
						{
							freq /= 1.1;
							if (freq < 1000)
							{
								up = true;
							}
						}

						if (ct.IsCancellationRequested)
							break;

						await Task.Delay(100, ct);
					}
				}, ct);
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				spiCts = null;

				buttonSpiStart.Enabled = true;
				buttonSpiStop.Enabled = false;
			}
		}

		private void buttonSpiStop_Click(object sender, EventArgs e)
		{
			spiCts.Cancel();
		}

		private async void buttonSpiLibStart_Click(object sender, EventArgs e)
		{
			buttonSpiLibStart.Enabled = false;
			buttonSpiLibStop.Enabled = true;

			try
			{
				spiLibCts = new CancellationTokenSource();
				var ct = spiLibCts.Token;
				await Task.Run(async () =>
				{
					double freq = 1000;
					bool up = true;

					ad9833.Begin();
					ad9833.ApplySignal(MyAD9833.WaveformType.TRIANGLE_WAVE, MyAD9833.Registers.REG0, freq);
					ad9833.EnableOutput(true);

					while (!ct.IsCancellationRequested)
					{
						ad9833.SetFrequency(MyAD9833.Registers.REG0, freq);
						if (up)
						{
							freq *= 1.1;
							if (freq > 10e3)
							{
								up = false;
							}
						}
						else
						{
							freq /= 1.1;
							if (freq < 1000)
							{
								up = true;
							}
						}

						if (ct.IsCancellationRequested)
							break;

						await Task.Delay(100, ct);
					}
				}, ct);
			}
			catch (OperationCanceledException)
			{
				// nothing to do
			}
			catch (GpiodIfException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				spiLibCts = null;

				buttonSpiLibStart.Enabled = true;
				buttonSpiLibStop.Enabled = false;
			}
		}

		private void buttonSpiLibStop_Click(object sender, EventArgs e)
		{
			spiLibCts.Cancel();
		}
	}
}
