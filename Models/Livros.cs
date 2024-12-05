namespace Biblioteca.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoLancamento { get; set; }
        public int Qtd { get; set; }

        public List<Locatario> Locatarios { get; set; }

    }
}
