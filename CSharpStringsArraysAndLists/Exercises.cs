using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStringsArraysAndLists
{
    public class Exercises
    {
        // The first four exercises can be procedures if you wish
        // Please add appropriate calling code to Program.cs
        // Add tests as well as calling code for the exercises where you use functions

        // 1: Arrays
        // Create an array of doubles each of which holds three coordinates
        // Print these to the screen
        public static void doubleArray()
        {
            double[] coords = new double[3];
            coords[0] = 10.5;
            coords[1] = 3;
            coords[2] = -7.25;
            Console.WriteLine(string.Join(",", coords));
        }

        // 2: Byte Arrays
        // i) Create an array of bytes that represents the word hello. Convert this to a string and output the result.
        // ii) Convert the word hello both in Chinese and in English to bytes. Output the byte array. 
        public static void byteArray()
        {
            byte[] hello = Encoding.ASCII.GetBytes("hello");

            byte[] 你好 = Encoding.UTF32.GetBytes("你好");

            Console.WriteLine(string.Join(",", Encoding.ASCII.GetChars(hello)));

            Console.WriteLine(string.Join(",", hello));

            Console.WriteLine(string.Join(",", 你好));


        }
        // 3: Temperatures
        // Populate a list of doubles to represent daily temperatures over two weeks
        // Calculate and output the min, max and average temperatures over the time period
        // Sort the list in ascending order and print it out
        public static void temperatures()
        {
            List<double> temps = new List<double>();
            temps.Add(12);
            temps.Add(25);
            temps.Add(10);
            temps.Add(5);
            temps.Add(3);
            temps.Add(19);

            double minTemp = 999999999;
            double maxTemp = 0;
            double tempTotal = 0;

            
            for (int i=0; i<temps.Count-1;i++)
            {  
                if (temps[i] > maxTemp) {
                    maxTemp = temps[i];
                }
                else if (temps[i] < minTemp)
                {
                    minTemp = temps[i];
                }
                tempTotal += temps[i];
            }
            double averageTemp = tempTotal / temps.Count;
            Console.WriteLine(minTemp);
            Console.WriteLine(maxTemp);
            Console.WriteLine(averageTemp);

            temps.Sort();

            Console.WriteLine(String.Join(",", temps));

        }
        // 4: Students
        // Populate a list of student data with a firstname, surname and date of birth. Use a tuple.
        // Print the names of the oldest and youngest students
        // Print out how many students were born after 2010
        // Create a new list of strings with the full names of all the students and print this out     
        public static void students()
        {
            List < (string firstName, string lastName, int dob) > data = new List<(string firstName, string lastName, int dob)>();

            data.Add(("bob","white",2013));
            data.Add(("alice", "gray", 2006));
            data.Add(("eve", "green", 2011));

            string youngest = "";
            string oldest = "";

            for (int i=0;i<data.Count-1;i++)
            {
                if (data[i].dob > data[i+1].dob)
                {
                    youngest = data[i].firstName + data[i].lastName;
                }
                else if (data[i].dob < data[i + 1].dob)
                {
                    oldest = data[i].firstName + data[i].lastName;
                }
                if (data[i].dob > 2010)
                {
                    Console.WriteLine(data[i].firstName, data[i].lastName, "was born after 2010");
                }

            }
            Console.WriteLine(oldest);
            Console.WriteLine(youngest);
            
        }
        // 5: Pig Latin
        // Move the first letter of each word to the end of it, then add "ay" to the end of the word. 
        // Leave punctuation marks untouched.
        // The cat sat on the mat. => heTay atcay noay hetay atmay.
        public static string PigLatin(string input)
        {
            string newPhrase = "";

            string[] words = input.Split();

            foreach (string word in words)
            {   
                newPhrase += " "+word.Substring(1)+word.Substring(0, 1)+"ay";
            }
            return newPhrase;
        }

        // 6. Mexican wave
        //  1.  The input string will always be lower case but maybe empty.
        //  2.  If the character in the string is whitespace then pass over it as if it was an empty seat
        // Example
        // Wave("hello") => ["Hello", "hEllo", "heLlo", "helLo", "hellO"]
        public static List<string> Wave(string input)
        {
            List<string> mexicanWave = new List<string>();

            char[] inputArray = input.ToCharArray();

            for (int i=0; i<inputArray.Count();i++)
            {
                inputArray[i] =  Char.ToUpper(inputArray[i]);

                string wave = string.Join("",inputArray);
                mexicanWave.Add(wave);

                inputArray[i] = Char.ToLower(inputArray[i]);
            }
            return mexicanWave;
        }

        // 7. Anagram
        // Given a word and a list of words return the number of words that are anagrams of the others
        // Anagram("star", ["rats", "arts", "arc"]) => 2
        public static int Anagram(string input, List<string> possibleAnagrams)
        {
            int num = 0;

            foreach (string words in possibleAnagrams)
            {
                if (String.Concat(words.OrderBy(c => c)) == String.Concat(input.OrderBy(c => c))) {
                    num++;
                }
            }
            return num;
        }

        // 8. Variable Name helper
        public enum VariableNameType
        {
            CamelCase,
            PascalCase,
            SnakeCase
        }
        // Return the string in either camelCase, PascalCase or snake_case depending on the user choice
        public static string WriteVariableName(string input, VariableNameType caseNeeded = VariableNameType.CamelCase)
        {
            string output = "";

            int i = Convert.ToInt16(caseNeeded);

            string[] stringArray = input.Split();
            switch(i)
            {
                case 0:
                    for (i=0;i<stringArray.Count();i++)
                    {
                        if (i == 0)
                        {
                            output += stringArray[i];
                        }
                        else
                        {
                            output += Char.ToUpper(stringArray[i][0]) + stringArray[i].Substring(1);
                        }
                    }
                    
                    break;
                case 1:
                    for (i = 0; i < stringArray.Count(); i++)
                    {
                        output += Char.ToUpper(stringArray[i][0]) + stringArray[i].Substring(1);
                    }

                    break;
                case 2:
                    for (i = 0; i < stringArray.Count(); i++)
                    {
                        if (i == stringArray.Count()-1)
                        {
                            output += stringArray[i];
                        }

                        else
                        {
                            output += stringArray[i] + "_";
                        }
                        
                    }
                    break;
            }


            return output;
        }

        // 9. Binary search
        // The function should take a sorted list. You can sort it in the calling code using default sort.
        // Use a binary search to find the requested value (write this yourself)
        // It should return the index of the value found or -1 if it isn't found
        public static int BinarySearch(List<decimal> values)
        {
            throw new NotImplementedException();
        }
    }
}
