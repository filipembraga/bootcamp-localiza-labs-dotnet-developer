using System;
using Classes.Herança;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Ponto p1 = new Ponto(10,20); // Cria objeto da classe ponto.

            Ponto3D p2 = new Ponto3D(10,20,30); // Cria objeto da classe filha, ponto3D.

            //p2.Calcular(); <<< Não é acessível pelo objeto, pois é um método estático

            Ponto3D.Calcular(); // Método estático é acessível pela classe.

        }
    }
}
