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
                _part = part;
                _output = null;
            }

            public override void Review()
            {
                if (string.IsNullOrWhiteSpace(Input) || string.IsNullOrWhiteSpace(_part))
                {
                    _output = null;
                    return;
                }

                string result = "";
                string word = "";

                for (int i = 0; i < Input.Length; i++)
                {
                    char ch = Input[i];
                    if (ch != ' ')
                    {
                        word += ch;
                    }

                    if (ch == ' ' || i == Input.Length - 1)
                    {
                        if (word.Length > 0)
                        {
                            string clean = "";
                            string punctuation = "";
                            char wrapperStart = '\0', wrapperEnd = '\0';

                            if ((word.StartsWith("(") && word.EndsWith(")")) ||
                                (word.StartsWith("\"") && word.EndsWith("\"")) ||
                                (word.StartsWith("«") && word.EndsWith("»")))
                            {
                                wrapperStart = word[0];
                                wrapperEnd = word[word.Length - 1];
                                word = word.Substring(1, word.Length - 2);
                            }

                            for (int j = 0; j < word.Length; j++)
                            {
                                char c = word[j];

                                if (char.IsLetterOrDigit(c) || c == '-' || c == '\'')
                                {
                                    clean += c;
                                }
                                else if (c == ',' && j > 0 && j < word.Length - 1 &&
                                         char.IsDigit(word[j - 1]) && char.IsDigit(word[j + 1]))
                                {
                                    clean += c;
                                }
                                else
                                {
                                    punctuation += c;
                                }
                            }

                            bool found = checkpart(clean, _part);

                            if (!found)
                            {
                                if (result.Length > 0 && result[result.Length - 1] != ' ')
                                    result += " ";

                                if (wrapperStart != '\0')
                                    result += wrapperStart;

                                result += clean;

                                if (wrapperEnd != '\0')
                                    result += wrapperEnd;

                                result += punctuation;
                            }
                            else
                            {
                                if (wrapperEnd == '\0' && punctuation.Length > 0)
                                {
                                    int cut = result.Length - 1;
                                    while (cut >= 0 && result[cut] == ' ')
                                        cut--;
                                    result = result.Substring(0, cut + 1) + punctuation;
                                }
                            }

                            word = "";
                        }
                    }
                }

                result = result.Trim();

                if (result.Length > 0)
                {
                    _output = result;
                }
                else
                {
                    _output = null;
                }
            }

            private bool checkpart(string word, string part)
            {
                int wLen = word.Length;
                int pLen = part.Length;
                if (pLen > wLen) return false;

                for (int i = 0; i <= wLen - pLen; i++)
                {
                    bool match = true;
                    for (int j = 0; j < pLen; j++)
                    {
                        char a = word[i + j];
                        char b = part[j];

                        if (a >= 'A' && a <= 'Z') a = (char)(a + 32);
                        if (b >= 'A' && b <= 'Z') b = (char)(b + 32);

                        if (a >= 'А' && a <= 'Я') a = (char)(a + 32);
                        if (a == 'Ё') a = 'ё';

                        if (b >= 'А' && b <= 'Я') b = (char)(b + 32);
                        if (b == 'Ё') b = 'ё';

                        if (a != b)
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match) return true;
                }

                return false;
            }

            public override string ToString()
            {
                return _output;
            }
        }
    }

