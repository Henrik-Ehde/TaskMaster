using TaskMaster;
using Task = TaskMaster.Task;





FileHandler.Open();
Menus.Setup();

while (true)
{
    Menus.MainMenu.Open();
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




