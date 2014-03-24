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

        private Moda.Connection Connection;
        private Moda.RobotPHX Phx;

        private ProcessController Controller;

        private RobotType typeRobot = RobotType.STUPID;

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
            Controller.setRobot(typeRobot, Phx);

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
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            groupRobots.Enabled = true;
        }

        //##############################################################################

        public void SetMotorCheckResults(bool checkResult)
        {
            labelMotorStatus.Text = "Motor status: " + (checkResult ? "OK" : "Fail");
        }

        public void SetSensorCheckResults(bool checkResult)
        {
            labelSensorStatus.Text = "Motor status: " + (checkResult ? "OK" : "Fail");
        }

        public void SetMotorSpeed(float lm, float rm)
        {
            String text = ("Motor speed:\n               left: " + lm + "\n             right: " + rm);
            SetTextSafely(labelMotorSpeed, text);
        }

        public void SetSensorResults(float ld, float rd)
        {
            String text = ("Sensor results: \n                 left: " + ld + "\n               right: " + rd);
            SetTextSafely(labelSensorResults, text);
        }

        public void SetCurrentPosition(float positionX, float positionZ)
        {
            String text = ("Current position:  X: " + positionX + "  Z: " + positionZ);
            SetTextSafely(labelPosition, text);
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
        //#############################################################################
        private void radioStupidRobot_CheckedChanged(object sender, EventArgs e)
        {
            typeRobot = RobotType.STUPID;
        }
        
        private void radioSimpleNNRobot_CheckedChanged(object sender, EventArgs e)
        {
            typeRobot = RobotType.SIMPLE_NN;
        }

    }

}
