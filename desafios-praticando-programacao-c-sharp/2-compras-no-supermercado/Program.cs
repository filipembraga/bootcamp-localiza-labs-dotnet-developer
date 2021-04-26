using System;
using System.Collections.Generic;

namespace _2_compras_no_supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalDeCasosDeTeste = int.Parse(Console.ReadLine());
            SortedSet<string> listaCompras;
            
            for(int i=1; i<=totalDeCasosDeTeste; i++){
                string[] valores = Console.ReadLine().Split(' ');
                listaCompras = new SortedSet<string> (valores);
                
                foreach(var n in listaCompras){
                    Console.Write(n.Replace(" ",""));
                    Console.Write(' ');
                }
                listaCompras.Clear();
                Console.WriteLine();
            }
        }
    }
}
