﻿using System;

namespace _2_ddd
{
    class Program
    {
        static void Main(string[] args)
        {
            int numddd;

            Console.WriteLine("Digite o DDD: ");

            numddd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(); 

            switch(numddd){
                case 11:
                    Console.WriteLine("São Paulo");
                    break;
                case 19:
                    Console.WriteLine("Campinas");
                    break;
                case 21:
                    Console.WriteLine("Rio de Janeiro");
                    break;
                case 27:
                    Console.WriteLine("Vitória");
                    break;
                case 31:
                    Console.WriteLine("Belo Horizonte");
                    break;
                case 32:
                    Console.WriteLine("Juiz de Fora");
                    break;
                case 61:
                    Console.WriteLine("Brasilia");
                    break;
                case 71:                             
                    Console.WriteLine("Salvador");
                    break;
                default:
                    Console.WriteLine("DDD nao cadastrado");        
                    break;         
            }
        }
    }
}