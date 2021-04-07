using System;
using desafio_app_cadastro_series.Classes;

namespace desafio_app_cadastro_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            int opUser = ImprimirMenuUsuario();
            
            while(opUser !=0)
            {
                switch(opUser)
                {
                    case 1:
                        ListarSeries();
                        break;
                    case 2:
                        InserirSerie();
                        break;
                    case 3:
                        AtualizarSerie();
                        break;
                    case 4:
                        ExcluirSerie();
                        break;
                    case 5:
                        VisualizarSerie();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                }
                opUser = ImprimirMenuUsuario();
            }
            Console.WriteLine("Obrigado por usar o nosso sistema!!");
        }
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries cadastradas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "- Excluído -" : ""));
			}
		}
        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
		}
        private static void AtualizarSerie()
		{   
            if(repositorio.ProximoId()==0)
            {
                Console.WriteLine("Nenhuma série cadastrada. Favor cadastrar primeiro!");
                return;
            }

            int idLido;
            while((idLido = LerId())>= repositorio.ProximoId())
            {
                Console.WriteLine("Id maior que o numero de séries cadastradas");
            }

			int indiceSerie = idLido;

			foreach (int i in Enum.GetValues(typeof(Genero))) //Método que pega os valores dos itens no Enum
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i)); //Método que pega os rótulos (nomes) dos itens no Enum
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ExcluirSerie()
		{
			// Console.Write("Digite o id da série: ");
			// int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(LerId()); //Método implementado, para centralizar a leitura do Id
		}
        private static void VisualizarSerie()
		{
            // Console.Write("Digite o id da série: ");
            // int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(LerId()); 
			Console.WriteLine(serie);
		}
        private static int LerId(){
            Console.Write("Digite o id da série: ");
			return int.Parse(Console.ReadLine());
        }
        private static int ImprimirMenuUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informa a opção desejada: ");
            Console.WriteLine();

            Console.WriteLine("1 - Listar séries;");
            Console.WriteLine("2 - Inserir nova série;");
            Console.WriteLine("3 - Atualizar série;");
            Console.WriteLine("4 - Excluir série;");
            Console.WriteLine("5 - Visualizar série;");
            Console.WriteLine("6 - Limpar tela;");
            Console.WriteLine("0 - Sair;");
            Console.WriteLine();

            int opcaoUsuario = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
