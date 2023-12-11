using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using GerenciamentoDeArtistas;


namespace GerenciamentoDeArtistas;

public class GerenciadorDeArquivo
{
    public List<Artista> Artistas = new List<Artista>();
    public List<Musica> Musicas = new List<Musica>();

    public GerenciadorDeArquivo()
    {
        this.IniciarListas();
    }

    public void IniciarListas()
    {
        if (File.Exists("artistas.json") == false)
            File.Create("artistas.json").Close();

        if (File.Exists("musicas.json") == false)
            File.Create("musicas.json").Close();

        using (StreamReader reader = new StreamReader(File.OpenRead("artistas.json")))
        {
            try
            {
                string content = reader.ReadToEnd();
                this.Artistas = JsonSerializer.Deserialize<List<Artista>>(content);
                reader.Close();
            }
            catch { }
        }

        using (StreamReader reader = new StreamReader(File.OpenRead("musicas.json")))
        {
            try
            {
                string content = reader.ReadToEnd();
                this.Musicas = JsonSerializer.Deserialize<List<Musica>>(content);
                reader.Close();
            }
            catch { }
        }
    }

    public void SalvarListas()
    {
        if (File.Exists("artistas.json"))
            File.Delete("artistas.json");

        using (StreamWriter writer = new StreamWriter(File.Open("artistas.json", FileMode.OpenOrCreate)))
        {
            string json = JsonSerializer.Serialize<List<Artista>>(Artistas);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }

        if (File.Exists("musicas.json"))
            File.Delete("musicas.json");

        using (StreamWriter writer = new StreamWriter(File.Open("musicas.json", FileMode.OpenOrCreate)))
        {
            string json = JsonSerializer.Serialize<List<Musica>>(Musicas);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }
    }

    public void AdicionarArtista(Artista artista)
    {
        this.Artistas.Add(artista);
    }

    public void CadastrarMusica(Musica musica){
        this.Musicas.Add(musica);
    }

    public void RemoverArtista(Artista artista)
    {
        this.Artistas.Remove(artista);
    }

    public void RemoverMusica(Musica musica)
    {
        this.Musicas.Remove(musica);
    }

     public void EditarMusica(String NomeMusica, String NovoNome)
    {
        foreach(var item in Musicas){
            if(item.Nome.Equals(NomeMusica)){
                item.Nome = NovoNome;
                 
            }
        }
    }

}