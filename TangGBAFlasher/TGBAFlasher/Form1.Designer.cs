
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
            progressBar1 = new ToolStripProgressBar();
            groupHeader = new GroupBox();
            buttonRefreshHeader = new Button();
            label3 = new Label();
            labelStartAddress = new Label();
            pictureLogo = new PictureBox();
            labelChecksum = new Label();
            labelVersion = new Label();
            labelUnit = new Label();
            labelDevice = new Label();
            labelFixed = new Label();
            labelMaker = new Label();
            labelCode = new Label();
            labelTitle = new Label();
            buttonDetectSize = new Button();
            linkLabel1 = new LinkLabel();
            statusStrip1.SuspendLayout();
            groupHeader.SuspendLayout();
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
            buttonDownload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDownload.Location = new Point(625, 365);
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
            textBoxReceived.Location = new Point(15, 405);
            textBoxReceived.Multiline = true;
            textBoxReceived.Name = "textBoxReceived";
            textBoxReceived.ReadOnly = true;
            textBoxReceived.ScrollBars = ScrollBars.Vertical;
            textBoxReceived.Size = new Size(718, 302);
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
            label2.Location = new Point(236, 370);
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
            comboCartridge.Location = new Point(367, 365);
            comboCartridge.Name = "comboCartridge";
            comboCartridge.Size = new Size(165, 33);
            comboCartridge.TabIndex = 8;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSave.Location = new Point(625, 713);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(108, 33);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // checkStrip
            // 
            checkStrip.AutoSize = true;
            checkStrip.Location = new Point(499, 716);
            checkStrip.Name = "checkStrip";
            checkStrip.Size = new Size(120, 29);
            checkStrip.TabIndex = 10;
            checkStrip.Text = "Strip ROM";
            checkStrip.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel, progressBar1 });
            statusStrip1.Location = new Point(0, 751);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(745, 32);
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
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 24);
            // 
            // groupHeader
            // 
            groupHeader.Controls.Add(buttonRefreshHeader);
            groupHeader.Controls.Add(label3);
            groupHeader.Controls.Add(labelStartAddress);
            groupHeader.Controls.Add(pictureLogo);
            groupHeader.Controls.Add(labelChecksum);
            groupHeader.Controls.Add(labelVersion);
            groupHeader.Controls.Add(labelUnit);
            groupHeader.Controls.Add(labelDevice);
            groupHeader.Controls.Add(labelFixed);
            groupHeader.Controls.Add(labelMaker);
            groupHeader.Controls.Add(labelCode);
            groupHeader.Controls.Add(labelTitle);
            groupHeader.Location = new Point(15, 61);
            groupHeader.Name = "groupHeader";
            groupHeader.Size = new Size(718, 298);
            groupHeader.TabIndex = 24;
            groupHeader.TabStop = false;
            groupHeader.Text = "GamePak Header";
            // 
            // buttonRefreshHeader
            // 
            buttonRefreshHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRefreshHeader.Location = new Point(270, 253);
            buttonRefreshHeader.Name = "buttonRefreshHeader";
            buttonRefreshHeader.Size = new Size(176, 34);
            buttonRefreshHeader.TabIndex = 35;
            buttonRefreshHeader.Text = "Refresh Header";
            buttonRefreshHeader.UseVisualStyleBackColor = true;
            buttonRefreshHeader.Click += buttonRefreshHeader_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(280, 35);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 34;
            label3.Text = "Logo:";
            // 
            // labelStartAddress
            // 
            labelStartAddress.AutoSize = true;
            labelStartAddress.Location = new Point(10, 224);
            labelStartAddress.Name = "labelStartAddress";
            labelStartAddress.Size = new Size(122, 25);
            labelStartAddress.TabIndex = 33;
            labelStartAddress.Text = "Start Address:";
            // 
            // pictureLogo
            // 
            pictureLogo.BorderStyle = BorderStyle.FixedSingle;
            pictureLogo.Location = new Point(286, 62);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(416, 64);
            pictureLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLogo.TabIndex = 32;
            pictureLogo.TabStop = false;
            // 
            // labelChecksum
            // 
            labelChecksum.AutoSize = true;
            labelChecksum.Location = new Point(306, 194);
            labelChecksum.Name = "labelChecksum";
            labelChecksum.Size = new Size(97, 25);
            labelChecksum.TabIndex = 31;
            labelChecksum.Text = "Checksum:";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(10, 100);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(74, 25);
            labelVersion.TabIndex = 30;
            labelVersion.Text = "Version:";
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Location = new Point(10, 194);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(95, 25);
            labelUnit.TabIndex = 29;
            labelUnit.Text = "Unit Code:";
            // 
            // labelDevice
            // 
            labelDevice.AutoSize = true;
            labelDevice.Location = new Point(9, 161);
            labelDevice.Name = "labelDevice";
            labelDevice.Size = new Size(108, 25);
            labelDevice.TabIndex = 28;
            labelDevice.Text = "Device type:";
            // 
            // labelFixed
            // 
            labelFixed.AutoSize = true;
            labelFixed.Location = new Point(306, 224);
            labelFixed.Name = "labelFixed";
            labelFixed.Size = new Size(109, 25);
            labelFixed.TabIndex = 27;
            labelFixed.Text = "Fixed Check:";
            // 
            // labelMaker
            // 
            labelMaker.AutoSize = true;
            labelMaker.Location = new Point(10, 131);
            labelMaker.Name = "labelMaker";
            labelMaker.Size = new Size(65, 25);
            labelMaker.TabIndex = 26;
            labelMaker.Text = "Maker:";
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(9, 68);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(109, 25);
            labelCode.TabIndex = 25;
            labelCode.Text = "Game Code:";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(10, 36);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(99, 25);
            labelTitle.TabIndex = 24;
            labelTitle.Text = "Game Title:";
            // 
            // buttonDetectSize
            // 
            buttonDetectSize.Font = new Font("Segoe UI", 9F);
            buttonDetectSize.Location = new Point(538, 365);
            buttonDetectSize.Name = "buttonDetectSize";
            buttonDetectSize.Size = new Size(81, 34);
            buttonDetectSize.TabIndex = 25;
            buttonDetectSize.Text = "Detect";
            buttonDetectSize.UseVisualStyleBackColor = true;
            buttonDetectSize.Click += buttonDetectSize_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(532, 16);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(185, 25);
            linkLabel1.TabIndex = 26;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Made by PeevishDave";
            linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            ClientSize = new Size(745, 783);
            Controls.Add(linkLabel1);
            Controls.Add(buttonDetectSize);
            Controls.Add(groupHeader);
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
            groupHeader.ResumeLayout(false);
            groupHeader.PerformLayout();
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
        private GroupBox groupHeader;
        private Label label3;
        private Label labelStartAddress;
        private PictureBox pictureLogo;
        private Label labelChecksum;
        private Label labelVersion;
        private Label labelUnit;
        private Label labelDevice;
        private Label labelFixed;
        private Label labelMaker;
        private Label labelCode;
        private Label labelTitle;
        private Button buttonRefreshHeader;
        private ToolStripProgressBar progressBar1;
        private Button buttonDetectSize;
        private LinkLabel linkLabel1;
    }
}