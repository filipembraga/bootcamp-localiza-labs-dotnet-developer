using System;
using EstruturaDoPrograma.Exemplos;

namespace EstruturaDoPrograma
{

// Esse é o programa principal
    class Program
    {
        static void Main()
        {
            var s = new Pilha(); //Instanciação da variável
            
            //Chamados do método Empilha:
            s.Empilha(1); 
            s.Empilha(10);
            s.Empilha(100);

            //Chamados do método Desempilha:
            Console.WriteLine(s.Desempilha()); 
            Console.WriteLine(s.Desempilha());
            Console.WriteLine(s.Desempilha());
            Console.WriteLine(s.Desempilha()); //Forçando a exception
        }
    }
}