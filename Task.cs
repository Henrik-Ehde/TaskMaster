namespace TaskMaster
{
    internal class Task
    {
        //Contains information about a task as well as a method that let's users create a task.
        public string Title { get; set; }
        public string Project { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }


        public Task(string title, string project, string dueDate,  bool completed)
        {
            //Constructor that recieves a string for date and tries to parse it to create a DateTime. Used to populate list.
            try
            {
                DateTime date = DateTime.Parse(dueDate);
                DueDate = date;
            }
            catch (Exception)
            {
                Console.WriteLine("Error: A date was entered incorrectly");
            }
            Title = title;
            Project = project;
            Completed = completed;
        }

        //Constructor that recieves a Datetime.
        public Task(string title, string project, DateTime dueDate, bool completed)
        {
            Title = title;
            Project = project;
            DueDate = dueDate; 
            Completed = completed;
        }


        //Let's the user create a new task by entering information.
        public static void CreateTask()
        {
            string titleInput;
            ColoredText.WriteLine("Enter a title for your task", ConsoleColor.Yellow);
            while (true)
            {
                Console.Write("Title: ");
                titleInput = Console.ReadLine();
                if (titleInput == "") ColoredText.WriteLine("You must enter a title for the task", ConsoleColor.Red);
                else break;
            }


            ColoredText.WriteLine("Is the task part of a project? If it is not, leave empty and press enter to continue", ConsoleColor.Yellow);
            Console.Write("Project: ");
            string projectInput = Console.ReadLine();

            DateTime date;
            ColoredText.WriteLine("Enter a due date for your task", ConsoleColor.Yellow);
            while (true)
            {
                try
                {
                    Console.Write("Due Date: ");
                    string dateInput = Console.ReadLine();
                    date = DateTime.Parse(dateInput);
                    break;
                }
                catch (Exception)
                {
                    ColoredText.WriteLine("You did not enter a valid date", ConsoleColor.Red);
                }
            }

            TaskList.Add(new Task(titleInput, projectInput, date, false));
            ColoredText.WriteLine("The task has been added\n", ConsoleColor.Green);



        }

    }


}
