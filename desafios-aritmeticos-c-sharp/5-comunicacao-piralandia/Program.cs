using System;

namespace _5_comunicacao_piralandia
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string v = "";
                
            for (int i=0; i<n.Length; i++)
            {
                v += n[n.Length-i-1];
            }

            Console.WriteLine("{0}\n",v);
        }
    }
}
