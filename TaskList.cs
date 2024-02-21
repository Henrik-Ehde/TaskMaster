namespace TaskMaster
{
    static internal class TaskList
    {
        //A list that contains tasks. Also has methods to display the list.

        public static List<Task> tasks {  get; set; }

        static public void Add(Task task)
        {
            tasks.Add(task);
        }

        static public void DisplayByDate()
        {
            //Sorts the list by date and displays it
            List<Task> sortedList = tasks.OrderBy(t => t.DueDate).ToList();
            Display(sortedList);
        }

        static public void DisplayByProject()
        {
            //Sorts the list by project,then by date and displays it
            List<Task> sortedList = tasks.OrderBy(t => t.Project).ThenBy(t => t.DueDate).ToList();
            Display(sortedList);
        }

        static void Display(List<Task> displayList)
        {
            //Displays the list after it has been sorted by one of the public display methods
            ColoredText.WriteLine("TITLE:".PadRight(24) + "PROJECT:".PadRight(16) + "DUE DATE:".PadRight(16) + "STATUS:",
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
                
                Console.WriteLine(t.Title.PadRight(24) + t.Project.PadRight(16) + t.DueDate.ToString("d").PadRight(16) + statusString);
                Console.ResetColor();
            }
            Console.WriteLine("");
        }
    }
}
