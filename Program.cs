using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] myString = new char[100];
            String input;

            Console.WriteLine("Enter characters to create a string:");
            input = Console.ReadLine();
            myString = input.ToCharArray();

            Console.Write("Size: " + myString.Length + "\t\t\t");
            Console.Write(myString);

            // REVERSE ARRAY
            myString = input.ToCharArray();
            myString = ReverseChars(myString);
            Console.WriteLine("\n\nReversed character array: " + "\t\t\t");
            Console.Write(myString);


            // REPLACE SPACES
            myString = input.ToCharArray();
            myString = ReplaceSpaces(myString);
            Console.WriteLine("\n\nSpaces replaced with \"_\": " + "\t\t\t");
            Console.Write(myString);


            // INSERT CHARACTER
            myString = input.ToCharArray();
            myString = InsertChar(myString);
            Console.WriteLine("\nCharacter array with the added character: " + "\t\t\t");
            Console.Write(myString);


            // PALINDROME
            myString = input.ToCharArray();
            if (IsPalindrome(myString))
            {
                Console.WriteLine("\n\nThis character array is a palindrome.");
            }
            else
            {
                Console.WriteLine("\n\nThis character array is not a palindrome!");
            }


            Console.ReadKey();
        }

        static char[] ReverseChars(char[] charArray)
        {
            char[] reverseString = new char[100];
            int temp = 0;
            for (int i = charArray.Length - 1; i >= 0; --i)
            {
                reverseString[temp] = charArray[i];
                temp++;
            }

            return reverseString;
        }

        static char[] ReplaceSpaces(char[] charArray)
        {
            for (int i = 0; i < charArray.Length; ++i)
            {
                if (charArray[i] == ' ')
                {
                    charArray[i] = '_';
                }
            }

            return charArray;
        }

        static char[] InsertChar(char[] characterArray)
        {
            char characterToInsert;
            char[] output = new char[100];

            Console.WriteLine("\n\nEnter a character to insert into the character array:");
            characterToInsert = (char)Console.Read();

            for (int i = 0; i < characterArray.Length; ++i)
            {
                output[i] = characterArray[i];
            }
            output[characterArray.Length] = characterToInsert;

            return output;
        }

        static bool IsPalindrome(char[] characterArray)
        {
            for (int i = characterArray.Length - 1; i > 0; --i)
            {
                if (characterArray[i] != characterArray[(characterArray.Length - 1) - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}