using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Jogame.Domains;
using API.Jogame.Interfaces;
using API.Jogame.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly IJogador _jogadorRepo;

        public JogadorController()
        {
            _jogadorRepo = new JogadorRepository();
        }

        /// <summary>
        /// Ler todos os jogadores já cadastrados
        /// </summary>
        /// <returns>Lista de jogadores</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogadores = _jogadorRepo.Listar();

                if (jogadores.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = jogadores.Count,
                    data = jogadores
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
        /// Busca um único jogador
        /// </summary>
        /// <param name="id">ID do jogador</param>
        /// <returns>Jogador buscado</returns>

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Jogador jogador = _jogadorRepo.BuscarPorId(id);

                if (jogador == null)
                    return NotFound();

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um jogador no sistema
        /// </summary>
        /// <param name="jogador">Obejto completo de um jogador</param>
        /// <returns>Jogador cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Jogador jogador)
        {
            try
            {
                _jogadorRepo.Cadastrar(jogador);

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera determinado jogador do sistema
        /// </summary>
        /// <param name="id">ID do jogador</param>
        /// <param name="jogador">Objeto alterado do jogador</param>
        /// <returns>Jogador alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogador jogador)
        {
            try
            {
                var jogadortemp = _jogadorRepo.BuscarPorId(id);

                if (jogadortemp == null)
                    return NotFound();

                jogador.Id = id;
                _jogadorRepo.Alterar(jogador);

                return Ok(jogador);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um jogador do sistema
        /// </summary>
        /// <param name="id">ID do jogador a ser excluído</param>
        /// <returns>ID do jogador excluído</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogadorRepo.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}