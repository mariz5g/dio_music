using System;

namespace DIO.Music
{
    class Program
    {
      static MusicRepository repository = new MusicRepository();
        static void Main(string[] args)
        {
          string userOption = getUserOption();

          while(userOption.ToUpper() != "X")
          {
            switch(userOption)
            {
              case "1":
                ListMusics();
                break;
              case "2":
                InsertMusic();
                break;
              case "3":
                UpdateMusic();
                break;
              case "4":
                DeleteMusic();
                break;
              case "5":
                viewMusic();
                break;
              case "C":
                Console.Clear();
                break;
              default:
                throw new ArgumentOutOfRangeException();
            }

            userOption = getUserOption();
          }

          Console.WriteLine("Obrigado por utilizar nossos serviços.");
          Console.ReadLine();
        }

        private static void ListMusics()
        {
          Console.Clear();
          Console.WriteLine("Todas as músicas:");

          var list = repository.List();

          if(list.Count == 0)
          {
            Console.WriteLine("Nenhuma música encontrada!");
            Console.ReadLine();
            Console.Clear();
            return;
          }

          foreach(var music in list)
          {
            var deleted = music.returnDeleted();
            if(!deleted)
            {
              Console.WriteLine("#ID {0}: - {1}", music.returnId(), music.returnTitle());
            }
          }

          Console.ReadLine();
        }

        private static void InsertMusic()
        {
          Console.Clear();
          Console.WriteLine("Cadastrar nova música:");

          foreach(int i in Enum.GetValues(typeof(Genre)))
          {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
          }
          Console.WriteLine();

          Console.Write("Digite o genêro da música [Entre as opções acima]: ");
          int inputGenre = int.Parse(Console.ReadLine());

          Console.Write("Digite o título da música: ");
          string inputTitle = Console.ReadLine();

          Console.Write("Digite o ano de lançamento: ");
          int inputYear = int.Parse(Console.ReadLine());

          Console.Write("Digite o nome do Canto/Banda: ");
          string inputAuthor = Console.ReadLine(); 

          Music newMusic = new Music(
            id: repository.NextId(),
            genre: (Genre)inputGenre,
            title: inputTitle,
            year: inputYear,
            author: inputAuthor
          );

          repository.Insert(newMusic);
        }

        private static void UpdateMusic()
        {
          Console.Clear();
          Console.Write("Digite o id da música: ");
          int indexMusic = int.Parse(Console.ReadLine());

          foreach(int i in Enum.GetValues(typeof(Genre)))
          {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
          }

          Console.Write("Digite o genêro da música [Entre as opções acima]: ");
          int inputGenre = int.Parse(Console.ReadLine());

          Console.Write("Digite o título da música: ");
          string inputTitle = Console.ReadLine();

          Console.Write("Digite o ano de lançamento: ");
          int inputYear = int.Parse(Console.ReadLine());

          Console.Write("Digite o nome do Canto/Banda: ");
          string inputAuthor = Console.ReadLine();

          Music updateMusic = new Music(
            id: indexMusic,
            genre: (Genre)inputGenre,
            title: inputTitle,
            year: inputYear,
            author: inputAuthor
          );

          repository.Update(indexMusic, updateMusic);
        }

        private static void DeleteMusic()
        {
          Console.Clear();
          Console.Write("Digite o id da música: ");
          int indexMusic = int.Parse(Console.ReadLine());

          repository.Delete(indexMusic);
        }

        private static void viewMusic()
        {
          Console.Clear();
          Console.Write("Digite o id da música: ");
          int indexMusic = int.Parse(Console.ReadLine());

          var music = repository.ReturnById(indexMusic);

          Console.WriteLine(music);
          Console.ReadLine();
        }

        private static string getUserOption()
        {
          Console.Clear();
          Console.WriteLine();
          Console.WriteLine("DIO Music");
          Console.WriteLine("Informe a opção desejada:");
          Console.WriteLine("1- Listar músicas");
          Console.WriteLine("2- Add nova música");
          Console.WriteLine("3- Atualizar música");
          Console.WriteLine("4- Deletar música");
          Console.WriteLine("5- Visualizar música");
          Console.WriteLine("C- Limpar tela");
          Console.WriteLine("X- Sair");

          Console.WriteLine();
          Console.Write("> ");
          string userOption = Console.ReadLine().ToUpper();
          Console.WriteLine();

          return userOption;
        }
    }
}
