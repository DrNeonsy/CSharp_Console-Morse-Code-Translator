namespace CSharp_Console_Morse_Code_Translator
{
    internal class Utility
    {
        /// <summary>
        /// This Is A Method That Prompts The User To Press One Of Two Keys
        /// </summary>
        /// <param name="msg">The Message You Wish To Display</param>
        /// <param name="option1">The Left Option To Press</param>
        /// <param name="option2">The Right Option To Press</param>
        /// <returns>A Boolean: Option 1 Pressed</returns>
        internal static bool Decision(string msg, ConsoleKey option1 = ConsoleKey.Y, ConsoleKey option2 = ConsoleKey.N)
        {
            ConsoleKeyInfo ckey;
            bool hasFailed = false;

            do
            {
                if (hasFailed)
                {
                    Console.WriteLine(Environment.NewLine +
                        $"Only Use {option1} Or {option2} Key" +
                        Environment.NewLine);
                }
                else
                {
                    hasFailed = true;
                }

                Console.Write(Environment.NewLine +
                    msg + $" ( {option1} | {option2} )" +
                    Environment.NewLine);
                ckey = Console.ReadKey(true);

            } while (ckey.Key != option1 && ckey.Key != option2);
            return ckey.Key == option1;
        }
        /// <summary>
        /// Clears The Screen And Prints A Message For A Certain Amount Of Time
        /// </summary>
        /// <param name="msg">The Message You Wish To Display</param>
        /// <param name="timeout">Idle Time</param>
        internal static void Error(string msg, int timeout = 2700)
        {
            Console.Clear();
            Console.WriteLine(Resources.Error);
            Console.WriteLine(msg);
            Thread.Sleep(timeout);
            Console.Clear();
        }
    }
}
