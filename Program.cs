using TaskMaster;
using Task = TaskMaster.Task;





FileHandler.Open();
Menus.Setup();
ShowWelcomeMessage();

while (true)
{
    Menus.MainMenu.Open();
}

void ShowWelcomeMessage()
{
    //Display an opening message when program is started. Count and show the number of tasks that are completed, not completed or overdue.
    int completedCount = 0;
    int uncompletedCount = 0;
    int overdueCount = 0;

    foreach (Task task in TaskList.tasks)
    {
        if (task.Completed) completedCount++;
        else
        {
            uncompletedCount++;
            if (task.DueDate <  DateTime.Now) overdueCount++;
        }
    }

    Console.WriteLine("Welcome to TaskMaster! You have " + completedCount + " completed tasks and " + uncompletedCount + " uncompleted tasks.");

    if (overdueCount > 0) ColoredText.WriteLine(overdueCount + " tasks are overdue!", ConsoleColor.DarkYellow);
    Console.Write("\n");
}



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