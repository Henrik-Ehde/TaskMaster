namespace TaskMaster
{
    static internal class Menus
    {
        //Sets up and contains all the menus in the program. Also contains some simple functions such as exiting the application.
        static public Menu MainMenu, DisplayMenu, TaskMenu;
        static public void Setup()
        {
            DisplayMenu = new Menu("Display To-Do List",
            [
                new Option("Sorted by Date", TaskList.DisplayByDate),
                new Option("Sorted by Project", TaskList.DisplayByProject),
                new Option("Cancel", Cancel)
            ]);

            TaskMenu = new Menu("What would you like to do?",
            [
                new Option("Mark as Completed", TaskEditor.MarkAsComplete),
                new Option("Mark as NOT Completed", TaskEditor.MarkAsIncomplete),
                new Option("Delete", TaskEditor.Delete),
                new Option("Cancel", Cancel)
            ]);

            MainMenu = new Menu("What would you like to do?",
            [
                new Option("Show To-Do List", DisplayMenu.Open),
                new Option("Add Task", Task.CreateTask),
                new Option("Edit Task", TaskEditor.Edit),
                new Option("Exit", Exit)
            ]);
        }

        static void Cancel()
        {
            //Do nothing - let the program return to main menu
        }

        static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
