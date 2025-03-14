using Biblioteca.Data;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LivroController : ControllerBase
    {
        readonly AppDbContext _context;

        public LivroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var livros = _context.Livros.ToList();

            return Ok(livros);
        }

        [HttpGet("GetLivroById")]
        public IActionResult Get(int id)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null)
                return BadRequest("Não foi possível encontrar o livro solicitado");

            return Ok(livro);
        }

        [HttpGet("GetLivroByTitulo")]
        public IActionResult Get(string titulo)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.Titulo == titulo);
            if (livro == null)
                return BadRequest("Não foi possível encontrar o livro solicitado");

            return Ok(livro);
        }

        [HttpGet("GetLivroByAutor")]
        public IActionResult Get(string livros)
        {
            var livros = _context.Livros.Where(x => x.Autor == livros.Autor);
            if (livros == null)
                return BadRequest($"Não foi possível encontrar os livros de {livros.Autor}");

            return Ok(livros);
        }
    }
}
