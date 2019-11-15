using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Term_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            Console.Write("Enter the Number of Rows : ");
            input = int.Parse(Console.ReadLine());

            binaryRightAngleTriangle(input);

            Console.ReadLine();
        }

        static void binaryRightAngleTriangle(int n)
        {
            int p, last = 0, input;
            input = n;

            for (int i = 1; i <= input; i++)
            {
                for (p = 1; p <= i; p++)
                {
                    if (last == 1)
                    {
                        Console.Write("0");
                        last = 0;
                    }
                    else if (last == 0)
                    {
                        Console.Write("1");
                        last = 1;
                    }
                }
                Console.Write("\n");
            }
        }


    }
}
