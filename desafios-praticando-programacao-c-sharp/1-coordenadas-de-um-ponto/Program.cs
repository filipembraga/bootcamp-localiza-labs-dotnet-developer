﻿using System;

namespace _1_coordenadas_de_um_ponto
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            string[] valores = Console.ReadLine().Split(' ');
            x = double.Parse(valores[0]);
            y = double.Parse(valores[1]);

            if(x==0.0 & y==0.0){
                Console.WriteLine("Origem");
            } else if (x==0.0){
                Console.WriteLine("Eixo Y");
            } else if (y==0.0){
                Console.WriteLine("Eixo X");
            } else if (x>0.0 & y>0.0){
                Console.WriteLine("Q1");
            } else if (x<0.0 & y>0.0){
                Console.WriteLine("Q2");
            } else if (x<0.0 & y<0.0){
                Console.WriteLine("Q3");
            } else {
                Console.WriteLine("Q4");
            }
        }
    }
}
