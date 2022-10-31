using System;

namespace CSharpStringsArraysAndLists
{
    public class Program
    {
        public static void Main()
        {
            //Examples.StringToListAndBack();
            //Examples.UsingAStringBuilder();
            //Examples.UsefulStringAndCharFunctions();
            //Examples.UsingArrays();
            //Examples.UsingLists();

            Exercises.doubleArray();
            Exercises.byteArray();
            Exercises.temperatures();
            Exercises.students();
            Console.WriteLine(Exercises.PigLatin("hello world"));
            Console.WriteLine(String.Join(",", Exercises.Wave("hello")));

            List<string> anagrams = new List<string> { "rats", "arts", "arc" };
            Console.WriteLine(Exercises.Anagram("star",anagrams));
            Console.WriteLine(Exercises.WriteVariableName("hello world", Exercises.VariableNameType.PascalCase));


        }


    }
} 