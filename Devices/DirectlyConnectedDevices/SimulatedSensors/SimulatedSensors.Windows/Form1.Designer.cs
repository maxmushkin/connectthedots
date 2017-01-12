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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTemperature)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.textConnectionString.Size = new System.Drawing.Size(398, 55);
            this.textConnectionString.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SimulatedSensors.Windows.Properties.Resources.SBLogoMedium;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.ForeColor = System.Drawing.Color.White;
            this.labelDeviceName.Location = new System.Drawing.Point(35, 565);
            this.labelDeviceName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(229, 13);
            this.labelDeviceName.TabIndex = 3;
            this.labelDeviceName.Text = "DeviceInstance Id  (physical, not azure device)";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionString.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelConnectionString.Location = new System.Drawing.Point(11, 150);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(181, 13);
            this.labelConnectionString.TabIndex = 4;
            this.labelConnectionString.Text = "Connection String (of IoT Hub)";
            // 
            // trackBarTemperature
            // 
            this.trackBarTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTemperature.Location = new System.Drawing.Point(7, 537);
            this.trackBarTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarTemperature.Maximum = 100;
            this.trackBarTemperature.Name = "trackBarTemperature";
            this.trackBarTemperature.Size = new System.Drawing.Size(398, 45);
            this.trackBarTemperature.TabIndex = 7;
            this.trackBarTemperature.TabStop = false;
            this.trackBarTemperature.Value = 70;
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelTemperature.Location = new System.Drawing.Point(11, 525);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(82, 13);
            this.labelTemperature.TabIndex = 6;
            this.labelTemperature.Text = "PresentValue";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(143, 586);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(129, 19);
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
            this.textAlerts.Location = new System.Drawing.Point(7, 609);
            this.textAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.textAlerts.Multiline = true;
            this.textAlerts.Name = "textAlerts";
            this.textAlerts.ReadOnly = true;
            this.textAlerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textAlerts.Size = new System.Drawing.Size(398, 117);
            this.textAlerts.TabIndex = 11;
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGateway.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelGateway.Location = new System.Drawing.Point(11, 372);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(284, 13);
            this.labelGateway.TabIndex = 12;
            this.labelGateway.Text = "GatewayName (name of on premise IoT gateway)";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDevice.Location = new System.Drawing.Point(11, 424);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(357, 13);
            this.lblDevice.TabIndex = 14;
            this.lblDevice.Text = "DeviceName (name of on premise device sending to gateway)";
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjectType.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblObjectType.Location = new System.Drawing.Point(11, 480);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(72, 13);
            this.lblObjectType.TabIndex = 16;
            this.lblObjectType.Text = "ObjectType";
            // 
            // btnGetDevices
            // 
            this.btnGetDevices.Location = new System.Drawing.Point(143, 277);
            this.btnGetDevices.Name = "btnGetDevices";
            this.btnGetDevices.Size = new System.Drawing.Size(127, 23);
            this.btnGetDevices.TabIndex = 17;
            this.btnGetDevices.Text = "Get IoTHub Devices";
            this.btnGetDevices.UseVisualStyleBackColor = true;
            this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
            // 
            // cmbHubDevices
            // 
            this.cmbHubDevices.FormattingEnabled = true;
            this.cmbHubDevices.Location = new System.Drawing.Point(7, 328);
            this.cmbHubDevices.Name = "cmbHubDevices";
            this.cmbHubDevices.Size = new System.Drawing.Size(398, 21);
            this.cmbHubDevices.TabIndex = 18;
            this.cmbHubDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // cmbGatewayId
            // 
            this.cmbGatewayId.FormattingEnabled = true;
            this.cmbGatewayId.Location = new System.Drawing.Point(7, 388);
            this.cmbGatewayId.Name = "cmbGatewayId";
            this.cmbGatewayId.Size = new System.Drawing.Size(398, 21);
            this.cmbGatewayId.TabIndex = 19;
            this.cmbGatewayId.SelectedIndexChanged += new System.EventHandler(this.cmbGatewayId_SelectedIndexChanged);
            // 
            // cmbDeviceId
            // 
            this.cmbDeviceId.FormattingEnabled = true;
            this.cmbDeviceId.Location = new System.Drawing.Point(7, 441);
            this.cmbDeviceId.Name = "cmbDeviceId";
            this.cmbDeviceId.Size = new System.Drawing.Size(398, 21);
            this.cmbDeviceId.TabIndex = 20;
            this.cmbDeviceId.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceId_SelectedIndexChanged);
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(7, 497);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(185, 21);
            this.cmbObjectType.TabIndex = 21;
            this.cmbObjectType.SelectedIndexChanged += new System.EventHandler(this.cmbObjectType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(11, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Device Id (IoTHub registered device)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 139);
            this.panel1.TabIndex = 23;
            // 
            // checkBoxVariation
            // 
            this.checkBoxVariation.AutoSize = true;
            this.checkBoxVariation.Location = new System.Drawing.Point(11, 569);
            this.checkBoxVariation.Name = "checkBoxVariation";
            this.checkBoxVariation.Size = new System.Drawing.Size(111, 17);
            this.checkBoxVariation.TabIndex = 24;
            this.checkBoxVariation.Text = "Add 10% variation";
            this.checkBoxVariation.UseVisualStyleBackColor = true;
            // 
            // lblSentCount
            // 
            this.lblSentCount.AutoSize = true;
            this.lblSentCount.Location = new System.Drawing.Point(278, 588);
            this.lblSentCount.Name = "lblSentCount";
            this.lblSentCount.Size = new System.Drawing.Size(0, 13);
            this.lblSentCount.TabIndex = 25;
            // 
            // textDBConnectionString
            // 
            this.textDBConnectionString.Location = new System.Drawing.Point(7, 247);
            this.textDBConnectionString.Name = "textDBConnectionString";
            this.textDBConnectionString.Size = new System.Drawing.Size(398, 20);
            this.textDBConnectionString.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(11, 232);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "DB Connection String (Optional)";
            // 
            // cmbInstance
            // 
            this.cmbInstance.DropDownWidth = 185;
            this.cmbInstance.FormattingEnabled = true;
            this.cmbInstance.Location = new System.Drawing.Point(222, 497);
            this.cmbInstance.Name = "cmbInstance";
            this.cmbInstance.Size = new System.Drawing.Size(183, 21);
            this.cmbInstance.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(223, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Instance";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(412, 729);
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
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
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
    }
}

