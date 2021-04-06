using System;

namespace _2_crescimento_populacional
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine()); //número de casos de teste
            double[] arrayList = new double[4];
            int pa, pb; //população de A e população de B
            double cpa, cpb; //crescimento populacional de A e de B
            int anos; //Anos até ultrapassar

            for (int i = 0; i < t; i++)
            {
                anos = 0;
                string[] valores = Console.ReadLine().Split(' ');
                pa = int.Parse(valores[0]);
                pb = int.Parse(valores[1]);

                cpa = double.Parse(valores[2])/100;
                cpb = double.Parse(valores[3])/100;

                while (pa <= pb)
                {
                    pa = pa + (int)(pa * cpa);
                    pb = pb + (int)(pb * cpb);
                    anos++;

                    if (anos > 100)
                    {
                        Console.WriteLine("Mais de 1 seculo.");
                        break;
                                          
                    }
                }

                if (anos <= 100)
                {
                    Console.WriteLine("{0} anos.", anos); 
                }

            }
        }
    }
}
