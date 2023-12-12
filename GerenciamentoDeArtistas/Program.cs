using System.Runtime.CompilerServices;
using GerenciamentoDeArtistas;

internal class Program
{
    private static GerenciadorDeArquivo manager;

    private static void Main(string[] args)
    {
        var stopKey = "0";
        var selectedMenu = "";
        manager = new GerenciadorDeArquivo(); 
        
        while (stopKey != selectedMenu)
        {
            Console.WriteLine("1 - Cadastrar Artista");
            Console.WriteLine("2 - Cadastrar Músicas");
            Console.WriteLine("3 - Apagar Artista");
            Console.WriteLine("4 - Apagar música");
            Console.WriteLine("5 - Exibir artista e suas músicas");
            Console.WriteLine("6 - Editar artista e músicas");
            Console.WriteLine("0 - Sair do programa");

            selectedMenu = Console.ReadLine();

            ExercutarOpcao(selectedMenu);

        }
    }

    private static void ExercutarOpcao(string? selectedMenu)
    {
        switch(selectedMenu)
        {
            case "1":
                CadastrarArtista();
                break;

            case "2":
                CadastrarMusica();
                break;

            case "3": 
                ApagarArtista();
                break;

            case "4":
                ApagarMusica();
                break;

            case "5":
                ExibirArtistaEMusica();
                break;

                case "6":
                EditarArtista();
                break;
            case "0":
                manager.SalvarListas();
                Console.WriteLine("Saindo do programa...");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    private static void CadastrarArtista()
    {
        Artista artista = new Artista();
        
        Console.WriteLine("Digite o nome do artista");
        artista.Nome = Console.ReadLine();

        Console.WriteLine("Digite o nome do país de origem do artista:");
        artista.Nacionalidade = Console.ReadLine();

        Console.WriteLine("Digite a data de nascimento do artista");
        artista.DataNascimento = Convert.ToDateTime(Console.ReadLine());


        manager.AdicionarArtista(artista);
        
    }

     private static void CadastrarMusica()
    {
        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if (artista == null) {
            Console.WriteLine("Não encontrei o artista");
            return;
        }

        Musica musica = new Musica();

        Console.WriteLine("Digite o nome da musica");
        musica.Nome = Console.ReadLine();

        Console.WriteLine("Digite o genero da música:");
        musica.Genero = Console.ReadLine();

        manager.CadastrarMusica(musica);
        artista.Musicas.Add(musica);
        
       // artista.AdicionarMusica(musica);
       

    }

    private static void ExibirArtistaEMusica()
    {
        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if (artista == null) {
            Console.WriteLine("Não encontrei o artista");
            return;
        }

        Console.WriteLine($"Nome do aluno: {artista.Nome}");
        Console.WriteLine($"Data de Nascimento {artista.DataNascimento}");
        Console.WriteLine($"================= Músicas do Artista ===================");

        if(artista.Musicas == null){
            Console.WriteLine("Músicas não encontradas");
            return;
        }

        foreach (var item in artista.Musicas)
        {
            Console.WriteLine($"Nome da música: {item.Nome}");
            Console.WriteLine($"Genero da música: {item.Genero}");
            Console.WriteLine("");
        }

    }

    private static void ApagarArtista(){
        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

         if (artista == null) {
            Console.WriteLine("Não encontrei o artista");
            return;
        }

        manager.RemoverArtista(artista);

    }

    private static void ApagarMusica(){

        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista1 = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

       Console.WriteLine("Digite o nome da musica");
        string nomeMusica = Console.ReadLine();
        Musica musica = manager.Musicas.FirstOrDefault(x => x.Nome == nomeMusica);
        

        if (musica == null) {
            Console.WriteLine("Não encontrei a música");
            return;
        }

        if (artista1 == null) {
            Console.WriteLine("Não encontrei o artista");
            return;
        }

        artista1.Musicas.Remove(musica);
        manager.RemoverMusica(musica);

    }

    private static void EditarArtista(){
         Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

         if (artista == null) {
            Console.WriteLine("Não encontrei o artista");
            return;
        }


        Console.WriteLine("1 - Editar Nome");
        Console.WriteLine("2 - Editar nacionalidade");
        Console.WriteLine("3 - Editar Data de nascimento");
        Console.WriteLine("4 - Editar músicas");
        
        String op = Console.ReadLine();


        switch(op){
            case "1":        
                    Console.WriteLine("Digitar o novo nome");
                    artista.Nome = Console.ReadLine();
            break;

            case "2":
                    if(artista.Nome.Equals(nomeArtista)){
                        Console.WriteLine("Digitar a nova nacionalidade");
                        artista.Nacionalidade = Console.ReadLine();
                    }
            break;

            case "3":
                    Console.WriteLine("Digitar a nova data de nascimento");
                    artista.DataNascimento = Convert.ToDateTime(Console.ReadLine());
            break;

            case "4":
                Console.WriteLine("Digitar o nome da música");
                String nomeMusica = Console.ReadLine();

                foreach(var item in artista.Musicas){
                    if(item.Nome.Equals(nomeMusica)){
                        Console.WriteLine("Digitar o novo nome da música");
                         String NovoNome = Console.ReadLine();
                         item.Nome = NovoNome;
                         manager.EditarMusica(nomeMusica, NovoNome);
                    }
                }
            break;


            default:

            Console.WriteLine("Erro");

            break;
        }
    }
}