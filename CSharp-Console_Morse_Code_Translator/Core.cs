namespace CSharp_Console_Morse_Code_Translator
{
    internal class Core
    {
        static void Main(string[] args)
        {
            // Personal Setup Stuff
            Console.CursorVisible = false;
            Console.Title = "Morse Code Translator";

            // Actual Application
            App.Initialize();

            while (App.Menu()) Console.Clear();

            Environment.Exit(0);
        }
    }
}