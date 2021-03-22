namespace Classes.Herança
{
    public class Ponto
    {
        public int x, y;
        private int distancia; // Variável privada, para conter a distância.
        
        
        public Ponto(int x, int y) // Construtor da classe
        {
            // Notações de referência a própria classe:
            this.x = x;
            this.y = y;
        }

        protected void CalcularDistancia() // Método acessível a quem herda. 
        {
            //Faz alguma coisa...
          
            CalcularDistancia2();
        }

        private void CalcularDistancia2() // Só pode ser usado dentro da classe ou em seus métodos, por exemplo, dentro de CalcularDistancia().
        {
            //Faz alguma coisa...
        }

        public virtual void CalcularDistancia3() // 'virtual' permite que a classe filha sobreescreva a ação do método. 
        {
            //Faz alguma coisa...
        }
    }
}