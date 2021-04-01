using System;
using desafio_aplicacao_bancaria.Enum;

namespace desafio_aplicacao_bancaria.Classes
{
    public class Conta
    {

        //Atributos da Classe
        private string Nome {get; set;}

        private TipoConta Tipoconta {get; set;} //Classe criada de tipo Enum

        private double Saldo {get; set;}

        private double LimiteCredito {get; set;}


        public Conta (string nome, TipoConta tipoConta, double saldo, double limiteCredito) //Construtor da Classe
        {
            this.Nome = nome;
            this.Tipoconta = tipoConta;
            this.Saldo = saldo;
            this.LimiteCredito = limiteCredito;
        }

        //Métodos da classe:

        public bool Sacar(double valorSaque){
            if(Saldo - valorSaque < (this.LimiteCredito * -1)){
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque; //'-=' Diminui atribuindo
            Console.WriteLine("Saldo atual da conta do titular {0} é {1} .", this.Nome, this.Saldo);
            return true;

        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito; //'+=' Soma atribuindo
            Console.WriteLine("Saldo atual da conta do titular {0} é {1} .", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if(Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //Sobreescrevendo método herdado:
        public override string ToString(){
            string retorno="- ";
            retorno += "Tipo de conta: " + this.Tipoconta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Limite de Crédito: " + this.LimiteCredito + " -";
            return retorno;

        }


    }
}