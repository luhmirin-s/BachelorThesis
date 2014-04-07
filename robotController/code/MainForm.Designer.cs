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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.comboRobot = new System.Windows.Forms.ComboBox();
            this.labelRobotCombo = new System.Windows.Forms.Label();
            this.comboCrossover = new System.Windows.Forms.ComboBox();
            this.comboMutation = new System.Windows.Forms.ComboBox();
            this.comboFitness = new System.Windows.Forms.ComboBox();
            this.comboActivation = new System.Windows.Forms.ComboBox();
            this.labelActivation = new System.Windows.Forms.Label();
            this.labelCrossover = new System.Windows.Forms.Label();
            this.labelMutation = new System.Windows.Forms.Label();
            this.labelFitness = new System.Windows.Forms.Label();
            this.groupTypes = new System.Windows.Forms.GroupBox();
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.textGenerationCount = new System.Windows.Forms.MaskedTextBox();
            this.textLifeTime = new System.Windows.Forms.MaskedTextBox();
            this.textPopulationSize = new System.Windows.Forms.MaskedTextBox();
            this.textMutationProbability = new System.Windows.Forms.MaskedTextBox();
            this.textEliteSize = new System.Windows.Forms.MaskedTextBox();
            this.labelGenerationCount = new System.Windows.Forms.Label();
            this.labelLifeTime = new System.Windows.Forms.Label();
            this.labelPopulationSize = new System.Windows.Forms.Label();
            this.labelEliteSize = new System.Windows.Forms.Label();
            this.labelMutationProbability = new System.Windows.Forms.Label();
            this.groupTypes.SuspendLayout();
            this.groupParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMODAServer
            // 
            this.textBoxMODAServer.Location = new System.Drawing.Point(59, 14);
            this.textBoxMODAServer.Name = "textBoxMODAServer";
            this.textBoxMODAServer.Size = new System.Drawing.Size(179, 20);
            this.textBoxMODAServer.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(9, 17);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(41, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Server:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(245, 12);
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
            this.buttonStart.Location = new System.Drawing.Point(12, 401);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(153, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(167, 401);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(153, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // comboRobot
            // 
            this.comboRobot.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboRobot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboRobot.FormattingEnabled = true;
            this.comboRobot.Items.AddRange(new object[] {
            "Simple - One Layer"});
            this.comboRobot.Location = new System.Drawing.Point(134, 19);
            this.comboRobot.Name = "comboRobot";
            this.comboRobot.Size = new System.Drawing.Size(163, 21);
            this.comboRobot.TabIndex = 6;
            // 
            // labelRobotCombo
            // 
            this.labelRobotCombo.AutoSize = true;
            this.labelRobotCombo.Location = new System.Drawing.Point(11, 22);
            this.labelRobotCombo.Name = "labelRobotCombo";
            this.labelRobotCombo.Size = new System.Drawing.Size(49, 13);
            this.labelRobotCombo.TabIndex = 7;
            this.labelRobotCombo.Text = "NN type:";
            // 
            // comboCrossover
            // 
            this.comboCrossover.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboCrossover.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboCrossover.FormattingEnabled = true;
            this.comboCrossover.Items.AddRange(new object[] {
            "Uniform with elite"});
            this.comboCrossover.Location = new System.Drawing.Point(134, 73);
            this.comboCrossover.Name = "comboCrossover";
            this.comboCrossover.Size = new System.Drawing.Size(163, 21);
            this.comboCrossover.TabIndex = 8;
            // 
            // comboMutation
            // 
            this.comboMutation.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboMutation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboMutation.FormattingEnabled = true;
            this.comboMutation.Items.AddRange(new object[] {
            "Random bit flip"});
            this.comboMutation.Location = new System.Drawing.Point(134, 100);
            this.comboMutation.Name = "comboMutation";
            this.comboMutation.Size = new System.Drawing.Size(163, 21);
            this.comboMutation.TabIndex = 9;
            // 
            // comboFitness
            // 
            this.comboFitness.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboFitness.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboFitness.FormattingEnabled = true;
            this.comboFitness.Items.AddRange(new object[] {
            "Max position",
            "Complicated"});
            this.comboFitness.Location = new System.Drawing.Point(134, 127);
            this.comboFitness.Name = "comboFitness";
            this.comboFitness.Size = new System.Drawing.Size(163, 21);
            this.comboFitness.TabIndex = 10;
            // 
            // comboActivation
            // 
            this.comboActivation.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboActivation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboActivation.FormattingEnabled = true;
            this.comboActivation.Items.AddRange(new object[] {
            "Classic Sigmoid",
            "Modified Sigmoid"});
            this.comboActivation.Location = new System.Drawing.Point(134, 46);
            this.comboActivation.Name = "comboActivation";
            this.comboActivation.Size = new System.Drawing.Size(163, 21);
            this.comboActivation.TabIndex = 11;
            // 
            // labelActivation
            // 
            this.labelActivation.AutoSize = true;
            this.labelActivation.Location = new System.Drawing.Point(11, 49);
            this.labelActivation.Name = "labelActivation";
            this.labelActivation.Size = new System.Drawing.Size(121, 13);
            this.labelActivation.TabIndex = 12;
            this.labelActivation.Text = "Activation function type:";
            // 
            // labelCrossover
            // 
            this.labelCrossover.AutoSize = true;
            this.labelCrossover.Location = new System.Drawing.Point(11, 76);
            this.labelCrossover.Name = "labelCrossover";
            this.labelCrossover.Size = new System.Drawing.Size(80, 13);
            this.labelCrossover.TabIndex = 13;
            this.labelCrossover.Text = "Crossover type:";
            // 
            // labelMutation
            // 
            this.labelMutation.AutoSize = true;
            this.labelMutation.Location = new System.Drawing.Point(11, 103);
            this.labelMutation.Name = "labelMutation";
            this.labelMutation.Size = new System.Drawing.Size(74, 13);
            this.labelMutation.TabIndex = 14;
            this.labelMutation.Text = "Mutation type:";
            // 
            // labelFitness
            // 
            this.labelFitness.AutoSize = true;
            this.labelFitness.Location = new System.Drawing.Point(11, 130);
            this.labelFitness.Name = "labelFitness";
            this.labelFitness.Size = new System.Drawing.Size(107, 13);
            this.labelFitness.TabIndex = 15;
            this.labelFitness.Text = "Fitness function type:";
            // 
            // groupTypes
            // 
            this.groupTypes.Controls.Add(this.labelRobotCombo);
            this.groupTypes.Controls.Add(this.labelFitness);
            this.groupTypes.Controls.Add(this.comboRobot);
            this.groupTypes.Controls.Add(this.labelMutation);
            this.groupTypes.Controls.Add(this.comboCrossover);
            this.groupTypes.Controls.Add(this.labelCrossover);
            this.groupTypes.Controls.Add(this.comboMutation);
            this.groupTypes.Controls.Add(this.labelActivation);
            this.groupTypes.Controls.Add(this.comboFitness);
            this.groupTypes.Controls.Add(this.comboActivation);
            this.groupTypes.Location = new System.Drawing.Point(12, 41);
            this.groupTypes.Name = "groupTypes";
            this.groupTypes.Size = new System.Drawing.Size(308, 158);
            this.groupTypes.TabIndex = 16;
            this.groupTypes.TabStop = false;
            // 
            // groupParameters
            // 
            this.groupParameters.Controls.Add(this.labelMutationProbability);
            this.groupParameters.Controls.Add(this.labelEliteSize);
            this.groupParameters.Controls.Add(this.labelPopulationSize);
            this.groupParameters.Controls.Add(this.labelLifeTime);
            this.groupParameters.Controls.Add(this.labelGenerationCount);
            this.groupParameters.Controls.Add(this.textEliteSize);
            this.groupParameters.Controls.Add(this.textMutationProbability);
            this.groupParameters.Controls.Add(this.textPopulationSize);
            this.groupParameters.Controls.Add(this.textLifeTime);
            this.groupParameters.Controls.Add(this.textGenerationCount);
            this.groupParameters.Location = new System.Drawing.Point(12, 205);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(308, 181);
            this.groupParameters.TabIndex = 17;
            this.groupParameters.TabStop = false;
            // 
            // textGenerationCount
            // 
            this.textGenerationCount.Location = new System.Drawing.Point(254, 19);
            this.textGenerationCount.Mask = "00000";
            this.textGenerationCount.Name = "textGenerationCount";
            this.textGenerationCount.Size = new System.Drawing.Size(43, 20);
            this.textGenerationCount.TabIndex = 1;
            this.textGenerationCount.ValidatingType = typeof(int);
            // 
            // textLifeTime
            // 
            this.textLifeTime.Location = new System.Drawing.Point(254, 45);
            this.textLifeTime.Mask = "00000";
            this.textLifeTime.Name = "textLifeTime";
            this.textLifeTime.Size = new System.Drawing.Size(43, 20);
            this.textLifeTime.TabIndex = 2;
            this.textLifeTime.ValidatingType = typeof(int);
            // 
            // textPopulationSize
            // 
            this.textPopulationSize.Location = new System.Drawing.Point(254, 71);
            this.textPopulationSize.Mask = "00000";
            this.textPopulationSize.Name = "textPopulationSize";
            this.textPopulationSize.Size = new System.Drawing.Size(43, 20);
            this.textPopulationSize.TabIndex = 3;
            this.textPopulationSize.ValidatingType = typeof(int);
            // 
            // textMutationProbability
            // 
            this.textMutationProbability.Location = new System.Drawing.Point(254, 123);
            this.textMutationProbability.Mask = "\\0.00";
            this.textMutationProbability.Name = "textMutationProbability";
            this.textMutationProbability.Size = new System.Drawing.Size(43, 20);
            this.textMutationProbability.TabIndex = 4;
            // 
            // textEliteSize
            // 
            this.textEliteSize.Location = new System.Drawing.Point(254, 97);
            this.textEliteSize.Mask = "00000";
            this.textEliteSize.Name = "textEliteSize";
            this.textEliteSize.Size = new System.Drawing.Size(43, 20);
            this.textEliteSize.TabIndex = 6;
            this.textEliteSize.ValidatingType = typeof(int);
            // 
            // labelGenerationCount
            // 
            this.labelGenerationCount.AutoSize = true;
            this.labelGenerationCount.Location = new System.Drawing.Point(11, 22);
            this.labelGenerationCount.Name = "labelGenerationCount";
            this.labelGenerationCount.Size = new System.Drawing.Size(113, 13);
            this.labelGenerationCount.TabIndex = 16;
            this.labelGenerationCount.Text = "Max generation count:";
            // 
            // labelLifeTime
            // 
            this.labelLifeTime.AutoSize = true;
            this.labelLifeTime.Location = new System.Drawing.Point(11, 48);
            this.labelLifeTime.Name = "labelLifeTime";
            this.labelLifeTime.Size = new System.Drawing.Size(127, 13);
            this.labelLifeTime.TabIndex = 17;
            this.labelLifeTime.Text = "Generation life time in ms:";
            // 
            // labelPopulationSize
            // 
            this.labelPopulationSize.AutoSize = true;
            this.labelPopulationSize.Location = new System.Drawing.Point(11, 74);
            this.labelPopulationSize.Name = "labelPopulationSize";
            this.labelPopulationSize.Size = new System.Drawing.Size(81, 13);
            this.labelPopulationSize.TabIndex = 18;
            this.labelPopulationSize.Text = "Population size:";
            // 
            // labelEliteSize
            // 
            this.labelEliteSize.AutoSize = true;
            this.labelEliteSize.Location = new System.Drawing.Point(11, 100);
            this.labelEliteSize.Name = "labelEliteSize";
            this.labelEliteSize.Size = new System.Drawing.Size(51, 13);
            this.labelEliteSize.TabIndex = 19;
            this.labelEliteSize.Text = "Elite size:";
            // 
            // labelMutationProbability
            // 
            this.labelMutationProbability.AutoSize = true;
            this.labelMutationProbability.Location = new System.Drawing.Point(11, 126);
            this.labelMutationProbability.Name = "labelMutationProbability";
            this.labelMutationProbability.Size = new System.Drawing.Size(101, 13);
            this.labelMutationProbability.TabIndex = 20;
            this.labelMutationProbability.Text = "Mutation probability:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 436);
            this.Controls.Add(this.groupParameters);
            this.Controls.Add(this.groupTypes);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxMODAServer);
            this.Name = "MainForm";
            this.Text = "Mega robot controller";
            this.groupTypes.ResumeLayout(false);
            this.groupTypes.PerformLayout();
            this.groupParameters.ResumeLayout(false);
            this.groupParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxMODAServer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboRobot;
        private System.Windows.Forms.Label labelRobotCombo;
        private System.Windows.Forms.ComboBox comboCrossover;
        private System.Windows.Forms.ComboBox comboMutation;
        private System.Windows.Forms.ComboBox comboFitness;
        private System.Windows.Forms.ComboBox comboActivation;
        private System.Windows.Forms.Label labelActivation;
        private System.Windows.Forms.Label labelCrossover;
        private System.Windows.Forms.Label labelMutation;
        private System.Windows.Forms.Label labelFitness;
        private System.Windows.Forms.GroupBox groupTypes;
        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.MaskedTextBox textLifeTime;
        private System.Windows.Forms.MaskedTextBox textGenerationCount;
        private System.Windows.Forms.MaskedTextBox textPopulationSize;
        private System.Windows.Forms.MaskedTextBox textMutationProbability;
        private System.Windows.Forms.Label labelGenerationCount;
        private System.Windows.Forms.MaskedTextBox textEliteSize;
        private System.Windows.Forms.Label labelMutationProbability;
        private System.Windows.Forms.Label labelEliteSize;
        private System.Windows.Forms.Label labelPopulationSize;
        private System.Windows.Forms.Label labelLifeTime;
	}
}

