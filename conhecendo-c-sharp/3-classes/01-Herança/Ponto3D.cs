namespace Classes.Herança
{
    public class Ponto3D : Ponto // ':' servem pra dizer que herda de outra classe. No exemplo Ponto3D herda de Ponto.
                                 // Em c# só é possível herdar de uma classe, atualmente.

    {
        public int z; // Complemento das variáveis herdadas 'x' e 'y'.

        //Passa para a base o ponto como ':base(x,y)':
        public Ponto3D(int x, int y, int z) : base(x, y) 

        {
            this.z = z;
            CalcularDistancia();
        }

        public static void Calcular() //
        {
            //Faz alguma coisa...
        }
        public override void CalcularDistancia3()
        {
            //Faz outra coisa ...
            base.CalcularDistancia3(); // Chama o método da classe base.
        }
    }
}