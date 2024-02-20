namespace TaskMaster
{
    class Menu
    {
        //Contains information about a single menu: Instructions to be displayed and a list of options to chose from.
        //Has a function to display the options and let user select one of them.
        string HeaderText { get; set; }
        List<Option> Options = new List<Option>();

        public Menu(string headerText, List<Option> options)
        {
            HeaderText = headerText;
            Options = options;
        }

        public void Open()
        {
            //Write the instructions and each option
            ColoredText.WriteLine(HeaderText, ConsoleColor.Yellow);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine(i+1 + ") " + Options[i].Text);
            }

            //Check input until the user inputs a key for one of the options.
            int selection;
            while (true)
            {
                char inputKey = Console.ReadKey(true).KeyChar;
                if (int.TryParse(inputKey.ToString(), out selection) && selection <= Options.Count) break;
            }

            Console.WriteLine("");
            //Calls the function to execute the selected option
            Options[selection-1].Function();

        }
    }
}
