// (C) 2024 PeevishDave. Peevo.art
using System.IO.Ports;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TGBAFlasher
{
    public class GBAFlasher
    {
        public System.Action<SerialError, bool> onError;

        public bool Busy { get; private set; }

        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public void OpenPort(string portName)
        {
            _serialPort = new SerialPort(portName)
            {
                //BaudRate = 2700000,
                BaudRate = 270000,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500,
                ReadBufferSize = BUFFER_LENGTH,
            };

            _serialPort.Open();
            _serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(OnError);
        }

        void OnError(object sender, SerialErrorReceivedEventArgs e)
        {
            onError?.Invoke(e.EventType, _serialPort.IsOpen);
        }

        public void ClosePort()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        public async Task<byte[]?> DownloadHeader()
        {
            return await DownloadHeader(COMMAND_HEADER, 0);
        }

        async Task<byte[]?> DownloadHeader(byte[] command, int discardBytes)
        {
            if (!_serialPort.IsOpen)
                return null;

            Busy = true;
            _serialPort.DiscardInBuffer();

            SendData(command);

            int timeWait = 0;

            while (_serialPort.BytesToRead - discardBytes < header.Length)
            {
                if (timeWait > 1000)
                {
                    if (_serialPort.BytesToRead > 0)
                        MessageBox.Show($"Incomplete response from Serial Port");
                    else
                        MessageBox.Show($"No response from Serial Port");
                    Busy = false;
                    return null;
                }

                timeWait += 10;
                await Task.Delay(10);
            }

            for (int i=0; i<discardBytes; ++i)
                _serialPort.ReadByte();
            
            _serialPort.Read(header, 0, header.Length);

            Busy = false;

            return header.ToArray();
        }

        public async Task<int?> DetectSize()
        {
            if (!_serialPort.IsOpen)
                return null;

            var headerResult = await DownloadHeader();

            if (headerResult == null)
                return null;

            var duplicateResult = await DownloadHeader(COMMAND_DUPLICATE4, 2);

            if (duplicateResult == null)
                return null;

            bool isDuplicate = true;
            for (int i = 0; i < duplicateResult.Length; i++)
            {
                if (duplicateResult[i] != headerResult[i])
                {
                    isDuplicate = false;
                    break;
                }
            }

            if (isDuplicate)
                return 0; // 4MB

            duplicateResult = await DownloadHeader(COMMAND_DUPLICATE8, 2);

            if (duplicateResult == null)
                return null;

            isDuplicate = true;
            for (int i = 0; i < duplicateResult.Length; i++)
            {
                if (duplicateResult[i] != headerResult[i])
                {
                    isDuplicate = false;
                    break;
                }
            }

            if (isDuplicate)
                return 1; // 8MB

            duplicateResult = await DownloadHeader(COMMAND_DUPLICATE16, 2);

            if (duplicateResult == null)
                return null;

            isDuplicate = true;
            for (int i = 0; i < duplicateResult.Length; i++)
            {
                if (duplicateResult[i] != headerResult[i])
                {
                    isDuplicate = false;
                    break;
                }
            }

            if (isDuplicate)
                return 2; // 16MB

            return 3; // 32MB
        }

        public async Task<byte[]?> DownloadROM(int cartSizeIndex, System.Action<int> onProgress)
        {
            if (!_serialPort.IsOpen)
                return null;

            Busy = true;
            _serialPort.DiscardInBuffer();
            downloadedRom.Clear();

            if (cartSizeIndex == 1)
                SendData(COMMAND_DUMP8);
            else if (cartSizeIndex == 2)
                SendData(COMMAND_DUMP16);
            else if (cartSizeIndex == 3)
                SendData(COMMAND_DUMP32);
            else // if (cartSizeIndex == 0)
                SendData(COMMAND_DUMP4);

            int timeWait = 0;
            int prevDataCount = -1;

            int dataToReceive = 1 << (cartSizeIndex + 22);

            while (_serialPort.BytesToRead < dataToReceive)
            {
                if (prevDataCount == _serialPort.BytesToRead)
                {
                    if (timeWait > 1000)
                    {
                        if (_serialPort.BytesToRead > 0)
                            MessageBox.Show($"Incomplete response from Serial Port (" + _serialPort.BytesToRead + ")");
                        else
                            MessageBox.Show($"No response from Serial Port");
                        break;
                    }

                    timeWait += 10;
                }
                else
                    timeWait = 0;

                onProgress?.Invoke((int)(100 * _serialPort.BytesToRead / (float)dataToReceive));

                prevDataCount = _serialPort.BytesToRead;
                await Task.Delay(10);
            }

            int bytesRead = _serialPort.Read(readBuffer, 0, _serialPort.BytesToRead);

            for (int i = 0; i < bytesRead; i++)
                downloadedRom.Add(readBuffer[i]);

            Busy = false;

            return downloadedRom.ToArray();
        }

        public bool ChecksumTest(byte[] header, byte check)
        {
            int calculatedChk = 0;

            for (int i = 0xA0; i <= 0xBC; i++)
            {
                calculatedChk -= header[i];
            }

            return ((byte)((calculatedChk - 0x19) & 0xFF)) == check;
        }

        void SendData(byte[] data)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending data: {ex.Message}");
                }
            }
        }

        const int BUFFER_LENGTH = 32 * 1024 * 1024;


        SerialPort _serialPort;
        byte[] header = new byte[192];
        byte[] readBuffer = new byte[BUFFER_LENGTH];

        List<byte> downloadedRom = new List<byte>();

        static byte[] COMMAND_HEADER = new byte[] { 104 };
        static byte[] COMMAND_DUPLICATE4 = new byte[] { 106 };
        static byte[] COMMAND_DUPLICATE8 = new byte[] { 107 };
        static byte[] COMMAND_DUPLICATE16 = new byte[] { 108 };

        static byte[] COMMAND_DUMP4 = new byte[] { 97 };
        static byte[] COMMAND_DUMP8 = new byte[] { 98 };
        static byte[] COMMAND_DUMP16 = new byte[] { 99 };
        static byte[] COMMAND_DUMP32 = new byte[] { 100 };
    }
}
