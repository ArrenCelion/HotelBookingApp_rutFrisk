using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Utilities
{
    internal class DisplayMenu  //Gör static senare
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public DisplayMenu(string prompt, string[] options)
        {
            Prompt = prompt;            
            Options = options;
            SelectedIndex = 0;
        }
        
        internal void DisplayOptions()
        {
            Console.WriteLine(Prompt);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix; //byt mot spectre funktionalitet sen med färg och grejer

                if (i == SelectedIndex)
                {
                    prefix = "-->";
                }
                else
                {
                    prefix = "   ";
                }

                Console.WriteLine($"{prefix} <<{currentOption}>>");
            }
        }

        public int Run()
        {
            ConsoleKey userInput;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                userInput = keyInfo.Key;

                if (userInput == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (userInput == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (userInput != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
