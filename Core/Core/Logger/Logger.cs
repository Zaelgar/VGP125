using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Debug
{
    static class Debug
    {
        private static Dictionary<string, ConsoleColor> colourByHeaderId = new Dictionary<string, ConsoleColor>(System.StringComparer.Ordinal)
        {
            { "Warning", ConsoleColor.Yellow },
            { "Error", ConsoleColor.Red },
        };


        public static void Output(string text, string headerID)
        {
            ConsoleColor colour;
            if (colourByHeaderId.TryGetValue(headerID, out colour))
            {
                var prevColour = Console.ForegroundColor;
                Console.ForegroundColor = colour;
                Console.WriteLine("[{0}] {1}", headerID, text);
                Console.ForegroundColor = prevColour;
            }

            Console.WriteLine(text);
        }

        public static void Log(string text, string headerId = "Info")
        {
            Output(text, headerId);
        }

        public static void Error(string text, string headerId = "Error")
        {
            Output(text, headerId);
        }

        public static void Warning(string text, string headerId = "Warning")
        {
            Output(text, headerId);
        }
    }
}