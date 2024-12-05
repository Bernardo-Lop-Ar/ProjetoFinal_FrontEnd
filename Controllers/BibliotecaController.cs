using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private static List<Livros> livros = new List<Livros>
        {
            new Livros
            {
                Id = 1,
                Titulo = "Dom Casmurro",
                Autor = "Machado de Assis",
                AnoLancamento = 1899,
                Qtd = 2

            },
            new Livros
            {
                Id = 2,
                Titulo = "Memórias Póstumas de Brás Cubas",
                Autor = "Machado de Assis",
                AnoLancamento = 1881,
                Qtd = 3
            },
            new Livros
            {
                Id = 3,
                Titulo = "Grande Sertão: Veredas",
                Autor = "João Guimarães Rosa",
                AnoLancamento = 1956,
                Qtd = 4
            },
            new Livros
            {
                Id = 4,
                Titulo = "O Cortiço",
                Autor = "Aluísio Azevedo",
                AnoLancamento = 1890,
                Qtd = 4
            },
            new Livros
            {
                Id = 5,
                Titulo = "Iracema",
                Autor = "José de Alencar",
                AnoLancamento = 1865,
                Qtd = 1
            },
            new Livros
            {
                Id = 6,
                Titulo = "Macunaíma",
                Autor = "Mário de Andrade",
                AnoLancamento = 1928,
                Qtd = 11
            },
            new Livros
            {
                Id = 7,
                Titulo = "Capitães da Areia",
                Autor = "Jorge Amado",
                AnoLancamento = 1937,
                Qtd = 2
            },
            new Livros
            {
                Id = 8,
                Titulo = "Vidas Secas",
                Autor = "Graciliano Ramos",
                AnoLancamento = 1938,
                Qtd = 9
            },
            new Livros
            {
                Id = 9,
                Titulo = "A Moreninha",
                Autor = "Joaquim Manuel de Macedo",
                AnoLancamento = 1844,
                Qtd = 2
            },
            new Livros
            {
                Id = 10,
                Titulo = "O Tempo e o Vento",
                Autor = "Erico Verissimo",
                AnoLancamento = 1949,
                Qtd = 1
            },
            new Livros
            {
                Id = 11,
                Titulo = "A Hora da Estrela",
                Autor = "Clarice Lispector",
                AnoLancamento = 1977,
                Qtd = 1
            },
            new Livros
            {
                Id = 12,
                Titulo = "O Quinze",
                Autor = "Rachel de Queiroz",
                AnoLancamento = 1930,
                Qtd = 1
            },
            new Livros
            {
                Id = 13,
                Titulo = "Menino do Engenho",
                Autor = "José Lins do Rego",
                AnoLancamento = 1932,
                Qtd = 5
            },
            new Livros
            {
                Id = 14,
                Titulo = "Sagarana",
                Autor = "João Guimarães Rosa",
                AnoLancamento = 1946,
                Qtd = 3
            },
            new Livros
            {
                Id = 15,
                Titulo = "Fogo Morto",
                Autor = "José Lins do Rego",
                AnoLancamento = 1943,
                Qtd = 1
            }
        };

        [HttpGet]
        public ActionResult<List<Livros>>
            VerLivros()
        {
            return Ok(livros);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Livros>
        LerUnicoPersonagem(int id)
        {
            var unico = livros.Find(x => x.Id == id);

            if (unico is null)
                return NotFound("Este livro não foi encontrado");

            return Ok(unico);
        }


        private static List<Locatario> usuario = new List<Locatario>();


        [HttpPost("{id}")]
        public ActionResult<List<Locatario>>
            EmprestarLivro(int id, Locatario novo)
        {
            if (novo.Id == 0 && usuario.Count > 0)
                novo.Id = usuario[usuario.Count - 1].Id + 1;

            var livro = livros.Find(l => l.Id == id); 
            if (livro != null && livro.Qtd > 0)
            {
                livro.Qtd--;
                usuario.Add(novo);
                return Ok("Locação realizada com sucesso!!");
            }
            else
            {
                return BadRequest("Livro não disponível");
            }
        }








    }
}
