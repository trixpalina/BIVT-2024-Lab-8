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
                        string originalWord = word;
                        string clean = "";
                        string punctuation = "";
                        char wrapperStart = '\0', wrapperEnd = '\0';
                        bool hasWrappers = false;

                        if ((word.StartsWith("(") && word.EndsWith(")")) ||
                            (word.StartsWith("\"") && word.EndsWith("\"")) ||
                            (word.StartsWith("«") && word.EndsWith("»")))
                        {
                            wrapperStart = word[0];
                            wrapperEnd = word[word.Length - 1];
                            word = word.Substring(1, word.Length - 2);
                            hasWrappers = true;
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
                            if (!string.IsNullOrWhiteSpace(result))
                                result += " ";

                            if (wrapperStart != '\0')
                                result += wrapperStart;

                            result += clean;

                            if (wrapperEnd != '\0')
                                result += wrapperEnd;

                            result += punctuation;
                        }

                        word = "";
                    }
                }
            }

            result = result.Trim();

            _output = result.Length > 0 ? result : null;
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

                    a = char.ToLower(a);
                    b = char.ToLower(b);

                    if (a == 'ё') a = 'е';
                    if (b == 'ё') b = 'е';

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
