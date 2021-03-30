using System;

namespace _3_aumento_salario
{
    class Program
    {
        static void Main(string[] args)
        {

            double salario, percentual, reajuste, novoSalario;
            salario = Convert.ToDouble(Console.ReadLine());
            
            if(salario==0){
                reajuste = salario * 0.15; 
                novoSalario = salario + reajuste;
                percentual = 0;
                Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
                Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
                Console.WriteLine("Em percentual: {0} %", percentual);
            }
            else if(salario >= 0.0 && salario <= 400.0){
                reajuste = salario * 0.15;
                novoSalario = salario + reajuste;
                percentual = ((novoSalario - salario) * 100) / salario;
                Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
                Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
                Console.WriteLine("Em percentual: {0} %", percentual);
            }
            else if(salario > 400.0 && salario <= 800.0){
                reajuste = salario * 0.12;
                novoSalario = salario + reajuste;
                percentual = ((novoSalario - salario) * 100) / salario;
                Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
                Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
                Console.WriteLine("Em percentual: {0} %", percentual);
            }
            else if(salario > 800.0 && salario <= 1200.0){
                reajuste = salario * 0.10;
                novoSalario = salario + reajuste;
                percentual = Math.Round(((novoSalario - salario) * 100) / salario);
                Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
                Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
                Console.WriteLine("Em percentual: {0} %", percentual);
            }
            else if(salario > 1200.0 && salario <= 2000.0){
                reajuste = salario * 0.07;
                novoSalario = salario + reajuste;
                percentual = ((novoSalario - salario) * 100) / salario;
                Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
                Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
                Console.WriteLine("Em percentual: {0} %", percentual);
            }
            else if(salario > 2000.0){
                reajuste = salario * 0.04;
                novoSalario = salario + reajuste;
                percentual = Math.Round(((novoSalario - salario) * 100) / salario);
                Console.WriteLine("Novo salario: {0:0.00}", novoSalario);
                Console.WriteLine("Reajuste ganho: {0:0.00}", reajuste);
                Console.WriteLine("Em percentual: {0} %", percentual);
            }
        }
    }
}
