using System;

namespace ConsumoMedioAutomovel
{
    class Program
    {
        static void Main(string[] args)
        {
            int dist;
            double comb, media; //float - 4 bytes; double - 8 bytes; decimal - 16 bytes

           // dist = Console.ReadLine(); //Não é possível converter implicitamente String (retorno do Console.Realine) para Int
            dist = Convert.ToInt32(Console.ReadLine());
            comb = Convert.ToDouble(Console.ReadLine());
            media = dist / comb;

            //Essa saída é didática, não retornando o resultado esperado pelo console do curso, que seria apenas "{0:0.000} km/l".
            Console.WriteLine("O consumo médio percorrendo {1} km gastando {2} litros é {0:0.000} km/l", media, dist, comb); 

        }
    }
}