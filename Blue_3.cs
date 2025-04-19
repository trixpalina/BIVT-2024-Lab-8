using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return new (char, double)[0];

                (char, double)[] newarr = new (char, double)[_output.Length];
                for (int i = 0; i < _output.Length; i++)
                    newarr[i] = _output[i];
                return newarr;
            }
        }

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
                return;


            int[] counts = new int[54765];
            int total = 0;
            int i = 0;

            while (i < Input.Length)
            {
                while (i < Input.Length && punkt(Input[i]))
                {
                    i++;
                }
                if (i >= Input.Length) break;

                int start = i;

                while (i < Input.Length && !punkt(Input[i])) i++;

                if (start < i)
                {
                    char ch = Input[start];


                    if (ch >= 'A' && ch <= 'Z') ch = (char)(ch + 32);
                    if (ch >= 'А' && ch <= 'Я') ch = (char)(ch + 32);


                    bool isLatin = (ch >= 'a' && ch <= 'z');
                    bool isCyrillic = (ch >= 'а' && ch <= 'я') || ch == 'ё';

                    if (isLatin || isCyrillic)
                    {
                        counts[ch]++;
                        total++;
                    }
                }
            }

            int unique = 0;
            for (int j = 0; j < counts.Length; j++)
                if (counts[j] > 0)
                    unique++;

            _output = new (char, double)[unique];
            int index = 0;

            for (int j = 0; j < counts.Length; j++)
            {
                if (counts[j] > 0)
                {
                    double percent = Math.Round(counts[j] * 100.0 / total, 4);
                    _output[index++] = ((char)j, percent);
                }
            }


            for (int x = 0; x < _output.Length - 1; x++)
            {
                for (int y = x + 1; y < _output.Length; y++)
                {
                    if (_output[y].Item2 > _output[x].Item2 ||
                       (_output[y].Item2 == _output[x].Item2 && _output[y].Item1 < _output[x].Item1))
                    {
                        var temp = _output[x];
                        _output[x] = _output[y];
                        _output[y] = temp;
                    }
                }
            }
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return "";

            string res = "";
            for (int i = 0; i < _output.Length; i++)
            {
                res += _output[i].Item1 + " - " + _output[i].Item2.ToString("F4");
                if (i < _output.Length - 1)
                    res += "\n";
            }

            return res;
        }

        private bool punkt(char c)
        {
            return c == ' ' || c == '.' || c == '!' || c == '?' || c == ',' || c == ':' || c == '"' ||
                   c == ';' || c == '–' || c == '(' || c == ')' || c == '[' || c == ']' ||
                   c == '{' || c == '}' || c == '/';
        }
    }
}
