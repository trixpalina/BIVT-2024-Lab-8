using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;

        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                return;
            }

            int sum = 0;
            int i = 0;

            while (i < Input.Length)
            {
                if (!(Input[i] >= '0' && Input[i] <= '9') && Input[i] != '-')
                {
                    i++;
                    continue;
                }

                int flag = 0;
                if (Input[i] == '-')
                {
                    if (i + 1 < Input.Length && Input[i+1] >= '0' && Input[i+1] <= '9')
                    {
                        flag = 1;
                        i++;
                    }
                    else
                    {
                        i++; 
                        continue;
                    }
                }

                int n = 0;
                while (i < Input.Length && Input[i] >= '0' && Input[i] <= '9')
                {
                    int digit = Input[i] - '0';

                    n = n * 10 + digit;
                    i++;
                }

                if (flag == 1)
                {
                    n = -n;
                }

                sum += n;
            }

            _output = sum;
        } //public override void Review()

 
        public override string ToString()
        {
            return $"{_output}";
        }
    }
}
