namespace CSharp_Console_Morse_Code_Translator
{
    internal class Morse
    {
        // Fields -----------------------------------------------------------------------
        static Dictionary<char, string> _hash = new Dictionary<char, string>();
        // Properties -------------------------------------------------------------------
        internal static Dictionary<char, string> MorseChart
        {
            get { return _hash; }
            set { _hash = value; }
        }
        // Methods ----------------------------------------------------------------------
        internal static void FillChart()
        {
            void WithAlphabet()
            {
                MorseChart.Add('A', ".-");
                MorseChart.Add('B', "-...");
                MorseChart.Add('C', "-.-.");
                MorseChart.Add('D', "-..");
                MorseChart.Add('E', ".");
                MorseChart.Add('F', "..-.");
                MorseChart.Add('G', "--.");
                MorseChart.Add('H', "....");
                MorseChart.Add('I', "..");
                MorseChart.Add('J', ".---");
                MorseChart.Add('K', "-.-");
                MorseChart.Add('L', ".-..");
                MorseChart.Add('M', "--");
                MorseChart.Add('N', "-.");
                MorseChart.Add('O', "---");
                MorseChart.Add('P', ".--.");
                MorseChart.Add('Q', "--.-");
                MorseChart.Add('R', ".-.");
                MorseChart.Add('S', "...");
                MorseChart.Add('T', "-");
                MorseChart.Add('U', "..-");
                MorseChart.Add('V', "...-");
                MorseChart.Add('W', ".--");
                MorseChart.Add('X', "-..-");
                MorseChart.Add('Y', "-.--");
                MorseChart.Add('Z', "--..");
            }
            void WithNumeric()
            {
                MorseChart.Add('0', "-----");
                MorseChart.Add('1', ".----");
                MorseChart.Add('2', "..---");
                MorseChart.Add('3', "...--");
                MorseChart.Add('4', "....-");
                MorseChart.Add('5', ".....");
                MorseChart.Add('6', "-....");
                MorseChart.Add('7', "--...");
                MorseChart.Add('8', "---..");
                MorseChart.Add('9', "----.");
            }
            void WithPunctuation()
            {
                MorseChart.Add(',', "--..--");
                MorseChart.Add('.', ".-.-.-");
                MorseChart.Add('?', "..--..");
                MorseChart.Add('!', "-.-.--");
                MorseChart.Add('-', "-....-");
                MorseChart.Add(':', "---...");
                MorseChart.Add(';', "-.-.-.");
                MorseChart.Add('/', "-..-.");
                MorseChart.Add('_', "..--.-");
                MorseChart.Add('@', ".--.-.");
                MorseChart.Add('+', ".-.-.");
                MorseChart.Add('(', "-.--.");
                MorseChart.Add(')', "-.--.-");
                MorseChart.Add('\'', ".----.");
                MorseChart.Add(' ', "/");
            }
            WithAlphabet(); // A - Z
            WithNumeric(); // 0 - 9
            WithPunctuation();
        }
        internal static void LoopThrough(bool output)
        {
            foreach (KeyValuePair<char, string> kvp in MorseChart) // KVP == KeyValuePair
            {
                // Optional Features ----------------------------------------------------
                if (output)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    Thread.Sleep(69);
                }
            }
        }
    }
}
