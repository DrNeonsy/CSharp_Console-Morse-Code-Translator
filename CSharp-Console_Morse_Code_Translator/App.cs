namespace CSharp_Console_Morse_Code_Translator
{
    internal class App
    {
        // Fields -----------------------------------------------------------------------
        static readonly char[] _menuKeys = { '0', '1', '2', '3', '4', '5' }; // Valid Menu Keys
        // Properties -------------------------------------------------------------------
        static string Original { get; set; } = "";
        static string Converted { get; set; } = "";
        static string Path { get; set; } = "";
        static bool Cancled { get; set; }
        static char[] MenuKeys
        {
            get { return _menuKeys; }
        }
        // Methods ----------------------------------------------------------------------
        internal static void Initialize()
        {
            Console.WriteLine(Resources.Loading); // For Debugging Purposes
            //Thread.Sleep(555);

            Morse.FillChart();

            Console.Clear();
        }
        internal static bool Menu()
        {
            Console.WriteLine(Resources.Menu);

            Console.WriteLine("{0, -32}{1}", "Text To Morse (TXT)", "| 1");
            Console.WriteLine("{0, -32}{1}", "Morse To Text (TXT)", "| 2");
            Console.WriteLine("{0, -32}{1}", "Text To Morse (User)", "| 3");
            Console.WriteLine("{0, -32}{1}", "Morse To Text (User)", "| 4");
            Console.WriteLine("{0, -32}{1}", "Check Dictionary", "| 5");
            Console.WriteLine(new String('-', 36));
            Console.WriteLine("{0, -32}{1}", "Morse Format Guide", "| 0");

            Console.WriteLine(Environment.NewLine + "Please Press The Corresponding Key");

            static char MenuValidation()
            {
                char result = '\0';
                bool invalidKey = true;

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    foreach (char keysAvailable in MenuKeys)
                    {
                        if (key.KeyChar == keysAvailable)
                        {
                            invalidKey = false;
                            result = key.KeyChar;
                        }
                    }
                } while (invalidKey);
                Console.Clear();
                return result;
            }
            Cancled = false; // Reset ------------------------------------
            switch (MenuValidation())
            {
                case '0':
                    Instuctions();
                    break;
                case '1':
                    Converter(mode: "TXT", direction: "ttm");
                    break;
                case '2':
                    Converter(mode: "TXT", direction: "mtt");
                    break;
                case '3':
                    Converter(mode: "user", direction: "ttm");
                    break;
                case '4':
                    Converter(mode: "user", direction: "mtt");
                    break;
                case '5':
                    Morse.LoopThrough(output: true);
                    break;
            }

            Converted = ""; // Resetting
            if (!Cancled)
            {
                return Utility.Decision("Return To Menu?");
            }
            else
            {
                return true;
            }
        }
        static void Converter(string mode, string direction)
        {
            if (mode == "TXT")
            {
                do // Read From TXT Until It Works
                {
                    Console.Clear();
                    Console.WriteLine(Resources.TxtInput);
                } while (!ReadFile());
            }
            else // Mode == User
            {
                do // Read From User Until It Works
                {
                    Console.Clear();
                    Console.WriteLine(Resources.UserInput);
                } while (!ReadInput());
            }

            void TextToMorse()
            {
                for (int i = 0; i < Original.Length; i++)
                {
                    if (Morse.MorseChart.ContainsKey(Original[i]))
                    {
                        Converted += Morse.MorseChart[Original[i]] + " ";
                    }
                }
            }
            void MorseToText()
            {
                string value;
                bool working = true;
                while (working)
                {
                    if (Original.Contains(' '))
                    {
                        value = Original[..Original.IndexOf(' ')];
                    }
                    else
                    {
                        value = Original[..];
                        working = false;
                    }

                    Original = Original.Remove(0, Original.IndexOf(' ') + 1);
                    Converted += (Morse.MorseChart.FirstOrDefault(x => x.Value == value).Key);
                }
            }

            if (direction == "ttm") // Based On Method Name
            {
                TextToMorse();
            }
            else if (direction == "mtt") // Based On Method Name
            {
                MorseToText();
            }

            if (!Cancled)
            {
                Console.Clear();
                Console.WriteLine(Resources.Result);
                Console.WriteLine(Environment.NewLine + Converted);
                if (Utility.Decision("Do You Want To Export?"))
                {
                    Export();
                }
            }
        }
        static bool ReadFile()
        {
            Console.CursorVisible = true;

            Console.Write("Path To TXT (Empty To Exit): ");
            string? path = Console.ReadLine();

            Console.CursorVisible = false;

            if (path != null && path != "")
            {
                if (path.Contains('"'))
                {
                    Path = path.Trim('"');
                }
                else
                {
                    Path = path;
                }
                try
                {
                    Original = File.ReadAllText(Path).ToUpper();
                }
                catch (Exception ex)
                {
                    if (ex is PathTooLongException || ex is ArgumentException)
                    {
                        Utility.Error("Invalid Path");
                    }
                    else if (ex is DirectoryNotFoundException || ex is FileNotFoundException)
                    {
                        Utility.Error("The Directory Or File Does Not Exist");
                    }
                    else if (ex is UnauthorizedAccessException)
                    {
                        Utility.Error("I Cannot Access That");
                    }
                    else if (ex is IOException)
                    {
                        Utility.Error("Illegal Characters I/O");
                    }
                    return false;
                }
            }
            else
            {
                Cancled = true;
                return true;
            }
            return true;
        }
        static bool ReadInput()
        {
            Console.CursorVisible = true;

            Console.Write("Text (Empty To Exit): ");
            string? input = Console.ReadLine();

            Console.CursorVisible = false;

            if (input == null || input == "")
            {
                Cancled = true;
                return true;
            }

            Original = input.ToUpper();
            return true;
        }
        static void Export()
        {
            try
            {
                string exportPath = Directory.GetCurrentDirectory() + "/Morse.txt";

                File.WriteAllText(exportPath, Converted);
                Console.WriteLine($"{Environment.NewLine}Result Exported To {exportPath}");
            }
            catch (Exception ex)
            {
                if (ex is PathTooLongException || ex is ArgumentException)
                {
                    Utility.Error("Invalid Path");
                }
                else if (ex is DirectoryNotFoundException || ex is FileNotFoundException)
                {
                    Utility.Error("The Directory Or File Does No Longer Exist");
                }
                else if (ex is UnauthorizedAccessException)
                {
                    Utility.Error("I Cannot Access That");
                }
                else if (ex is IOException)
                {
                    Utility.Error("Illegal Characters I/O");
                }
            }
        }
        static void Instuctions()
        {
            Console.WriteLine(Resources.Morse);

            Console.WriteLine("Please Follow The Following Morse Format" +
                Environment.NewLine);

            Console.WriteLine($"Every Letter Like (A: {Morse.MorseChart['A']}) Should Be Separated By A Space");
            Console.WriteLine("Every Space Should Be Represented By A (/)");

            Console.WriteLine(Environment.NewLine +
                "For Example: hello world | .... . .-.. .-.. --- / .-- --- .-. .-.. -..");
        }
    }
}

