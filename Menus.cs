using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster
{
    //static internal class Menus { }
    class Menu
    {
        string HeaderText { get; set; }
        List<Option> Options = new List<Option>();

        public Menu(string headerText, List<Option> options)
        {
            HeaderText = headerText;
            Options = options;
        }

        public void Open()
        {
            ColoredText.WriteLine(HeaderText, ConsoleColor.Yellow);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine(i+1 + ") " + Options[i].Text);
            }

            int selection;
            while (true)
            {
                char inputKey = Console.ReadKey(true).KeyChar;
                if (int.TryParse(inputKey.ToString(), out selection) && selection <= Options.Count) break;
            }

            Console.WriteLine("");
            Options[selection-1].Function();

        }
    }

    class Option
    {
        public Option(string text, functionCall function)
        {
            Text = text;
            Function = function;
        }

        public string Text { get; set; }
        public delegate void functionCall();
        public functionCall Function;
            
    }
}
