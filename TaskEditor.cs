namespace TaskMaster
{
    static internal class TaskEditor
    {
        //Used to edit previously created tasks.

        static int selectedTask;
        static public Option completeOption = new Option("Mark as Completed", TaskEditor.MarkAsComplete);
        static public Option uncompleteOption = new Option("Mark as NOT Completed", TaskEditor.MarkAsIncomplete);
        public static void PickTask()
        {
            //Displays the list of tasks and asks the user which one to edit
            //Stores the number of the selected task in selectedTask, then opens the Task Menu to select what to do with it.

            ColoredText.WriteLine("Pick a task to edit", ConsoleColor.Yellow);
            for (int i = 0; i < TaskList.tasks.Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + TaskList.tasks[i].Title);
            }

            while (true)
            {
                //Loops until the user inputs a valid number
                Console.Write("Task: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out selectedTask) && selectedTask > 0 && selectedTask <= TaskList.tasks.Count) break;
                else ColoredText.WriteLine("You did not enter the number of an existing task", ConsoleColor.Red);
            }
            selectedTask--;

            //If the task is uncompleted the user will have the option to mark as complete. Otherwise they'll may mark it as uncompleted.
            if (TaskList.tasks[selectedTask].Completed) Menus.TaskMenu.Options[0] = uncompleteOption;
            else Menus.TaskMenu.Options[0] = completeOption;

            Console.WriteLine("");
            Menus.TaskMenu.Open();
        }

        public static void Delete()
        {
            TaskList.tasks.RemoveAt(selectedTask);
            ColoredText.WriteLine("Task deleted\n", ConsoleColor.Green);
        }
        public static void MarkAsComplete() 
        {
            TaskList.tasks[selectedTask].Completed = true;
            ColoredText.WriteLine("Task marked as complete\n", ConsoleColor.Green);

        }

        public static void MarkAsIncomplete()
        {
            TaskList.tasks[selectedTask].Completed = false;
            ColoredText.WriteLine("Task marked as not completed\n", ConsoleColor.Green);

        }

        public static void EditTitle()
        {
            ColoredText.WriteLine("Enter a new title for the task", ConsoleColor.Yellow);
            string newTitle = Task.InputTitle();
            TaskList.tasks[selectedTask].Title = newTitle;
            ColoredText.WriteLine("Task title updated\n", ConsoleColor.Green);
        }

        public static void EditProject()
        {
            ColoredText.WriteLine("Enter a new project", ConsoleColor.Yellow);
            Console.Write("Project: ");
            string projectInput = Console.ReadLine();
            TaskList.tasks[selectedTask].Project = projectInput;
            ColoredText.WriteLine("Task's project updated\n", ConsoleColor.Green);
        }


        public static void EditDate()
        {
            ColoredText.WriteLine("Enter a new due date for the task", ConsoleColor.Yellow);
            DateTime newDate = Task.InputDate();
            TaskList.tasks[selectedTask].DueDate = newDate;
            ColoredText.WriteLine("Due date updated\n", ConsoleColor.Green);
        }



    }
}
