namespace Classes.Metodos
{
    public class Ref
    {
        static void Inverter(ref int x, ref int y) // Sem o 'ref' as variáveis de tipo valor, dentro do método, não alteram fora. 
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void Inverter()
        {
            int i = 1, j = 2;
            Inverter(ref i, ref j);
            System.Console.WriteLine($"{i} {j}");    // Escreveria "2 1"
        }
    }
}