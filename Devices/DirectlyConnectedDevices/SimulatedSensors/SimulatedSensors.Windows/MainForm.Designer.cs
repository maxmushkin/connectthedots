namespace SimulatedSensors.Windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textConnectionString = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.trackBarTemperature = new System.Windows.Forms.TrackBar();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textAlerts = new System.Windows.Forms.TextBox();
            this.labelGateway = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.btnGetDevices = new System.Windows.Forms.Button();
            this.cmbHubDevices = new System.Windows.Forms.ComboBox();
            this.cmbGatewayId = new System.Windows.Forms.ComboBox();
            this.cmbDeviceId = new System.Windows.Forms.ComboBox();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxVariation = new System.Windows.Forms.CheckBox();
            this.lblSentCount = new System.Windows.Forms.Label();
            this.textDBConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInstance = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textConnectionString
            // 
            this.textConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textConnectionString.Location = new System.Drawing.Point(14, 330);
            this.textConnectionString.Margin = new System.Windows.Forms.Padding(4);
            this.textConnectionString.Multiline = true;
            this.textConnectionString.Name = "textConnectionString";
            this.textConnectionString.Size = new System.Drawing.Size(792, 106);
            this.textConnectionString.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SimulatedSensors.Windows.Properties.Resources.SBLogoMedium;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(810, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.ForeColor = System.Drawing.Color.White;
            this.labelDeviceName.Location = new System.Drawing.Point(70, 1130);
            this.labelDeviceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(458, 25);
            this.labelDeviceName.TabIndex = 3;
            this.labelDeviceName.Text = "DeviceInstance Id  (physical, not azure device)";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionString.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelConnectionString.Location = new System.Drawing.Point(22, 300);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(335, 26);
            this.labelConnectionString.TabIndex = 4;
            this.labelConnectionString.Text = "Connection String (of IoT Hub)";
            // 
            // trackBarTemperature
            // 
            this.trackBarTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTemperature.Location = new System.Drawing.Point(14, 1074);
            this.trackBarTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarTemperature.Maximum = 100;
            this.trackBarTemperature.Name = "trackBarTemperature";
            this.trackBarTemperature.Size = new System.Drawing.Size(796, 90);
            this.trackBarTemperature.TabIndex = 7;
            this.trackBarTemperature.TabStop = false;
            this.trackBarTemperature.Value = 70;
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelTemperature.Location = new System.Drawing.Point(22, 1050);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(155, 26);
            this.labelTemperature.TabIndex = 6;
            this.labelTemperature.Text = "PresentValue";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(286, 1172);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(258, 38);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "Send Data";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // textAlerts
            // 
            this.textAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAlerts.BackColor = System.Drawing.SystemColors.Window;
            this.textAlerts.Location = new System.Drawing.Point(14, 1218);
            this.textAlerts.Margin = new System.Windows.Forms.Padding(4);
            this.textAlerts.Multiline = true;
            this.textAlerts.Name = "textAlerts";
            this.textAlerts.ReadOnly = true;
            this.textAlerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAlerts.Size = new System.Drawing.Size(792, 230);
            this.textAlerts.TabIndex = 11;
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGateway.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelGateway.Location = new System.Drawing.Point(22, 744);
            this.labelGateway.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(537, 26);
            this.labelGateway.TabIndex = 12;
            this.labelGateway.Text = "GatewayName (name of on premise IoT gateway)";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDevice.Location = new System.Drawing.Point(22, 848);
            this.lblDevice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(670, 26);
            this.lblDevice.TabIndex = 14;
            this.lblDevice.Text = "DeviceName (name of on premise device sending to gateway)";
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjectType.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblObjectType.Location = new System.Drawing.Point(22, 960);
            this.lblObjectType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(132, 26);
            this.lblObjectType.TabIndex = 16;
            this.lblObjectType.Text = "ObjectType";
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(286, 554);
            this.btnGetDevices.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(254, 46);
            this.btnGetDevices.TabIndex = 17;
            this.btnGetDevices.Text = "Get IoTHub Devices";
            this.btnGetDevices.UseVisualStyleBackColor = true;
            this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
            // 
            // cmbHubDevices
            // 
            this.cmbHubDevices.FormattingEnabled = true;
            this.cmbHubDevices.Location = new System.Drawing.Point(14, 656);
            this.cmbHubDevices.Margin = new System.Windows.Forms.Padding(6);
            this.cmbHubDevices.Name = "cmbHubDevices";
            this.cmbHubDevices.Size = new System.Drawing.Size(792, 33);
            this.cmbHubDevices.TabIndex = 18;
            this.cmbHubDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // cmbGatewayId
            // 
            this.cmbGatewayId.FormattingEnabled = true;
            this.cmbGatewayId.Location = new System.Drawing.Point(14, 776);
            this.cmbGatewayId.Margin = new System.Windows.Forms.Padding(6);
            this.cmbGatewayId.Name = "cmbGatewayId";
            this.cmbGatewayId.Size = new System.Drawing.Size(792, 33);
            this.cmbGatewayId.TabIndex = 19;
            this.cmbGatewayId.SelectedIndexChanged += new System.EventHandler(this.cmbGatewayId_SelectedIndexChanged);
            // 
            // cmbDeviceId
            // 
            this.cmbDeviceId.FormattingEnabled = true;
            this.cmbDeviceId.Location = new System.Drawing.Point(14, 882);
            this.cmbDeviceId.Margin = new System.Windows.Forms.Padding(6);
            this.cmbDeviceId.Name = "cmbDeviceId";
            this.cmbDeviceId.Size = new System.Drawing.Size(792, 33);
            this.cmbDeviceId.TabIndex = 20;
            this.cmbDeviceId.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceId_SelectedIndexChanged);
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(14, 994);
            this.cmbObjectType.Margin = new System.Windows.Forms.Padding(6);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(366, 33);
            this.cmbObjectType.TabIndex = 21;
            this.cmbObjectType.SelectedIndexChanged += new System.EventHandler(this.cmbObjectType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(22, 624);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 26);
            this.label1.TabIndex = 22;
            this.label1.Text = "Device Id (IoTHub registered device)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 276);
            this.panel1.TabIndex = 23;
            // 
            // checkBoxVariation
            // 
            this.checkBoxVariation.AutoSize = true;
            this.checkBoxVariation.Location = new System.Drawing.Point(22, 1138);
            this.checkBoxVariation.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxVariation.Name = "checkBoxVariation";
            this.checkBoxVariation.Size = new System.Drawing.Size(219, 29);
            this.checkBoxVariation.TabIndex = 24;
            this.checkBoxVariation.Text = "Add 10% variation";
            this.checkBoxVariation.UseVisualStyleBackColor = true;
            // 
            // lblSentCount
            // 
            this.lblSentCount.AutoSize = true;
            this.lblSentCount.Location = new System.Drawing.Point(556, 1176);
            this.lblSentCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSentCount.Name = "lblSentCount";
            this.lblSentCount.Size = new System.Drawing.Size(0, 25);
            this.lblSentCount.TabIndex = 25;
            // 
            // textDBConnectionString
            // 
            this.textDBConnectionString.Location = new System.Drawing.Point(14, 494);
            this.textDBConnectionString.Margin = new System.Windows.Forms.Padding(6);
            this.textDBConnectionString.Name = "textDBConnectionString";
            this.textDBConnectionString.Size = new System.Drawing.Size(792, 31);
            this.textDBConnectionString.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(22, 464);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "DB Connection String (Optional)";
            // 
            // cmbInstance
            // 
            this.cmbInstance.DropDownWidth = 185;
            this.cmbInstance.FormattingEnabled = true;
            this.cmbInstance.Location = new System.Drawing.Point(444, 994);
            this.cmbInstance.Margin = new System.Windows.Forms.Padding(6);
            this.cmbInstance.Name = "cmbInstance";
            this.cmbInstance.Size = new System.Drawing.Size(362, 33);
            this.cmbInstance.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(446, 960);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Instance";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(824, 1458);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbInstance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDBConnectionString);
            this.Controls.Add(this.lblSentCount);
            this.Controls.Add(this.checkBoxVariation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbObjectType);
            this.Controls.Add(this.cmbDeviceId);
            this.Controls.Add(this.cmbGatewayId);
            this.Controls.Add(this.cmbHubDevices);
            this.Controls.Add(this.btnGetDevices);
            this.Controls.Add(this.lblObjectType);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.labelGateway);
            this.Controls.Add(this.textAlerts);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.trackBarTemperature);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.textConnectionString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Building sensor simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textConnectionString;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TrackBar trackBarTemperature;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textAlerts;
        private System.Windows.Forms.Label labelGateway;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.Button btnGetDevices;
        private System.Windows.Forms.ComboBox cmbHubDevices;
        private System.Windows.Forms.ComboBox cmbGatewayId;
        private System.Windows.Forms.ComboBox cmbDeviceId;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxVariation;
        private System.Windows.Forms.Label lblSentCount;
        private System.Windows.Forms.TextBox textDBConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInstance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

