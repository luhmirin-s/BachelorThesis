using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Moda;
using RobotSimulationController.GA;
using RobotSimulationController.Properties;

namespace RobotSimulationController
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(Label label, string text);
        delegate void SetButtonTextCallback(Button label, string text);

        private Moda.Connection Connection;
        private Moda.RobotPHX Phx;

        private ProcessController Controller;

        private RobotType RobotType = RobotType.SIMPLE_NN;

        public MainForm()
        {
            InitializeComponent();
            textBoxMODAServer.Text = Constants.DEFAULT_IP;
            Connection = null;
            Phx = null;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (textBoxMODAServer.Text.Length != 0)
            {
                if (Connection != null)
                {
                    //close the current connection
                    Connection.Disconnect();
                    Connection = null;
                    Phx = null;
                }

                Connection = new Moda.Connection(true);
                if (Connection.Connect(textBoxMODAServer.Text))
                {
                    Phx = Connection.QueryRobotPHX(Constants.ROBOT_PHX);
                    if (Phx == null)
                    {
                        MessageBox.Show("Connected to MODA server " + textBoxMODAServer.Text + ", /phx0 not found");
                    }
                    else
                    {
                        buttonConnect.Enabled = false;
                        buttonConnect.Text = "Connected";
                        buttonStart.Enabled = true;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Unable to connected to MODA server " + textBoxMODAServer.Text);
                }
            }
            else
            {
                MessageBox.Show("Unable to connected to MODA server " + textBoxMODAServer.Text);
            }
        }

        private void PrepareNewController()
        {
            Controller = new ProcessController();
            Controller.SetRobotType(RobotType, Phx);
        }

        //####################################################################
        protected void buttonStart_Click(object sender, EventArgs e)
        {
            Settings.Default.UsedNN = comboRobot.SelectedIndex;
            Settings.Default.UsedActivationFunction = comboActivation.SelectedIndex;
            Settings.Default.UsedFitnessFunction = comboFitness.SelectedIndex;
            Settings.Default.UsedMutation = comboMutation.SelectedIndex;
            Settings.Default.UsedCrossover = comboCrossover.SelectedIndex;

            Settings.Default.GenerationCount = int.Parse(textGenerationCount.Text);
            Settings.Default.GenerationLifeTime = int.Parse(textLifeTime.Text);
            Settings.Default.PopulationSize = int.Parse(textPopulationSize.Text);
            Settings.Default.MutationProbability = double.Parse(textMutationProbability.Text);
            Settings.Default.EliteSize = int.Parse(textEliteSize.Text);

            groupParameters.Enabled = false;
            groupTypes.Enabled = false;

            PrepareNewController();
            Controller.Start(Connection);

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Controller.Stop();
            buttonStop.Enabled = false;
            buttonStop.Text = "Finishing...";
            buttonStart.Enabled = true;

            groupParameters.Enabled = true;
            groupTypes.Enabled = true;
        }

        //##############################################################################

        private void SetTextSafely(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextSafely);
                Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        private void SetButtonTextSafely(Button button, string text)
        {
            if (button.InvokeRequired)
            {
                SetButtonTextCallback d = new SetButtonTextCallback(SetButtonTextSafely);
                Invoke(d, new object[] { button, text });
            }
            else
            {
                button.Text = text;
            }
        }

        //#############################################################################

    }

}
