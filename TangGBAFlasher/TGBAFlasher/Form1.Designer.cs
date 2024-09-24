
namespace TGBAFlasher
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Button buttonClosePort;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.TextBox textBoxReceived;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            comboBoxPorts = new ComboBox();
            buttonOpenPort = new Button();
            buttonClosePort = new Button();
            buttonDownload = new Button();
            textBoxReceived = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboCartridge = new ComboBox();
            buttonSave = new Button();
            checkStrip = new CheckBox();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            progressBar1 = new ProgressBar();
            labelTitle = new Label();
            labelCode = new Label();
            labelMaker = new Label();
            labelFixed = new Label();
            labelDevice = new Label();
            labelUnit = new Label();
            labelVersion = new Label();
            labelChecksum = new Label();
            pictureLogo = new PictureBox();
            labelStartAddress = new Label();
            label3 = new Label();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            SuspendLayout();
            // 
            // comboBoxPorts
            // 
            comboBoxPorts.FormattingEnabled = true;
            comboBoxPorts.Location = new Point(114, 12);
            comboBoxPorts.Name = "comboBoxPorts";
            comboBoxPorts.Size = new Size(165, 33);
            comboBoxPorts.TabIndex = 0;
            // 
            // buttonOpenPort
            // 
            buttonOpenPort.Location = new Point(285, 12);
            buttonOpenPort.Name = "buttonOpenPort";
            buttonOpenPort.Size = new Size(84, 33);
            buttonOpenPort.TabIndex = 1;
            buttonOpenPort.Text = "Open";
            buttonOpenPort.UseVisualStyleBackColor = true;
            buttonOpenPort.Click += buttonOpenPort_Click;
            // 
            // buttonClosePort
            // 
            buttonClosePort.Location = new Point(375, 12);
            buttonClosePort.Name = "buttonClosePort";
            buttonClosePort.Size = new Size(86, 33);
            buttonClosePort.TabIndex = 2;
            buttonClosePort.Text = "Close";
            buttonClosePort.UseVisualStyleBackColor = true;
            buttonClosePort.Click += buttonClosePort_Click;
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(608, 287);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(108, 34);
            buttonDownload.TabIndex = 4;
            buttonDownload.Text = "Download";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonSend_Click;
            // 
            // textBoxReceived
            // 
            textBoxReceived.Font = new Font("Cascadia Mono", 8F);
            textBoxReceived.Location = new Point(14, 367);
            textBoxReceived.Multiline = true;
            textBoxReceived.Name = "textBoxReceived";
            textBoxReceived.ReadOnly = true;
            textBoxReceived.ScrollBars = ScrollBars.Vertical;
            textBoxReceived.Size = new Size(692, 295);
            textBoxReceived.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 16);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 6;
            label1.Text = "Serial Port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(305, 290);
            label2.Name = "label2";
            label2.Size = new Size(125, 25);
            label2.TabIndex = 7;
            label2.Text = "Cartridge Size:";
            // 
            // comboCartridge
            // 
            comboCartridge.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCartridge.FormattingEnabled = true;
            comboCartridge.Items.AddRange(new object[] { "4MB", "8MB", "16MB", "32MB" });
            comboCartridge.Location = new Point(436, 287);
            comboCartridge.Name = "comboCartridge";
            comboCartridge.Size = new Size(165, 33);
            comboCartridge.TabIndex = 8;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(608, 668);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(108, 31);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // checkStrip
            // 
            checkStrip.AutoSize = true;
            checkStrip.Location = new Point(481, 670);
            checkStrip.Name = "checkStrip";
            checkStrip.Size = new Size(120, 29);
            checkStrip.TabIndex = 10;
            checkStrip.Text = "Strip ROM";
            checkStrip.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 710);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(729, 32);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(67, 25);
            statusLabel.Text = "READY";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(25, 327);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(691, 34);
            progressBar1.TabIndex = 12;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(13, 66);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(99, 25);
            labelTitle.TabIndex = 13;
            labelTitle.Text = "Game Title:";
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(14, 91);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(109, 25);
            labelCode.TabIndex = 14;
            labelCode.Text = "Game Code:";
            // 
            // labelMaker
            // 
            labelMaker.AutoSize = true;
            labelMaker.Location = new Point(14, 141);
            labelMaker.Name = "labelMaker";
            labelMaker.Size = new Size(65, 25);
            labelMaker.TabIndex = 15;
            labelMaker.Text = "Maker:";
            // 
            // labelFixed
            // 
            labelFixed.AutoSize = true;
            labelFixed.Location = new Point(17, 183);
            labelFixed.Name = "labelFixed";
            labelFixed.Size = new Size(109, 25);
            labelFixed.TabIndex = 16;
            labelFixed.Text = "Fixed Check:";
            // 
            // labelDevice
            // 
            labelDevice.AutoSize = true;
            labelDevice.Location = new Point(182, 208);
            labelDevice.Name = "labelDevice";
            labelDevice.Size = new Size(108, 25);
            labelDevice.TabIndex = 17;
            labelDevice.Text = "Device type:";
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Location = new Point(17, 208);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(95, 25);
            labelUnit.TabIndex = 18;
            labelUnit.Text = "Unit Code:";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(14, 116);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(74, 25);
            labelVersion.TabIndex = 19;
            labelVersion.Text = "Version:";
            // 
            // labelChecksum
            // 
            labelChecksum.AutoSize = true;
            labelChecksum.Location = new Point(182, 183);
            labelChecksum.Name = "labelChecksum";
            labelChecksum.Size = new Size(97, 25);
            labelChecksum.TabIndex = 20;
            labelChecksum.Text = "Checksum:";
            // 
            // pictureLogo
            // 
            pictureLogo.BorderStyle = BorderStyle.FixedSingle;
            pictureLogo.Location = new Point(285, 91);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(416, 64);
            pictureLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLogo.TabIndex = 21;
            pictureLogo.TabStop = false;
            // 
            // labelStartAddress
            // 
            labelStartAddress.AutoSize = true;
            labelStartAddress.Location = new Point(18, 242);
            labelStartAddress.Name = "labelStartAddress";
            labelStartAddress.Size = new Size(122, 25);
            labelStartAddress.TabIndex = 22;
            labelStartAddress.Text = "Start Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 63);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 23;
            label3.Text = "Logo:";
            // 
            // Form1
            // 
            ClientSize = new Size(729, 742);
            Controls.Add(label3);
            Controls.Add(labelStartAddress);
            Controls.Add(pictureLogo);
            Controls.Add(labelChecksum);
            Controls.Add(labelVersion);
            Controls.Add(labelUnit);
            Controls.Add(labelDevice);
            Controls.Add(labelFixed);
            Controls.Add(labelMaker);
            Controls.Add(labelCode);
            Controls.Add(labelTitle);
            Controls.Add(progressBar1);
            Controls.Add(statusStrip1);
            Controls.Add(checkStrip);
            Controls.Add(buttonSave);
            Controls.Add(comboCartridge);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxReceived);
            Controls.Add(buttonDownload);
            Controls.Add(buttonClosePort);
            Controls.Add(buttonOpenPort);
            Controls.Add(comboBoxPorts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Tang GBA Flasher";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private ComboBox comboCartridge;
        private Button buttonSave;
        private CheckBox checkStrip;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ProgressBar progressBar1;
        private Label labelTitle;
        private Label labelCode;
        private Label labelMaker;
        private Label labelFixed;
        private Label labelDevice;
        private Label labelUnit;
        private Label labelVersion;
        private Label labelChecksum;
        private PictureBox pictureLogo;
        private Label labelStartAddress;
        private Label label3;
    }
}