using System;

namespace Instrucoes
{
    class Program
    {
        static void Declaracoes() //Método estático com declarações de variável
        {
            //Declaração das variáveis:
            int a;
            int b = 2, c = 3;
            const int d = 4; //Constante de valor 4
            a = 1; //Atribuição de valor a variável 'a'

            //Operação de soma com as variáveis:
            Console.WriteLine(a + b + c + d);
        }

        static void InstrucaoIf(string[] args) //Método estático com instrução condicional If
        {
            if (args.Length == 0) //'.Length' retorna tamanho
            {
                Console.WriteLine("Nenhum argumento");
            }
            else if (args.Length == 1) //Encadeada de If
            {
                Console.WriteLine("Um argumento");
            }
            else //Todo restante
            {
                Console.WriteLine($"{args.Length} argumentos"); //Interpolação de Strings concatenando a String usando '$'
            }
        }

        // Para comentar um trecho do código use 'Ctrl + K + C'
        // Para descomentar use 'Ctrl + ;'

        static void InstrucaoSwitch(string[] args)
        {
            int numeroDeArgumentos = args.Length; //Armazena o valor do tamanho a uma variável local
            switch (numeroDeArgumentos)
            {
                case 0:
                    Console.WriteLine("Nenhum argumento");
                    break;  //Interrompe a execução do Switch
                case 1:
                    Console.WriteLine("Um argumento");
                    break;
                default:
                    Console.WriteLine($"{numeroDeArgumentos} argumentos");
                    break;
            }
        }

        static void InstrucaoWhile(string[] args)
        {
            int i = 0;
            while (i < args.Length) 
            {
                Console.WriteLine(args[i]);
                i++; // Incrementa o i
            }
        }

        static void InstrucaoDo(string[] args)
        {
            string texto;
            do // Executa ao menos uma vez antes de passar pelo while
            {
                texto = Console.ReadLine();
                Console.WriteLine(texto);
            } while (!string.IsNullOrEmpty(texto)); //'!' faz a negativa da expressão > Enquanto o texto NÃO for nulo ou vazio 
        }

        static void InstrucaoFor(string[] args)
        {
            for (int i = 0; i < args.Length; i++) 
            {
                Console.WriteLine(args[i]);
            }
        }

        static void InstrucaoForeach(string[] args) // Trabalha com objetos de certo tipo criado. Mais simples de usar.
        {
            foreach (string s in args) // Para cada string do array de strings.
            {
                Console.WriteLine(s);
            }
        }

        static void InstrucaoBreak(string[] args)
        {
            while (true)
            {
                string s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                
                // Como só existe um comando na instrução, as chaves são opcionais. É algo verboso, recomendado no começo.
                { 
                    break;
                }

                Console.WriteLine(s);
            }
        }

        static void InstrucaoContinue(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("/"))
                {
                    continue; // Vai para o próximo item do For.
                }
                
                Console.WriteLine(args[i]);
            }
        }

        static void InstrucaoReturn(string[] args) // Método void não retorna nada.
        {
            int Somar(int a, int b)
            {
                return a + b; // O somar vai retornar o valor de a + b
            }

            Console.WriteLine(Somar(1, 2));
            Console.WriteLine(Somar(3, 4));
            Console.WriteLine(Somar(5, 6));
            return; // Mesmo não retornando valores por ser void, o Return serve para parar a execução do método.
        }

        static void InstrucoesTryCatchFinallyThrow(string[] args)
        {
            double Dividir(double x, double y)
            {
                if (y == 0)
                    throw new DivideByZeroException(); // Exceção pronta do DOTNET de divisão por zero, sendo tratada.

                return x / y;
            }

            try 
            // Tenta fazer o que está dentro da instrução TRY.
            {
                if (args.Length != 2)
                {
                    throw new InvalidOperationException("Informe 2 números"); 
                }

                double x = double.Parse(args[0]);
                double y = double.Parse(args[1]);
                Console.WriteLine(Dividir(x, y));
            }

            // Caso a exceção aconteça durante o TRY, os CATCHs tratam.
            catch (InvalidOperationException e) // Se não passar dois argumentos ele pega a exception do throw.
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) // Outras exceções não tratadas caem nesse genérico.
            {
                Console.WriteLine($"Erro genérico: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Até breve!"); // O que será executado dando certo ou errado, no final.
            }
        }

        static void InstrucaoUsing(string[] args)
        {

            // System.IO.TextWriter w;
            // System.IO.File.CreateText("texte.txt");

            // w.WriteLine("xxxxx");

            // w.Dispose(); <<< Elimina objeto

            // Usando Using em I/O são objetos não gerenciados, que ficam em memória. Se fossem usados diretamente no código, conforme acima, teriam que ser finalizados com o Dispose()
            using (System.IO.TextWriter w = System.IO.File.CreateText("teste.txt")) 
            {
                w.WriteLine("Line 1");
                w.WriteLine("Line 2");
                w.WriteLine("Line 3");
            } // Fim do objeto elimina ele da memória.
        }
    }
}
