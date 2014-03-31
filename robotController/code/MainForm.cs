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

namespace RobotSimulationController
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(Label label, string text);
        delegate void SetButtonTextCallback(Button label, string text);

        private Moda.Connection Connection;
        private Moda.RobotPHX Phx;

        private ProcessController Controller;

        private RobotType typeRobot = RobotType.SIMPLE_NN;

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
                        groupRobots.Enabled = true;
                        buttonStart.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Unable to connected to MODA server " + textBoxMODAServer.Text);
            }
        }

        private void prepareNewController()
        {
            Controller = new ProcessController(this);
            Controller.SetRobotType(typeRobot, Phx);
        }

        //####################################################################
        protected void buttonStart_Click(object sender, EventArgs e)
        {
            prepareNewController();
            Controller.start(Connection);

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            groupRobots.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Controller.stop();
            buttonStop.Enabled = false;
            buttonStop.Text = "Finishing...";
            buttonStart.Enabled = true;
            groupRobots.Enabled = true;
        }

        //##############################################################################

        public void EvolutionStop()
        {
            SetButtonTextSafely(buttonStop, "Stop");
        }

        public void AddGenerationInfo(string s)
        {
            AppendTextBox(s + "\r\n");
        }

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

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            textWeights.Text += value;
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

        private void radioSimpleNNRobot_CheckedChanged(object sender, EventArgs e)
        {
            typeRobot = RobotType.SIMPLE_NN;
        }
        
    }

}
