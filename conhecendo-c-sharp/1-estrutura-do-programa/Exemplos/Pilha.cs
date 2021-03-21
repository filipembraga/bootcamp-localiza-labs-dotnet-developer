using System;

namespace EstruturaDoPrograma.Exemplos //Como boa prática o namespace é o nome do projeto.
{
    public class Pilha //Declaração da classe
    {
        Posicao primeiro; //Propriedade
        public void Empilha(object item) //Método
        {
            primeiro = new Posicao(primeiro, item); //Construtor
        }

        public object Desempilha() //Segundo método da classe

        {
            if (primeiro == null)
            {
                throw new InvalidOperationException("A pilha está vazia!"); //Exceção disparada em certa condição - Operação inválida
            }

            object resultado = primeiro.item;
            primeiro = primeiro.proximo;
            return resultado;
        }
        
        class Posicao //Classe aninhada ou subclasse
        {
            public Posicao proximo;
            public object item;
            public Posicao(Posicao proximo, object item)
            {
                this.proximo = proximo;
                this.item = item;
            }
        }
    }
}
