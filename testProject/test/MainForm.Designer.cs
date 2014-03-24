namespace RobotSimulationController
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
            this.textBoxMODAServer = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMotorStatus = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelSensorStatus = new System.Windows.Forms.Label();
            this.labelSensorResults = new System.Windows.Forms.Label();
            this.labelMotorSpeed = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.groupRobots = new System.Windows.Forms.GroupBox();
            this.radioSimpleNNRobot = new System.Windows.Forms.RadioButton();
            this.radioStupidRobot = new System.Windows.Forms.RadioButton();
            this.textWeights = new System.Windows.Forms.TextBox();
            this.groupRobots.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMODAServer
            // 
            this.textBoxMODAServer.Location = new System.Drawing.Point(12, 34);
            this.textBoxMODAServer.Name = "textBoxMODAServer";
            this.textBoxMODAServer.Size = new System.Drawing.Size(240, 20);
            this.textBoxMODAServer.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(41, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Server:";
            // 
            // labelMotorStatus
            // 
            this.labelMotorStatus.AutoSize = true;
            this.labelMotorStatus.Location = new System.Drawing.Point(169, 73);
            this.labelMotorStatus.Name = "labelMotorStatus";
            this.labelMotorStatus.Size = new System.Drawing.Size(68, 13);
            this.labelMotorStatus.TabIndex = 1;
            this.labelMotorStatus.Text = "Motor status:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(280, 34);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(280, 236);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(280, 270);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelSensorStatus
            // 
            this.labelSensorStatus.AutoSize = true;
            this.labelSensorStatus.Location = new System.Drawing.Point(9, 73);
            this.labelSensorStatus.Name = "labelSensorStatus";
            this.labelSensorStatus.Size = new System.Drawing.Size(79, 13);
            this.labelSensorStatus.TabIndex = 6;
            this.labelSensorStatus.Text = "Sensors status:";
            // 
            // labelSensorResults
            // 
            this.labelSensorResults.AutoSize = true;
            this.labelSensorResults.Location = new System.Drawing.Point(9, 102);
            this.labelSensorResults.Name = "labelSensorResults";
            this.labelSensorResults.Size = new System.Drawing.Size(76, 13);
            this.labelSensorResults.TabIndex = 7;
            this.labelSensorResults.Text = "Sensor results:";
            // 
            // labelMotorSpeed
            // 
            this.labelMotorSpeed.AutoSize = true;
            this.labelMotorSpeed.Location = new System.Drawing.Point(158, 102);
            this.labelMotorSpeed.Name = "labelMotorSpeed";
            this.labelMotorSpeed.Size = new System.Drawing.Size(79, 13);
            this.labelMotorSpeed.TabIndex = 8;
            this.labelMotorSpeed.Text = "Motors speeds:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(9, 163);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(47, 13);
            this.labelPosition.TabIndex = 9;
            this.labelPosition.Text = "Position:";
            // 
            // groupRobots
            // 
            this.groupRobots.Controls.Add(this.radioSimpleNNRobot);
            this.groupRobots.Controls.Add(this.radioStupidRobot);
            this.groupRobots.Enabled = false;
            this.groupRobots.Location = new System.Drawing.Point(12, 222);
            this.groupRobots.Name = "groupRobots";
            this.groupRobots.Size = new System.Drawing.Size(240, 71);
            this.groupRobots.TabIndex = 10;
            this.groupRobots.TabStop = false;
            this.groupRobots.Text = "Robots";
            // 
            // radioSimpleNNRobot
            // 
            this.radioSimpleNNRobot.AutoSize = true;
            this.radioSimpleNNRobot.Location = new System.Drawing.Point(7, 43);
            this.radioSimpleNNRobot.Name = "radioSimpleNNRobot";
            this.radioSimpleNNRobot.Size = new System.Drawing.Size(107, 17);
            this.radioSimpleNNRobot.TabIndex = 2;
            this.radioSimpleNNRobot.Text = "Simple NN Robot";
            this.radioSimpleNNRobot.UseVisualStyleBackColor = true;
            this.radioSimpleNNRobot.CheckedChanged += new System.EventHandler(this.radioSimpleNNRobot_CheckedChanged);
            // 
            // radioStupidRobot
            // 
            this.radioStupidRobot.AutoSize = true;
            this.radioStupidRobot.Checked = true;
            this.radioStupidRobot.Location = new System.Drawing.Point(7, 20);
            this.radioStupidRobot.Name = "radioStupidRobot";
            this.radioStupidRobot.Size = new System.Drawing.Size(87, 17);
            this.radioStupidRobot.TabIndex = 0;
            this.radioStupidRobot.TabStop = true;
            this.radioStupidRobot.Text = "Stupid Robot";
            this.radioStupidRobot.UseVisualStyleBackColor = true;
            this.radioStupidRobot.CheckedChanged += new System.EventHandler(this.radioStupidRobot_CheckedChanged);
            // 
            // textWeights
            // 
            this.textWeights.AcceptsReturn = true;
            this.textWeights.Location = new System.Drawing.Point(370, 32);
            this.textWeights.Multiline = true;
            this.textWeights.Name = "textWeights";
            this.textWeights.ReadOnly = true;
            this.textWeights.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textWeights.Size = new System.Drawing.Size(121, 261);
            this.textWeights.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 314);
            this.Controls.Add(this.textWeights);
            this.Controls.Add(this.groupRobots);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelMotorSpeed);
            this.Controls.Add(this.labelSensorResults);
            this.Controls.Add(this.labelSensorStatus);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelMotorStatus);
            this.Controls.Add(this.textBoxMODAServer);
            this.Name = "MainForm";
            this.Text = "Mega robot controller";
            this.groupRobots.ResumeLayout(false);
            this.groupRobots.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxMODAServer;
		private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMotorStatus;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelSensorStatus;
        private System.Windows.Forms.Label labelSensorResults;
        private System.Windows.Forms.Label labelMotorSpeed;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.GroupBox groupRobots;
        private System.Windows.Forms.RadioButton radioStupidRobot;
        private System.Windows.Forms.RadioButton radioSimpleNNRobot;
        private System.Windows.Forms.TextBox textWeights;
	}
}

