namespace TaskMaster
{
    static internal class TaskEditor
    {
        //Used to edit previously created tasks.

        static int selectedTask;
        public static void Edit()
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
            Menus.TaskMenu.Open();
        }

        public static void Delete()
        {
            TaskList.tasks.RemoveAt(selectedTask);
        }
        public static void MarkAsComplete() 
        {
            TaskList.tasks[selectedTask].Completed = true;
        }

        public static void MarkAsIncomplete()
        {
            TaskList.tasks[selectedTask].Completed = false;
        }

    }
}
