# Esp32IfTest

Esp32IfTestプロジェクトは、C#ライブラリEsp32Ifと、そのサンプルアプリケーションEsp32IfTestを含んでいます。

C#ライブラリEsp32Ifは、別プロジェクト[RemoteEsp32 Library](https://github.com/Rapidnack/RemoteEsp32)のArduinoライブラリと組み合わせることで、
[Arduino core for the ESP32](https://github.com/espressif/arduino-esp32)のほとんどの関数をC#から実行することができます。
![Esp32If and RemoteEsp32](http://rapidack.sakura.ne.jp/ttl/wp-content/uploads/2018/12/RemoteEsp32_fig1c.png)

サンプルアプリケーションEsp32IfTestは、C#ライブラリEsp32Ifを使ったWindows.Formsアプリケーションです。ESP32のADC、DAC、LEDC、Touch、I2C、SPIをC#から操作しています。ESP32には別プロジェクトのArduinoライブラリ[RemoteEsp32 Library](https://github.com/Rapidnack/RemoteEsp32)のサンプルスケッチEsp32ServerTestSTA.inoを書き込みます。
![Esp32IfTest and Esp32ServerTestSTA](http://rapidack.sakura.ne.jp/ttl/wp-content/uploads/2018/12/RemoteEsp32_fig2c.png)

![Esp32IfTest screen](http://rapidack.sakura.ne.jp/ttl/wp-content/uploads/2018/12/Esp32IfTest1.png)

![Esp32IfTest bread board](http://rapidack.sakura.ne.jp/ttl/wp-content/uploads/2018/12/IMG_20181206_195958b.png)

# Dependency

- Microsoft Visual Studio Community 2017
- .NET Framework 4.6.1

# Usage

#### ESP32の準備

1. 最新の[Arduino IDE](https://www.arduino.cc/en/main/software)をダウンロードしてインストールします。

2. [Arduino core for the ESP32](https://github.com/espressif/arduino-esp32)のインストール手順に従ってライブラリマネージャに追加してインストールします。

3. ESP8266 and ESP32 Oled Driver for SSD1306 displayをライブラリマネージャで検索してインストールします。

4. Adafruit Unified sensorをライブラリマネージャで検索してインストールします。

5. Adafruit ADXL345をライブラリマネージャで検索してインストールします。

6. [AD9833 Library](https://github.com/Billwilliams1952/AD9833-Library-Arduino)をZIPファイルを保存し、Sketch > Include Library > Add .ZIP Libraryでインストールします。

7. [RemoteEsp32 Library](https://github.com/Rapidnack/RemoteEsp32)をZIPファイルを保存し、Sketch > Include Library > Add .ZIP Libraryでインストールします。

8. ESP32とPCをUSBケーブルで繋ぎます。

9. File > Examples > RemoteEsp32 > Esp32ServerTestSTAでサンプルスケッチを開き、ESP32に書き込みます。

# Licence

# Authors

[Rapidnack](http://rapidnack.com/)

# References

[https://github.com/Rapidnack/RemoteEsp32](https://github.com/Rapidnack/RemoteEsp32)  

# Status

[Arduino core for the ESP32](https://github.com/espressif/arduino-esp32)の関数の内、下記をC#から実行できます。

- double temperatureRead()
- uint micros()
- uint millis()
- void delay(uint ms)
- void delayMicroseconds(uint us)

- int analogRead(int pin)
- void analogReadResolution(int bits)
- void analogSetWidth(int bits)
- void analogSetCycles(int cycles)
- void analogSetSamples(int samples)
- void analogSetClockDiv(int clockDiv)
- void analogSetAttenuation(AdcAttenuation attenuation)
- void analogSetPinAttenuation(int pin, AdcAttenuation adcAttenuation)
- int hallRead()
- bool adcAttachPin(int pin)
- bool adcStart(int pin)
- bool adcBusy(int pin)
- int adcEnd(int pin)

- void dacWrite(int pin, int value)
- void pinMode(int pin, GpioFunction mode)
- void digitalWrite(int pin, int val)
- int digitalRead(int pin)
- void attachInterrupt(int pin, Action<int, UInt32> f, InterruptMode mode)
- void detachInterrupt(int pin)

- double ledcSetup(int channel, double freq, int resolution_bits)
- void ledcWrite(int channel, int duty)
- double ledcWriteTone(int channel, double freq)
- double ledcWriteNote(int channel, Note note, int octave)
- uint ledcRead(int channel)
- double ledcReadFreq(int channel)
- void ledcAttachPin(int pin, int channel)
- void ledcDetachPin(int pin)

- uint sigmaDeltaSetup(int channel, uint freq)
- void sigmaDeltaWrite(int channel, int duty)
- int sigmaDeltaRead(int channel)
- void sigmaDeltaAttachPin(int pin, int channel)
- void sigmaDeltaDetachPin(int pin)

- void touchSetCycles(int measure, int sleep)
- int touchRead(int pin)
- void touchAttachInterrupt(int pin, Action<int, UInt32> f, int threshold)

#### I2C

- void begin(int sda = -1, int scl = -1, uint frequency = 0)
- void setClock(uint frequency)
- uint getClock(uint frequency)
- void setTimeOut(int timeOutMillis)
- int getTimeOut()
- int lastError()
- string getErrorText(int err)
- I2CError writeTransmission(int address, byte[] buff, bool sendStop = true)
- I2CError readTransmission(int address, byte[] buff, bool sendStop, out uint readCount)
- void beginTransmission(UInt16 address)
- void beginTransmission(byte address)
- void beginTransmission(int address)
- int endTransmission(bool sendStop)
- int endTransmission(int sendStop)
- int endTransmission()
- int requestFrom(UInt16 address, int size, bool sendStop)
- int requestFrom(UInt16 address, int size, int sendStop)
- int requestFrom(UInt16 address, int size)
- int requestFrom(byte address, int size, int sendStop)
- int requestFrom(byte address, int size)
- int requestFrom(int address, int size, int sendStop)
- int requestFrom(int address, int size)
- uint write(byte data)
- uint write(byte[] buff)
- int available()
- int read()
- int peek()
- void flush()
- uint write(string s)
- uint write(uint n)
- uint write(int n)
- uint write(UInt16 n)
- uint write(Int16 n)
- void dumpInts()
- void dumpI2C()

#### SPI
- void begin(int sck = -1, int miso = -1, int mosi = -1, int ss = -1)
- void end()
- void setHwCs(bool hwCs)
- void setBitOrder(SPIBitOrder bitOrder)
- void setDataMode(SPIMode mode)
- void setFrequency(uint frequency)
- void setClockDivider(uint clockDiv)
- uint getClockDivider()
- void beginTransaction(uint clock = 1000000, SPIBitOrder bitOrder = SPIBitOrder.MSBFIRST, SPIMode dataMode = SPIMode.MODE0)
- void endTransaction()
- int transfer(int data)
- int transfer16(int data)
- uint transfer32(uint data)
- byte[] transferBytes(byte[] txBuf)
- uint transferBits(uint data, int bits)
- void write(int data)
- void write16(int data)
- void write32(uint data)
- void writeBytes(byte[] data)
- void writePixels(byte[] data)
- void writePattern(byte[] data, uint repeat)
