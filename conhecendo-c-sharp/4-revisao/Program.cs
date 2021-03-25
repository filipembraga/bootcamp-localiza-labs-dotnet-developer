using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5]; //Array de alunos pré alocado com 5 alunos.
            var indiceAluno = 0; //Poderia ser usado 'int aluno' também.
            string opcaoUsuario = ObterOpcaoUsuario(); //Lista de comandos que estava duplicada e foi extraída para baixo enquanto um método.

            while (opcaoUsuario.ToUpper() != "X") //Valida as opções selecionadas pelo usuário, para manter o fluxo do programa. 'ToUpper' garante que minúsculas também serão aceitas.
            {
                switch (opcaoUsuario)
                {
                    case "1": //Adicionar aluno
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)) //Valida se o dado inserido pode ser transformado em decimal e cria com 'out decimal' a variável a ser preenchida.
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal"); //Exception para os casos em que o Parse não funciona.
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++; //Incrementa índice do array para garantir que serão apenas 5

                        break;
                    case "2": //Listar alunos
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome)) //Para não imprimir os não preenchidos dentro do array
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3": //Calcular média geral.
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                       
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        { 
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(); //Excpetion que trata argumentos fora da lista do Case.
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()

        //Menu para usuários
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine(); //Comando obtem informação do usuário.
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
