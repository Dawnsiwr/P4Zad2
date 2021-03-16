using System;
using System.Collections.Generic;
using System.Text;

namespace P4Zad2
{
    public class DataReader
    {
        public string ReadSentence()
        {
            string sentence;
            do
            {
                sentence = Console.ReadLine();
            } while (sentence == null);

            return sentence;
        }
        public int ReadIntValue()
        {
            bool valueError = false;
            int value = 0;
            do
            {
                valueError = false;
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.Write("Niepoprawna wartość ");
                    valueError = true;
                    continue;
                }

            } while (valueError);

            return value;
        }

        public int ReadIntValueMinMax(int min, int max)
        {
            bool valueError = false;
            int value = 0;
            do
            {
                valueError = false;
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.Write("Niepoprawna wartość ");
                    valueError = true;
                    continue;
                }

            } while (valueError && (value >= min && value <= max));

            return value;
        }


    }
}