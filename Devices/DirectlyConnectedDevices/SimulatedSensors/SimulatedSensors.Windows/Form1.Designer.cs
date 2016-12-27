namespace SimulatedSensors.Windows
{
    partial class Form1
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
            this.lblObjectTypeInstance = new System.Windows.Forms.Label();
            this.btnGetDevices = new System.Windows.Forms.Button();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.cmbGatewayId = new System.Windows.Forms.ComboBox();
            this.cmbDeviceId = new System.Windows.Forms.ComboBox();
            this.cmbObjectTypeInstance = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // textConnectionString
            // 
            this.textConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textConnectionString.Location = new System.Drawing.Point(7, 165);
            this.textConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.textConnectionString.Multiline = true;
            this.textConnectionString.Name = "textConnectionString";
            this.textConnectionString.Size = new System.Drawing.Size(396, 58);
            this.textConnectionString.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SimulatedSensors.Windows.Properties.Resources.CTDLogoMedium;
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.ForeColor = System.Drawing.Color.White;
            this.labelDeviceName.Location = new System.Drawing.Point(35, 517);
            this.labelDeviceName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(229, 13);
            this.labelDeviceName.TabIndex = 3;
            this.labelDeviceName.Text = "DeviceInstance Id  (physical, not azure device)";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.ForeColor = System.Drawing.Color.White;
            this.labelConnectionString.Location = new System.Drawing.Point(7, 150);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(139, 13);
            this.labelConnectionString.TabIndex = 4;
            this.labelConnectionString.Text = "Connection String (IoT Hub)";
            // 
            // trackBarTemperature
            // 
            this.trackBarTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTemperature.Location = new System.Drawing.Point(7, 485);
            this.trackBarTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarTemperature.Maximum = 100;
            this.trackBarTemperature.Name = "trackBarTemperature";
            this.trackBarTemperature.Size = new System.Drawing.Size(396, 45);
            this.trackBarTemperature.TabIndex = 7;
            this.trackBarTemperature.TabStop = false;
            this.trackBarTemperature.Value = 70;
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.ForeColor = System.Drawing.Color.White;
            this.labelTemperature.Location = new System.Drawing.Point(12, 474);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(34, 13);
            this.labelTemperature.TabIndex = 6;
            this.labelTemperature.Text = "Value";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(143, 542);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(127, 19);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "Send Data";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // textAlerts
            // 
            this.textAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAlerts.Location = new System.Drawing.Point(7, 565);
            this.textAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.textAlerts.Multiline = true;
            this.textAlerts.Name = "textAlerts";
            this.textAlerts.ReadOnly = true;
            this.textAlerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAlerts.Size = new System.Drawing.Size(398, 142);
            this.textAlerts.TabIndex = 11;
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.ForeColor = System.Drawing.Color.White;
            this.labelGateway.Location = new System.Drawing.Point(12, 324);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(61, 13);
            this.labelGateway.TabIndex = 12;
            this.labelGateway.Text = "Gateway Id";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.ForeColor = System.Drawing.Color.White;
            this.lblDevice.Location = new System.Drawing.Point(11, 376);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(94, 13);
            this.lblDevice.TabIndex = 14;
            this.lblDevice.Text = "DeviceInstance Id";
            // 
            // lblObjectTypeInstance
            // 
            this.lblObjectTypeInstance.AutoSize = true;
            this.lblObjectTypeInstance.ForeColor = System.Drawing.Color.White;
            this.lblObjectTypeInstance.Location = new System.Drawing.Point(11, 432);
            this.lblObjectTypeInstance.Name = "lblObjectTypeInstance";
            this.lblObjectTypeInstance.Size = new System.Drawing.Size(106, 13);
            this.lblObjectTypeInstance.TabIndex = 16;
            this.lblObjectTypeInstance.Text = "ObjectType Instance";
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(143, 228);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(127, 23);
            this.btnGetDevices.TabIndex = 17;
            this.btnGetDevices.Text = "Get IoTHub Devices";
            this.btnGetDevices.UseVisualStyleBackColor = true;
            this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(7, 261);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(392, 21);
            this.cmbDevices.TabIndex = 18;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // cmbGatewayId
            // 
            this.cmbGatewayId.FormattingEnabled = true;
            this.cmbGatewayId.Location = new System.Drawing.Point(11, 340);
            this.cmbGatewayId.Name = "cmbGatewayId";
            this.cmbGatewayId.Size = new System.Drawing.Size(396, 21);
            this.cmbGatewayId.TabIndex = 19;
            this.cmbGatewayId.SelectedIndexChanged += new System.EventHandler(this.cmbGatewayId_SelectedIndexChanged);
            // 
            // cmbDeviceId
            // 
            this.cmbDeviceId.FormattingEnabled = true;
            this.cmbDeviceId.Location = new System.Drawing.Point(11, 393);
            this.cmbDeviceId.Name = "cmbDeviceId";
            this.cmbDeviceId.Size = new System.Drawing.Size(396, 21);
            this.cmbDeviceId.TabIndex = 20;
            this.cmbDeviceId.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceId_SelectedIndexChanged);
            // 
            // cmbObjectTypeInstance
            // 
            this.cmbObjectTypeInstance.FormattingEnabled = true;
            this.cmbObjectTypeInstance.Location = new System.Drawing.Point(11, 449);
            this.cmbObjectTypeInstance.Name = "cmbObjectTypeInstance";
            this.cmbObjectTypeInstance.Size = new System.Drawing.Size(396, 21);
            this.cmbObjectTypeInstance.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Device Id (IoTHub term)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(410, 713);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbObjectTypeInstance);
            this.Controls.Add(this.cmbDeviceId);
            this.Controls.Add(this.cmbGatewayId);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.btnGetDevices);
            this.Controls.Add(this.lblObjectTypeInstance);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.labelGateway);
            this.Controls.Add(this.textAlerts);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.trackBarTemperature);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textConnectionString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Building sensor simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).EndInit();
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
        private System.Windows.Forms.Label lblObjectTypeInstance;
        private System.Windows.Forms.Button btnGetDevices;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.ComboBox cmbGatewayId;
        private System.Windows.Forms.ComboBox cmbDeviceId;
        private System.Windows.Forms.ComboBox cmbObjectTypeInstance;
        private System.Windows.Forms.Label label1;
    }
}

