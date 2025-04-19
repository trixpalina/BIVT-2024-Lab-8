using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }
        private static void Add(ref string[] strings, string str)
        {
            if (strings == null || string.IsNullOrEmpty(str))
                return;

            string[] newStrings = new string[strings.Length + 1];
            for (int i = 0; i < strings.Length; i++)
            {
                newStrings[i] = strings[i];
            }

            newStrings[strings.Length] = str;
            strings = newStrings;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Split(Input, ' ');
            string[] res = new string[0];
            int i = 0;

            while (i < words.Length)
            {
                string line = "";
                int counter = words[i].Length;

                line += words[i++] + " ";

                while (i < words.Length && (counter + words[i].Length + 1) <= 50)
                {
                    line += words[i] + " ";
                    counter += words[i].Length + 1;
                    i++;
                }

                if (line.Length > 0)
                    line = line.Substring(0, line.Length - 1); 

                Add(ref res, line);
            }

            _output = res;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;
            return string.Join(Environment.NewLine, _output);
        }

        private string[] Split(string input, char separator)
        {
            if (string.IsNullOrEmpty(input))
                return new string[0];

            int wordCount = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == separator)
                    wordCount++;
            }

            string[] result = new string[wordCount];
            int wordIndex = 0;
            string currentWord = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == separator)
                {
                    result[wordIndex++] = currentWord;
                    currentWord = "";
                }
                else
                {
                    currentWord += input[i];
                }
            }

            result[wordIndex] = currentWord;
            return result;
        }
    }
}
