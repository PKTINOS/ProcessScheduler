using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduler
{
    class Program
    {
        static Random rand;
        public static List<Process> processes = new List<Process>();
        static void Main(string[] args)
        {
            rand = new Random();
            DataViewForm dvf = new DataViewForm();
            dvf.ShowDialog();
            Console.ReadLine();
        }
        public static void Clear()
        {
            System.Console.Clear();
        }
        public static void Out(string text)
        {
            System.Console.WriteLine("[~]: " + text);
        }
        static void Insert(Process process)
        {
            processes.Add(process);
        }
        static Process Pull()
        {
            int highest = 0;
            Process chosen = null;
            foreach (Process p in processes)
            {
                int priority = p.GetPriority();
                if (priority > highest)
                {
                    chosen = p;
                    highest = priority;
                }
            }
            if (chosen != null)
            processes.Remove(chosen);
            return chosen;
        }
    }
}
