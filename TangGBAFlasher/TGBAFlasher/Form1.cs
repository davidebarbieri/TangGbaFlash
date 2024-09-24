// (C) 2024 PeevishDave. Peevo.art

using System.Text;

namespace TGBAFlasher
{
    public partial class Form1 : Form
    {
        public Form1(GBAFlasher flasher)
        {
            this.flasher = flasher;
            InitializeComponent();
            LoadAvailablePorts();
            SetupForm();
        }

        private void LoadAvailablePorts()
        {
            comboBoxPorts.Items.Clear();
            string[] ports = flasher.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            if (ports.Length > 0)
                comboBoxPorts.SelectedIndex = 0;

            comboCartridge.SelectedIndex = 0;
        }

        private void SetupForm()
        {
            buttonOpenPort.Enabled = true;
            buttonClosePort.Enabled = false;
            buttonDownload.Enabled = false;
            buttonSave.Enabled = false;
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (flasher.Busy)
                return;

            if (comboBoxPorts.SelectedItem == null)
            {
                MessageBox.Show("No COM port selected.");
                return;
            }

            try
            {
                flasher.OpenPort(comboBoxPorts.SelectedItem.ToString());
                buttonOpenPort.Enabled = false;
                buttonClosePort.Enabled = true;
                buttonDownload.Enabled = true;

                statusLabel.Text = "Downloading header";
                Task.Run(flasher.DownloadHeader).ContinueWith(
                    (Task<byte[]> t) =>
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            var header = t.Result;

                            statusLabel.Text = "Header received";
                            textBoxReceived.Text = PrintHex(header);

                            labelTitle.Text = "Game Title: " + GetStringFromHeader(header, 160, 12);
                            labelCode.Text = "Game Code: " + GetStringFromHeader(header, 172, 4);
                            labelMaker.Text = "Maker: " + GetStringFromHeader(header, 176, 2);
                            labelFixed.Text = "Fixed Check: " + ((header[178] == 0x96) ? "OK" : "FAIL");
                            labelUnit.Text = "Unit Code: " + header[179].ToString("X2");
                            labelDevice.Text = "Device Type: " + header[180].ToString("X2");
                            labelVersion.Text = "Version: " + header[188].ToString("X2");
                            labelChecksum.Text = "Checksum: " + header[189].ToString("X2");

                            var startAddress = 8 + (((int)header[0]) << 2) +
                                                (((int)header[1]) << 10) +
                                                (((int)header[2]) << 18);

                            labelStartAddress.Text = "Start Address: " + startAddress.ToString("X2") + " (" + startAddress + ")";

                            pictureLogo.Image = GBALogoDecoder.DecodeLogo(header);
                        }));
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while trying to open port: {ex.Message}");
            }
        }

        private void buttonClosePort_Click(object sender, EventArgs e)
        {
            if (flasher.Busy)
                return;

            flasher.ClosePort();
            SetupForm();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            int cartIndex = comboCartridge.SelectedIndex;

            if (!flasher.Busy)
            {
                statusLabel.Text = "Downloading ROM";

                progressBar1.Value = 0;
                Task.Run(() => flasher.DownloadROM(cartIndex, (percentage) =>
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        progressBar1.Value = percentage;
                    }));
                })).ContinueWith((Task<byte[]> task) =>
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        progressBar1.Value = 100;
                        statusLabel.Text = "ROM downloaded";
                        textBoxReceived.Text = PrintHex(task.Result);

                        buttonSave.Enabled = true;
                        downloadedRom = task.Result;
                    }));
                });
            }
        }


        string GetStringFromHeader(byte[] header, int from, int len)
        {
            string value = "";
            for (int i = 0; i < len; ++i)
                value += (char)header[from + i];

            return value;
        }



        string PrintHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            string representation = "";

            for (int i = 0, count = data.Length; i < count; ++i)
            {
                var b = data[i];

                if (i > 0 && (i % 16) == 0)
                {
                    sb.Append("   " + representation);
                    representation = "";
                    sb.AppendLine();
                }

                sb.Append(b.ToString("X2") + " ");
                var charB = (char)b;
                representation += char.IsAsciiLetter(charB) || char.IsPunctuation(charB) ? charB : ".";

            }

            if (!string.IsNullOrEmpty(representation))
                sb.Append(representation);


            return sb.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<byte> downloadedRomCopy = new List<byte>(downloadedRom);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "ROM files (*.gba)|*.gba";
                saveFileDialog.Title = "Choose the destination file";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (checkStrip.Checked)
                        {
                            // Remove ending FF
                            for (int i = downloadedRomCopy.Count - 1; i >= 0; --i)
                            {
                                if (downloadedRomCopy[i] == 0xFF)
                                {
                                    downloadedRomCopy.RemoveAt(i);
                                }
                                else
                                    break;
                            }
                        }

                        File.WriteAllBytes(saveFileDialog.FileName, downloadedRomCopy.ToArray());
                        MessageBox.Show("Rom Saved!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during ROM save: {ex.Message}");
                    }
                }
            }
        }

        GBAFlasher flasher;
        byte[] downloadedRom;
    }
}