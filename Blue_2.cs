using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _part;
        private string _output;

        public string Output => _output;

        public Blue_2(string text, string part) : base(text)
        {
            if (part != null)
            {
                _part = part;
            }
            else
            {
                _part = "";
            }

            _output = "";
        }

        public override void Review()
        {
            if (Input == null || _part == null)
            {
                _output = "";
                return;
            }

            string text = Input;
            string result = "";
            string word = "";

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (ch != ' ')
                {
                    word += ch;
                }

                if (ch == ' ' || i == text.Length - 1)
                {
                    string clean = "";
                    string punctuation = "";

                    for (int j = 0; j < word.Length; j++)
                    {
                        char c = word[j];
                        if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ||
                            (c >= 'А' && c <= 'я') || c == 'Ё' || c == 'ё' ||
                            (c >= '0' && c <= '9') || c == '-' || c == '\'')
                        {
                            clean += c;
                        }
                        else
                        {
                            punctuation += c;
                        }
                    }

                   
                    bool found = false;

                    if (clean.Length >= _part.Length)
                    {
                        for (int k = 0; k <= clean.Length - _part.Length; k++)
                        {
                            bool match = true;

                            for (int m = 0; m < _part.Length; m++)
                            {
                                char ch1 = clean[k + m];
                                char ch2 = _part[m];

                                if (ch1 >= 'A' && ch1 <= 'Z') ch1 = (char)(ch1 + 32);
                                if (ch2 >= 'A' && ch2 <= 'Z') ch2 = (char)(ch2 + 32);

                                if (ch1 >= 'А' && ch1 <= 'Я') ch1 = (char)(ch1 + 32);
                                if (ch2 >= 'А' && ch2 <= 'Я') ch2 = (char)(ch2 + 32);

                                if (ch1 != ch2)
                                {
                                    match = false;
                                    break;
                                }
                            }

                            if (match)
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        if (result.Length > 0 && result[result.Length - 1] != ' ')
                            result += " ";

                        result += clean;
                        result += punctuation;
                    }
                    else if (punctuation.Length > 0 && result.Length > 0)
                    {
                        int cut = result.Length - 1;
                        while (cut >= 0 && result[cut] == ' ')
                            cut--;

                        result = result.Substring(0, cut + 1);
                        result += punctuation;
                    }

                    word = "";
                }
            }

            int start = 0;
            while (start < result.Length && result[start] == ' ')
                start++;

            int end = result.Length - 1;
            while (end >= start && result[end] == ' ')
                end--;

            if (start <= end)
            {
                _output = result.Substring(start, end - start + 1);
            }
            else
            {
                _output = "";
            }
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
