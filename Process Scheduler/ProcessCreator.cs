using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessScheduler
{
    public partial class ProcessCreator : Form
    {
        public Process returnProcess;
        private int count;
        public ProcessCreator(int count)
        {
            this.count = count;
            InitializeComponent();
        }

        private void ProcessCreator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnProcess = new Process(count, (int)startTime.Value, (int)burstTime.Value, (int)priority.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
