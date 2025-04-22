using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            {
                _output = null;
                return;
            }


            char[] pun = { ' ', '?', '!', '.', ':', ';', '\"', ',', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(pun, StringSplitOptions.RemoveEmptyEntries);
            int[] letter = new int[65674];
            int total = 0;
            foreach (string n in words)
            {
                if (n.Length != 0)
                {
                    char count = char.ToLower(n[0]);

                    if (char.IsLetter(count))
                    {
                        letter[count]++;
                        total++;
                    }
                }

            }
            int k = 0;
            for (int i = 0; i < letter.Length; i++)
            {
                if (letter[i] > 0)
                {
                    k++;
                }
            }

            _output = new (char, double)[k];
            int t = 0;
            for (int i = 0; i < letter.Length; i++)
            {
               
                double res;
                if (letter[i] > 0)
                {
                    double result = letter[i] * 100.0 / total;
                    res = Math.Round(result, 4);

                    _output[t++] = ((char)i, res); 
                }
            }

            if (_output == null || _output.Length == 0) return;

            for (int i = 0; i < _output.Length; i++)
            {
                for (int j = 0; j < _output.Length - i - 1; j++)
                {
                    if (_output[j].Item2 < _output[j + 1].Item2)
                    {
                        var temp = _output[j];
                        _output[j] = _output[j + 1];
                        _output[j + 1] = temp;
                    }

                    else if (_output[j].Item2 == _output[j + 1].Item2)
                    {
                        if (_output[j].Item1 > _output[j + 1].Item1)
                        {
                            var temp = _output[j];
                            _output[j] = _output[j + 1];
                            _output[j + 1] = temp;
                        }
                    }
                }
                //for (int x = 0; x < _output.Length - 1; x++)
                //{
                //    for (int y = x + 1; y < _output.Length; y++)
                //    {
                //        if (_output[y].Item2 > _output[x].Item2 ||
                //           (_output[y].Item2 == _output[x].Item2 && _output[y].Item1 < _output[x].Item1))
                //        {
                //            var temp = _output[x];
                //            _output[x] = _output[y];
                //            _output[y] = temp;
                //        }
                //    }
                }
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            string res = "";
            for (int i = 0; i < _output.Length; i++)
            {
                res =res + ($"{_output[i].Item1} - {_output[i].Item2:f4}");

                if (i != _output.Length - 1)
                    res += Environment.NewLine;
            }
            return res;
        }
    }

}
