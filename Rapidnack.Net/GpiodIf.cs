using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Rapidnack.Net
{
	public class GpiodIf : IDisposable
	{
		public class GpioExtent
		{
			public byte[] Contents { get; set; }
		}


		public class Callback
		{
			public int gpio { get; set; }
			public Action<int, UInt32> f { get; set; }
		}


		public class I2CReceiveCallback
		{
			public Action<int> f { get; set; }
		}


		public class I2CRequestCallback
		{
			public Action f { get; set; }
		}


		#region # event

		public event EventHandler StreamConnected;

		#endregion


		#region # private const

		private const string DEFAULT_SOCKET_PORT_STR = "8888";
		private const string DEFAULT_SOCKET_ADDR_STR = "127.0.0.1";

		private const int MAX_REPORTS_PER_READ = 4096;

		private const int CMD_NC = 21;
		private const int CMD_NOIB = 99;

		#endregion


		#region # private field

		private bool isConnecting = false;

		private int handle = -1;

		private CancellationTokenSource cts;

		private Callback[] callbackList = new Callback[40];

		#endregion


		#region # private property

		private TcpConnection TcpConnection { get; set; }

		private TcpConnection NotifyTcpConnection { get; set; }

		#endregion


		#region # public property

		private object _lockObject = new object();
		public object LockObject
		{
			get
			{
				return _lockObject;
			}
		}

		private NetworkStream _commandStream = null;
		public NetworkStream CommandStream
		{
			get
			{
				return _commandStream;
			}
			private set
			{
				_commandStream = value;

				if (CommandStream != null && NotifyStream != null && !isConnecting)
				{
					isConnecting = true;
					if (StreamConnected != null)
					{
						StreamConnected.Invoke(this, new EventArgs());
					}
				}
			}
		}

		private NetworkStream _notifyStream = null;
		public NetworkStream NotifyStream
		{
			get
			{
				return _notifyStream;
			}
			private set
			{
				_notifyStream = value;

				if (CommandStream != null && NotifyStream != null && !isConnecting)
				{
					isConnecting = true;
					if (StreamConnected != null)
					{
						StreamConnected.Invoke(this, new EventArgs());
					}
				}
			}
		}

		public bool IsOpened
		{
			get
			{
				if (this.TcpConnection == null || NotifyTcpConnection == null)
					return false;
				return this.TcpConnection.IsOpened && NotifyTcpConnection.IsOpened;
			}
		}

		public bool CanRead
		{
			get
			{
				if (this.TcpConnection.Stream == null || NotifyTcpConnection.Stream == null)
					return false;
				return this.TcpConnection.Stream.CanRead && NotifyTcpConnection.Stream.CanRead;
			}
		}

		public bool CanWrite
		{
			get
			{
				if (this.TcpConnection.Stream == null || NotifyTcpConnection.Stream == null)
					return false;
				return this.TcpConnection.Stream.CanWrite && NotifyTcpConnection.Stream.CanWrite;
			}
		}

		#endregion


		#region # constructor

		public GpiodIf()
		{
			this.TcpConnection = new TcpConnection();
			this.TcpConnection.StreamChanged += (s, evt) =>
			{
				this.CommandStream = this.TcpConnection.Stream;
			};

			NotifyTcpConnection = new TcpConnection();
			NotifyTcpConnection.StreamChanged += (s, evt) =>
			{
				NotifyStream = NotifyTcpConnection.Stream;

				if (NotifyTcpConnection.Stream != null)
				{
					NotifyStream.ReadTimeout = Timeout.Infinite;

					handle = GpioNotify();

					if (handle >= 0)
					{
						cts = new CancellationTokenSource();
						Task.Run(() => NotifyThread(cts.Token));
					}
				}
			};
		}

		#endregion


		#region # Implementation of IDisposable

		bool disposed = false;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				// Release managed objects
				GpioStop();
			}

			// Release unmanaged objects

			disposed = true;
		}
		~GpiodIf()
		{
			Dispose(false);
		}

		#endregion


		#region # public method

		public int GpioStart(string addrStr, string portStr)
		{
			handle = -1;

			if (string.IsNullOrWhiteSpace(addrStr))
			{
				addrStr = DEFAULT_SOCKET_ADDR_STR;
			}
			if (string.IsNullOrWhiteSpace(portStr))
			{
				portStr = DEFAULT_SOCKET_PORT_STR;
			}

			int port;
			if (int.TryParse(portStr, out port) == false)
			{
				throw new GpiodIfException("failed to find address of the device");
			}

			isConnecting = false;
			this.TcpConnection.Open(addrStr, port);
			NotifyTcpConnection.Open(addrStr, port);

			return 0;
		}

		public void GpioStop()
		{
			if (cts != null)
			{
				cts.Cancel();
			}

			if (handle >= 0)
			{
				GpioCommand(CMD_NC, handle, 0);
				handle = -1;
			}

			if (this.TcpConnection != null)
			{
				// Execute handlers of StreamChanged event, and call Close()
				this.CommandStream = null;
				this.TcpConnection.Close();
			}
			if (NotifyTcpConnection != null)
			{
				// Execute handlers of NotifyStreamChanged event, and call Close()
				NotifyStream = null;
				NotifyTcpConnection.Close();
			}
		}

		#endregion


		#region # private method

		public byte[] IntArrayToBytes(int[] array)
		{
			int numBytes = 4;

			byte[] bytes = new byte[numBytes * array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				byte[] tempBytes = BitConverter.GetBytes(array[i]);
				tempBytes.CopyTo(bytes, numBytes * i);
			}

			return bytes;
		}

		public byte[] IntToBytes(int data)
		{
			return IntArrayToBytes(new int[] { data });
		}

		public int[] BytesToIntArray(byte[] bytes)
		{
			int numBytes = 4;

			int[] array = new int[bytes.Length / numBytes];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = BitConverter.ToInt32(bytes, numBytes * i);
			}

			return array;
		}

		public int BytesToInt(byte[] bytes, int startIndex = 0)
		{
			return BitConverter.ToInt32(bytes, startIndex);
		}

		public int GpioCommand(int command, int p1, int p2)
		{
			var cmd = InternalGpioCommand(command, p1, p2);
			return cmd[2];
		}

		public int GpioCommand(int command, int p1, int p2, out byte[] rxBuf)
		{
			rxBuf = new byte[0];

			lock (LockObject)
			{
				var cmd = InternalGpioCommand(command, p1, p2);
				int bytes = cmd[3];

				if (bytes > 0)
				{
					rxBuf = new byte[bytes];
					RecvMax(rxBuf, bytes);
				}

				return cmd[2];
			}
		}

		private int[] InternalGpioCommand(int command, int p1, int p2)
		{
			if (CanWrite == false || CanRead == false)
			{
				throw new GpiodIfException("not connected to the device");
			}

			int[] cmd = new int[4];
			cmd[0] = command;
			cmd[1] = p1;
			cmd[2] = p2;
			cmd[3] = 0;

			// int[] -> byte[]
			byte[] bytes = IntArrayToBytes(cmd);

			lock (LockObject)
			{
				try
				{
					this.TcpConnection.Stream.Write(bytes, 0, bytes.Length);
				}
				catch (Exception)
				{
					throw new GpiodIfException("failed to send to the device");
				}

				try
				{
					if (this.TcpConnection.Stream.Read(bytes, 0, bytes.Length) != bytes.Length)
					{
						throw new GpiodIfException("failed to receive from the device");
					}
				}
				catch (Exception)
				{
					throw new GpiodIfException("failed to receive from the device");
				}
			}

			// byte[] -> int[]
			cmd = BytesToIntArray(bytes);

			return cmd;
		}

		private int GpioNotify()
		{
			if (NotifyTcpConnection == null || NotifyTcpConnection.Stream == null ||
				NotifyTcpConnection.Stream.CanWrite == false || NotifyTcpConnection.Stream.CanRead == false)
			{
				throw new GpiodIfException("not connected to the device");
			}

			int[] cmd = new int[4];
			cmd[0] = CMD_NOIB;
			cmd[1] = 0;
			cmd[2] = 0;
			cmd[3] = 0;

			// int[] -> byte[]
			byte[] bytes = IntArrayToBytes(cmd);

			lock (LockObject)
			{
				try
				{
					NotifyTcpConnection.Stream.Write(bytes, 0, bytes.Length);
				}
				catch (Exception)
				{
					throw new GpiodIfException("failed to send to the device");
				}

				try
				{
					if (NotifyTcpConnection.Stream.Read(bytes, 0, bytes.Length) != bytes.Length)
					{
						throw new GpiodIfException("failed to receive from the device");
					}
				}
				catch (Exception)
				{
					throw new GpiodIfException("failed to receive from the device");
				}
			}

			// byte[] -> int[]
			cmd = BytesToIntArray(bytes);

			return cmd[2];
		}

		public int GpioCommandExt(int command, int p1, int p2, GpioExtent[] exts)
		{
			int[] cmd = InternalGpioCommandExt(command, p1, p2, exts);
			return cmd[2];
		}

		public int GpioCommandExt(int command, int p1, int p2, GpioExtent[] exts, out byte[] rxBuf)
		{
			rxBuf = new byte[0];

			lock (LockObject)
			{
				var cmd = InternalGpioCommandExt(command, p1, p2, exts);
				int bytes = cmd[3];

				if (bytes > 0)
				{
					rxBuf = new byte[bytes];
					RecvMax(rxBuf, bytes);
				}

				return cmd[2];
			}
		}

		protected int[] InternalGpioCommandExt(int command, int p1, int p2, GpioExtent[] exts)
		{
			if (CanWrite == false || CanRead == false)
			{
				throw new GpiodIfException("not connected to the device");
			}

			int extsBytes = 0;
			foreach (var ext in exts)
			{
				extsBytes += ext.Contents.Length;
			}

			int[] cmd = new int[4];
			cmd[0] = command;
			cmd[1] = p1;
			cmd[2] = p2;
			cmd[3] = extsBytes;

			// int[] -> byte[]
			byte[] cmdBytes = IntArrayToBytes(cmd);

			byte[] bytes = new byte[cmdBytes.Length + extsBytes];
			int index = 0;
			cmdBytes.CopyTo(bytes, index); index += cmdBytes.Length;
			foreach (var ext in exts)
			{
				ext.Contents.CopyTo(bytes, index); index += ext.Contents.Length;
			}

			lock (LockObject)
			{
				try
				{
					this.TcpConnection.Stream.Write(bytes, 0, bytes.Length);
				}
				catch (Exception)
				{
					throw new GpiodIfException("failed to send to the device");
				}

				try
				{
					if (this.TcpConnection.Stream.Read(cmdBytes, 0, cmdBytes.Length) != cmdBytes.Length)
					{
						throw new GpiodIfException("failed to receive from the device");
					}
				}
				catch (Exception)
				{
					throw new GpiodIfException("failed to receive from the device");
				}
			}

			// byte[] -> int[]
			cmd = BytesToIntArray(cmdBytes);

			return cmd;
		}

		private void NotifyThread(CancellationToken ct)
		{
			byte[] bytes = new byte[8 * MAX_REPORTS_PER_READ];
			int received = 0;

			while (ct.IsCancellationRequested == false)
			{
				if (NotifyTcpConnection == null || NotifyTcpConnection.Stream == null || NotifyTcpConnection.Stream.CanRead == false)
					break;

				try
				{
					while (received < 8)
					{
						received += NotifyTcpConnection.Stream.Read(bytes, received, bytes.Length - received);
					}
				}
				catch (System.IO.IOException)
				{
					break;
				}

				int p = 0;
				while (p + 8 <= received)
				{
					int gpio = BitConverter.ToInt32(new byte[] { bytes[p + 0], bytes[p + 1], bytes[p + 2], bytes[p + 3] }, 0);
					UInt32 tick = BitConverter.ToUInt32(new byte[] { bytes[p + 4], bytes[p + 5], bytes[p + 6], bytes[p + 7] }, 0);
					if (callbackList[gpio] != null)
					{
						var callback = callbackList[gpio];
						callback.f(gpio, tick);
					}
					p += 8;
				}
				for (int i = p; i < received; i++)
				{
					bytes[i - p] = bytes[i];
				}
				received -= p;
			}
		}

		protected int InternalCallback(int user_gpio, Action<int, UInt32> f)
		{
			if (f == null)
			{
				throw new GpiodIfException("null callback function");
			}

			if (user_gpio < 0 && callbackList.Length <= user_gpio)
			{
				throw new GpiodIfException($"GPIO not 0-{callbackList.Length - 1}");
			}

			/* prevent duplicates */
			if (callbackList[user_gpio] != null)
			{
				throw new GpiodIfException("identical callback exists");
			}

			var callback = new Callback()
			{
				gpio = user_gpio,
				f = f
			};
			callbackList[user_gpio] = callback;

			return 0;
		}

		protected int InternalCallbackCancel(int user_gpio)
		{
			if (user_gpio < 0 && callbackList.Length <= user_gpio)
			{
				throw new GpiodIfException($"GPIO not 0-{callbackList.Length - 1}");
			}

			if (callbackList[user_gpio] == null)
			{
				throw new GpiodIfException("callback not found");
			}

			callbackList[user_gpio] = null;

			return 0;
		}

		protected int RecvMax(byte[] buf, int sent)
		{
			/*
			Copy at most bufSize bytes from the receieved message to
			buf.  Discard the rest of the message.
			*/
			byte[] scratch = new byte[4096];
			int remaining, fetch, count;

			if (sent < buf.Length) count = sent; else count = buf.Length;

			if (count > 0)
			{
				int received = 0;
				while (received < count)
				{
					received += this.TcpConnection.Stream.Read(buf, received, count - received);
				}
			}

			remaining = sent - count;

			while (remaining > 0)
			{
				fetch = remaining;
				if (fetch > scratch.Length) fetch = scratch.Length;
				remaining -= this.TcpConnection.Stream.Read(scratch, 0, fetch);
			}

			return count;
		}

		#endregion
	}
}
