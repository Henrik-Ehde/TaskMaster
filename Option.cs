namespace TaskMaster
{
    class Option
    {
        //Stores one option in a menu. Contains a string that descripes the option and a function to be executed when the option is chosen
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
