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
    public partial class DataViewForm : Form
    {
        private Random rand;
        private List<Process> processes;
        private List<int> processQueue = new List<int>();
        private Brush b = new SolidBrush(Color.Black);
        private Brush sel_b = new SolidBrush(Color.Blue);
        private int selectedIndex = -1;
        private int currentTime = 0;

        public DataViewForm()
        {
            InitializeComponent();
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            rand = new Random();
            processes = new List<Process>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearProcessList();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Program.Out("Removed process with id: " + deleteSelected());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (processNum.Value < 1)
            {
                MessageBox.Show("Ο αριθμός διεργασιών πρέπει να είναι > 1.");
                Program.Out("Error: process no. must be higher than 1.");
                return;
            }
            clearProcessList();
            for (int i = 0; i < processNum.Value; i++)
            {
                int startTime = rand.Next(0, 100);
                if (i == 0)
                    startTime = 0;
                int burstTime = rand.Next(10, 50);
                int priority = rand.Next(1, 8);
                Process p = new Process(i, startTime, burstTime, priority);
                Program.Out("Generated process: " + p.ToString());
                listBox1.Items.Add(p.ToString());
                processes.Add(p);
            }
            Refresh();
        }

        private void clearProcessList()
        {
            currentTime = 0;
            processQueue.Clear();
            listBox2.Items.Clear();
            foreach (Process p in processes)
            {
                p.completedParts.Clear();
                p.InQueue = false;
                p.Completed = false;
            }
            listBox1.Items.Clear();
            processes.Clear();
            Program.Clear();
            Program.Out("Cleared process list");
            Refresh();
        }

        private int deleteSelected()
        {
            int sel = listBox1.SelectedIndex;
            int id = processes.ElementAt(sel).GetId();
            processes.RemoveAt(sel);
            listBox1.Items.RemoveAt(sel);
            Refresh();
            return id;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int i = 0;

            foreach (Process p in processes)
            {
                if (!p.InQueue && !p.Completed)
                {
                    if (p.GetId() == selectedIndex)
                        g.FillRectangle(sel_b, p.GetStartTime(), 20 + i * 11, p.GetBurstTime(), 9);
                    else
                        g.FillRectangle(b, p.GetStartTime(), 20 + i * 11, p.GetBurstTime(), 9);
                }
                if (p.Completed)
                {
                    if (p.completedParts.Count() > 0)
                    {
                        foreach (Tuple<int, int> tuple in p.completedParts)
                        {
                            g.FillRectangle(Brushes.DarkGreen, tuple.Item1, 20 + processes.IndexOf(p) * 11, tuple.Item2, 9);
                        }
                    }
                }
                i++;
            }
            foreach(int j in processQueue)
            {
                if (processes.ElementAt(j).InQueue) {
                    if (processes.ElementAt(j).completedParts.Count() > 0)
                    {
                        foreach (Tuple<int, int> tuple in processes.ElementAt(j).completedParts)
                        {
                            g.FillRectangle(Brushes.DarkGreen, tuple.Item1, 20 + processes.IndexOf(processes.ElementAt(j)) * 11, tuple.Item2, 9);
                        }
                    }
                }
            }
            g.DrawLine(Pens.White, 0, 19, 223, 19);
            g.DrawLine(Pens.White, currentTime, 0, currentTime, 224);
        }
        
        private void Refresh()
        {
            pictureBox1.Refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            selectedIndex = int.Parse(listBox1.SelectedItem.ToString().Split(':')[1].Split(' ')[0]);
            Refresh();
        }

        private void scheduleTimer_Tick(object sender, EventArgs e)
        {
            int previousTime = currentTime;
            currentTime += (int)timeQuantum.Value;
            foreach (Process p in processes)
            {
                if (currentTime > p.GetStartTime())
                {
                    if (!p.Completed && !p.InQueue)
                    {
                        processQueue.Add(p.GetId());
                        listBox2.Items.Add(p.GetId());
                        p.InQueue = true;
                    } else if (p.Completed && processQueue.Contains(p.GetId()) && processQueue.Count() > 0)
                    {
                        try
                        {
                            processQueue.Remove(p.GetId());
                            listBox2.Items.Remove(p.GetId());
                        }
                        catch
                        {
                            MessageBox.Show("error: " + p.GetId() + " count: " + processQueue.Count());
                        }
                    }
                }
            }
            if (processQueue.Count > 0)
            {
                processes.ElementAt(getHighestProcess()).AddCompletedPart(previousTime, (int)timeQuantum.Value);
            }
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduleTimer_Tick(null, null);
        }

        private int getHighestProcess()
        {
            int min = 9;
            int min_id = -1;
            foreach (int i in processQueue)
            {
                Process p = getProcessById(i);
                if (p.GetPriority() < min)
                {
                    min = p.GetPriority();
                    min_id = p.GetId();
                }
            }
            return min_id;
        }

        private Process getProcessById(int id)
        {
            foreach(Process p in processes)
            {
                if (p.GetId() == id)
                    return p;
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTime = 0;
            processQueue.Clear();
            listBox2.Items.Clear();
            foreach(Process p in processes)
            {
                p.completedParts.Clear();
                p.InQueue = false;
                p.Completed = false;
            }
            Refresh();
        }

        private void processWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProcessCreator form = new ProcessCreator(processes.Count())) {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    processes.Add(form.returnProcess);
                    listBox1.Items.Add(form.returnProcess.ToString());
                }
                Refresh();
            }
        }
    }
}
