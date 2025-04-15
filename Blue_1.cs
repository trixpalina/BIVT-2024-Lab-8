using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Разбить исходный текст на строки длиной не более 50 символов.Перенос на новую строку осуществлять на месте пробела
//    (слова не переносить). Свойство Output должно возвращать массив строк.Метод ToString() должен возвращать массив 
//        отформатированных строк построчно.
namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = new string[0];
        }

        public override void Review()
        {
            if (Input == null)
            {
               _output = null;
               return;
            }

            string[] words = SplitWords(Input);
            string line = "";

            string[] result = new string[Input.Length]; 
            int index = 0;

            foreach (string word in words)
            {
                    if (line.Length + word.Length + 1 <= 50)
                    {
                        if (line.Length > 0)
                            line += " ";
                        line += word;
                    }
                    else
                    {
                        result[index++] = line;
                        line = word;
                    }
            }

            if (line.Length > 0) result[index++] = line;

                _output = new string[index];
                for (int i = 0; i < index; i++)
                    _output[i] = result[i];
        }

        public override string ToString()
        {
            if (_output == null)  return " ";

            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += _output[i];
                if (i < _output.Length - 1)
                    result += "\n"; 
            }
            return result;
        }

        private string[] SplitWords(string text)
            {
                string current = "";
                string[] temp = new string[text.Length];
                int count = 0;

                foreach (char c in text)
                {
                    if (c != ' ')
                    {
                        current += c;
                    }
                    else
                    {
                        if (current.Length > 0)
                        {
                            temp[count++] = current;
                            current = "";
                        }
                    }
                }

                if (current.Length > 0)  temp[count++] = current;

                string[] result = new string[count];
                for (int i = 0; i < count; i++)
                    result[i] = temp[i];

                return result;
            }
        }
    }


