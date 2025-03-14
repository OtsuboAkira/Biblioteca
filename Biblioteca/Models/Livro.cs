namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public DateOnly AnoPublicacao { get; set; }
        public bool Disponivel { get; set; }
        public int Edicao { get; set; }

        public Livro(string titulo, string autor, string editora, DateOnly anoPublicacao, bool disponivel, int edicao)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editora = editora;
            this.AnoPublicacao = anoPublicacao;
            this.Disponivel = disponivel;
            this.Edicao = edicao;
        }
        public Livro() { }
    }
}
