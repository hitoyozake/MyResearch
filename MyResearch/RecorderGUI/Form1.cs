using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace RecorderGUI
{
    public partial class Form1 : Form
    {
        bool debug_mode = false;
        String recorder_name = @"./kinectrecorder.exe";
        Process recorder = null;

        enum Mode : int
        {
            E_STOP = 0,
            E_RECORD = 1
        };

        Mode state = Mode.E_STOP;

        public Form1()
        {
            InitializeComponent();
        }

        void stop_recorder()
        {

        }

        void prepare_recorder()
        {
            if (recorder != null)
            {
                //終了させる   
            }
            recorder = new Process();
            recorder.StartInfo.UseShellExecute = false;
            recorder.StartInfo.RedirectStandardInput = true;
            recorder.StartInfo.RedirectStandardOutput = true;
            recorder.StartInfo.FileName = recorder_name;

            recorder.Start();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Shiftを押しながらクリックするとデバッグモード
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                debug_mode = true;
            }
            else
            {
                debug_mode = false;
            }

            if (state == Mode.E_STOP)
            {
                state = Mode.E_RECORD;
            }
            else
            {
                state = Mode.E_STOP;
            }
        }
    }
}
