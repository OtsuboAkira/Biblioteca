using Biblioteca.Data;
using Biblioteca.Models;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null)
                return BadRequest("Não foi possível encontrar o livro solicitado");

            return Ok(livro);
        }

        [HttpGet("GetLivroByTitulo/{titulo}")]
        public IActionResult GetLivroByTitulo(string titulo)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.Titulo == titulo);
            if (livro == null)
                return BadRequest("Não foi possível encontrar o livro solicitado");

            return Ok(livro);
        }

        [HttpGet("GetLivroByAutor/{autor}")]
        public IActionResult GetlivroByAutor(string autor)
        {
            var livrosAutor = _context.Livros.Where(x => x.Autor.ToLower().Contains(autor.ToLower())).ToList();
            if (livrosAutor == null)
                return BadRequest($"Não foi possível encontrar os livros de {autor}");

            return Ok(livrosAutor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livro cadastroLivro)
        {
            _context.Livros.Add(cadastroLivro);
            if (cadastroLivro == null)
                return BadRequest("Falha ao tentar adicionar o livro a biblioteca! Por gentileza revise os dados inseridos");

            _context.SaveChanges();

            return Ok(cadastroLivro);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Livro livro)
        {
            var updateLivro = _context.Livros.FirstOrDefault(x => x.Id == livro.Id);
            if (updateLivro == null)
                return BadRequest("Não foi possível encontrar o livro solicitado");

            updateLivro.Titulo = livro.Titulo;
            updateLivro.Autor = livro.Autor;
            updateLivro.Editora = livro.Editora;
            updateLivro.AnoPublicacao = livro.AnoPublicacao;
            updateLivro.Editora = livro.Editora;
            updateLivro.Disponivel = livro.Disponivel;
            updateLivro.Edicao = livro.Edicao;

            _context.Livros.Update(updateLivro);

            _context.SaveChanges();

            return Ok(updateLivro);
        }

        [HttpPut("PutLivroByTitulo")]
        public IActionResult PutLivroByTitulo([FromBody] Livro livro)
        {
            var updateLivro = _context.Livros.FirstOrDefault(x => x.Titulo.ToLower().Contains(livro.Titulo.ToLower()));
            if (updateLivro == null)
                return BadRequest($"Não foi possível encontrar o livro {livro.Titulo}");

            updateLivro.Titulo = livro.Titulo;
            updateLivro.Autor = livro.Autor;
            updateLivro.Editora = livro.Editora;
            updateLivro.AnoPublicacao = livro.AnoPublicacao;
            updateLivro.Editora = livro.Editora;
            updateLivro.Disponivel = livro.Disponivel;
            updateLivro.Edicao = livro.Edicao;

            _context.Livros.Update(updateLivro);

            _context.SaveChanges();

            return Ok(updateLivro);
        }
    }
}
