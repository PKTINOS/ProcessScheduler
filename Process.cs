using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduler
{
    public class Process
    {
        private int index;
        private int startTime;
        private int burstTime;
        private int priority;
        public List<Tuple<int,int>> completedParts = new List<Tuple<int, int>>();
        public Boolean Completed = false;
        public Boolean InQueue = false;
        private int completedTime = 0;
        public Process(int index, int startTime, int burstTime, int priority)
        {
            this.index = index;
            this.startTime = startTime;
            this.burstTime = burstTime;
            this.priority = priority;
        }
        public int GetId()
        {
            return index;
        }
        public int GetPriority()
        {
            return priority;
        }
        public int GetStartTime()
        {
            return startTime;
        }
        public int GetBurstTime()
        {
            return burstTime;
        }
        public void AddCompletedPart(int startTime, int endTime)
        {
            completedParts.Add(new Tuple<int, int>(startTime, endTime));
            completedTime += endTime;
            if (completedTime >= burstTime)
            {
                Completed = true;
                InQueue = false;
            }
        }
        public override string ToString()
        {
            return "Id:" + index + " start:" + startTime + " burst:" + burstTime + " prior:" + priority;
        }
    }
}
