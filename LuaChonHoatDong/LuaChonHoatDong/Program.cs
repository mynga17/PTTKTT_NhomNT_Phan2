using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaChonHoatDong
{
    class Activity
    {
        public int start;
        public int finish;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Activity[] activities = {
            new Activity { start = 1, finish = 3 },
            new Activity { start = 2, finish = 4 },
            new Activity { start = 3, finish = 5 },
            new Activity { start = 4, finish = 6 },
            new Activity { start = 5, finish = 7 },
            new Activity { start = 5, finish = 9 },
            new Activity { start = 6, finish = 10 }
        };
            Array.Sort(activities, (a, b) => a.finish.CompareTo(b.finish));

            int selectedActivities = 0;
            int lastFinishTime = 0;

            Console.WriteLine("Cac hoat dong đuoc chon:");
            for (int i = 0; i < activities.Length; i++)
            {
                if (activities[i].start >= lastFinishTime)
                {
                    Console.WriteLine("Hoat đong {i + 1}: bat đau luc {activities[i].start} va ket thuc luc {activities[i].finish}");
                    selectedActivities++;
                    lastFinishTime = activities[i].finish;
                }
            }

            Console.WriteLine("So luong hoat dong duoc chon: {selectedActivities}");
        }
    }
}

