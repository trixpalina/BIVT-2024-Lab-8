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
        public Blue_2(string input, string part) : base(input)
        {
            _output = null;
            _part = part;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_part) || string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(' ');
            string ans = "";

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (!word.Contains(_part))
                {
                    if (ans.Length > 0)
                    {
                        ans += " " + word;
                    }
                    else
                    {
                        ans = ans + word;
                    }
                }
                else
                {
                    if (word.Length > 0 && char.IsPunctuation(word[0]))
                    {
                        if (ans.Length > 0)
                        {
                            ans += " " + word[0];
                        }
                        else
                        {
                            ans += word[0];
                        }
                    }
                    int len = word.Length;

                    if (len >= 2)
                    {
                        char secondLast = word[len - 2];
                        if (char.IsPunctuation(secondLast))
                        {
                            ans += secondLast;
                        }
                    }
                    if (len >= 1)
                    {
                        char last = word[len - 1];
                        if (char.IsPunctuation(last))
                        {
                            ans += last;
                        }
                    }

                }
                _output = ans.Trim();
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output)) return null;
            return _output;
        }
    }
}
