using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster
{
    internal class TaskList
    {
        //A list that contains tasks. Also has methods to display the list.
        public TaskList(List<Task> tasks)
        {
            this.tasks = tasks;
        }

        public List<Task> tasks {  get; set; }

        public void Add(Task task)
        {
            tasks.Add(task);
        }

        public void DisplayByDate()
        {
            //Sorts the list by date and displays it
            List<Task> sortedList = tasks.OrderBy(t => t.DueDate).ToList();
            Display(sortedList);
        }

        public void DisplayByProject()
        {
            //Sorts the list by project,then by date and displays it
            List<Task> sortedList = tasks.OrderBy(t => t.Project).ThenBy(t => t.DueDate).ToList();
            Display(sortedList);
        }

        void Display(List<Task> displayList)
        {
            //Displays the list after it has been sorted by one of the public display methods
            ColoredText.WriteLine("\n"+"TITLE:".PadRight(16) + "PROJECT:".PadRight(16) + "DUE DATE:".PadRight(16) + "STATUS:",
                                        ConsoleColor.DarkBlue);

            foreach (Task t in displayList)
            {
                //Display each task. Check whether the task is complete or overdue, set color and text to indicate if so.
                string statusString;
                if (t.Completed)
                {
                    statusString = "Completed";
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (t.DueDate < DateTime.Now)
                {
                    statusString = "Overdue!";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else statusString = "";
                
                Console.WriteLine(t.Title.PadRight(16) + t.Project.PadRight(16) + t.DueDate.ToString("d").PadRight(16) + statusString);
                Console.ResetColor();
            }
            Console.WriteLine("");
        }
    }
}
