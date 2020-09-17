using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Jogame.Domains;
using API.Jogame.Interfaces;
using API.Jogame.Repositories;
using API.Jogame.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogo _jogoRepo;

        public JogoController()
        {
            _jogoRepo = new JogoRepository();
        }

        /// <summary>
        /// Ler todos os jogos já cadastrados
        /// </summary>
        /// <returns>Lista de jogos</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogos = _jogoRepo.Listar();

                if (jogos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = jogos.Count,
                    data = jogos
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/produtos"
                });
            }
        }

        /// <summary>
        /// Busca um único jogo
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <returns>Jogo buscado</returns>

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Jogo jogo = _jogoRepo.BuscarPorId(id);

                if (jogo == null)
                    return NotFound();

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um jogo no sistema
        /// </summary>
        /// <param name="jogo">Obejto completo de um jogo</param>
        /// <returns>Jogo cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Jogo jogo)
        {
            try
            {
                if (jogo.Imagem != null)
                {
                    var urlImagem = Upload.Local(jogo.Imagem);

                    jogo.UrlImagem = urlImagem;
                }
                _jogoRepo.Adicionar(jogo);

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera determinado jogo do sistema
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <param name="jogo">Objeto alterado do jogo</param>
        /// <returns>Jogo alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogo jogo)
        {
            try
            {
                var jogotemp = _jogoRepo.BuscarPorId(id);

                if (jogotemp == null)
                    return NotFound();

                jogo.Id = id;
                _jogoRepo.Alterar(jogo);

                return Ok(jogo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um jogo do sistema
        /// </summary>
        /// <param name="id">ID do jogo a ser excluído</param>
        /// <returns>ID do jogo excluído</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogoRepo.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}