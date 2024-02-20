using TaskMaster;
using Task = TaskMaster.Task;



//Create a populated list of tasks
TaskList taskList = new TaskList
([
    new Task("Do dishes", "Chores", "20/2", false),
    new Task("Take out trash", "Chores", "22/2", true),
    new Task("Read a book", "", "25/3", false)

]);

//Setup Menus
Menu DisplayMenu = new Menu
(
    "Display To-Do List",
    [
    new Option("Sorted by Date", taskList.DisplayByDate),
    new Option("Sorted by Project", taskList.DisplayByProject),
    new Option("Cancel", Cancel)
]);

Menu MainMenu = new Menu
(
    "What would you like to do?",
    [
    new Option("Show To-Do List", DisplayMenu.Open),
    new Option("Add Task", AddTask),
    new Option("Exit", Exit)
]);





//Menus.MainMenu.Open();
//addTask();
while (true)
{
    MainMenu.Open();
}

Console.ReadLine();



void MainMenuOLD()
{
    while (true)
    {
        ColoredText.WriteLine("What would you like to do?", ConsoleColor.Yellow);
        Console.WriteLine("1) Display to-do list");
        Console.WriteLine("2) Add a task");
        Console.WriteLine("3) Edit a Task");
        Console.WriteLine("4) Exit");

        bool repeat;
        do
        {
            repeat = false;
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //DisplayMenu();
                    break;

                case "2":
                    //AddTask();
                    break;
                default:
                    repeat = true;
                    break;

            }

        }
        while (repeat);
    }
}



void AddTask()
{
    Task newTask = Task.CreateTask();
    taskList.Add(newTask);
    ColoredText.WriteLine("The task has been added\n", ConsoleColor.Green);
}

void Cancel()
{
    //This function doesen't do anything, which means the program will return to main menu
}

void Exit()
{
    Environment.Exit(0);
}




