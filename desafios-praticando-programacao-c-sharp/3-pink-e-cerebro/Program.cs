using System;

namespace _3_pink_e_cerebro
{
    class Program
    {
        static void Main(string[] args)
        {
            int suavariavel = int.Parse(Console.ReadLine());
            string[] valores = Console.ReadLine().Split(' ');
            int multiploDois=0, multiploTres=0, multiploQuatro=0, multiploCinco=0;
            
            for (int i=0; i<=valores.Length-1;i++)
            {
                int numero = int.Parse(valores[i]);
                if(numero%2 ==0){
                    multiploDois++;
                }
                if(numero%3 ==0){
                    multiploTres++;
                }
                if(numero%4 ==0){
                    multiploQuatro++;
                }
                if(numero%5 ==0){
                    multiploCinco++;
                }

            }
            Console.WriteLine("{0} Multiplo(s) de 2", multiploDois);
            Console.WriteLine("{0} Multiplo(s) de 3", multiploTres);
            Console.WriteLine("{0} Multiplo(s) de 4", multiploQuatro);
            Console.WriteLine("{0} Multiplo(s) de 5", multiploCinco);
        }
    }
}
