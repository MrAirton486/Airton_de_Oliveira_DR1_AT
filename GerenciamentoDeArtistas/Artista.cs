using System.Dynamic;

namespace GerenciamentoDeArtistas;


public class Artista{
    public String Nome { get; set; }

    public String Nacionalidade { get; set; }

    public DateTime DataNascimento { get; set; }



    public List<Musica> Musicas {get;set;}

    public void AdicionarMusica(Musica musicas) 
    {
        if (this.Musicas == null) {
            this.Musicas = new List<Musica>(); 
        }
        
        this.Musicas.Add(musicas);
    }



}