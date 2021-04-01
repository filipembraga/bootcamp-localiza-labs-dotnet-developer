using System;
using System.Collections.Generic;
using desafio_aplicacao_bancaria.Classes;
using desafio_aplicacao_bancaria.Enum;

namespace desafio_aplicacao_bancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>(); //Lista a popular os dados na memória
        static void Main(string[] args)
        {                            
        //Testes usados no começo do desafio:
            // Conta minhaConta = new Conta("Filipe Braga", (Enum.TipoConta)1,500,150);
            // Conta minhaConta2 = new Conta("Bruno Oliveira", (Enum.TipoConta)2,5000,950);

            // Console.WriteLine(minhaConta.ToString());
            // Console.WriteLine(minhaConta2.ToString());

            // minhaConta.Sacar(50);
            // minhaConta.Depositar(500);
            // minhaConta.Sacar(700);
            // minhaConta.Transferir(200,minhaConta2);
            // Console.WriteLine(minhaConta.ToString());
            // Console.WriteLine(minhaConta2.ToString());
          
            int opUser = ImprimirMenuUsuario();
            
            while(opUser !=0)
            {
                switch(opUser)
                {
                    case 1:
                        ListarContas();
                        break;
                    case 2:
                        InserirConta();
                        break;
                    case 3:
                        Transferir();
                        break;
                    case 4:
                        Sacar();
                        break;
                    case 5:
                        Depositar();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                                
                }

                opUser = ImprimirMenuUsuario();
            }

            Console.WriteLine("Obrigado por usar o nosso sistema!!");
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta: ");
            
            Console.WriteLine("Digite 1 para Pessoa Física OU 2 para Pessoa Jurídica");
            int inputTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do titular: ");
            string inputNome = (Console.ReadLine());

            Console.WriteLine("Digite o saldo inicial da conta: ");
            int inputSaldo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o limite de crédito: ");
            int inputLimiteCredito = int.Parse(Console.ReadLine());

            Conta novaConta = new Conta( tipoConta: (TipoConta)inputTipoConta,
                    nome: inputNome,
                    saldo: inputSaldo,
                    limiteCredito: inputLimiteCredito);

            listaContas.Add(novaConta);  
        }

        private static void ListarContas()
        {   
            Console.WriteLine("Listar contas: ");

            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada");
            }

            for(int i=0; i<listaContas.Count; i++)
            {
                Console.Write("#{0} ", (i+1));
                Console.WriteLine(listaContas[i]);

            }
        }
        private static void Sacar()
        {
            Console.WriteLine("Efetuar saque: ");

            Console.WriteLine("Digite o ID da conta: ");
            int inputId = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser sacado: ");
            double inputSaque = double.Parse(Console.ReadLine());

            listaContas[inputId].Sacar(inputSaque);
        }
        private static void Depositar()
        {
            Console.WriteLine("Efetuar depósito: ");

            Console.WriteLine("Digite o ID da conta: ");
            int inputId = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser depositado: ");
            double inputDeposito = double.Parse(Console.ReadLine());

            listaContas[inputId].Depositar(inputDeposito);
        }
        private static void Transferir()
        {
            Console.WriteLine("Efetuar transferência: ");
            
            Console.WriteLine("Digite o ID da sua conta: ");
            int inputIdDepositante = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID da comta a receber o depósito: ");
            int inputIdDestinatário = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double inputValorTransferencia = double.Parse(Console.ReadLine());

            listaContas[inputIdDepositante].Transferir(inputValorTransferencia, listaContas[inputIdDestinatário]);
        }
        private static int ImprimirMenuUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informa a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1 - Listar contas;");
            Console.WriteLine("2 - Inserir nova conta;");
            Console.WriteLine("3 - Transferir;");
            Console.WriteLine("4 - Sacar;");
            Console.WriteLine("5 - Depositar;");
            Console.WriteLine("6 - Limpar tela;");
            Console.WriteLine("0 - Sair;");
            Console.WriteLine();

            int opcaoUsuario = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
