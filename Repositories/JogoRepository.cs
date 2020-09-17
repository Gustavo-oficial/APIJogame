using API.Jogame.Context;
using API.Jogame.Domains;
using API.Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Repositories
{
    public class JogoRepository : IJogo
    {
        private readonly JogameContext _ctx;

        public JogoRepository()
        {
            _ctx = new JogameContext();
        }

        /// <summary>
        /// Adiciona um novo jogo
        /// </summary>
        /// <param name="jogo">Jogo a ser adcionado</param>
        public void Adicionar(Jogo jogo)
        {
            try
            {
                _ctx.Jogo.Add(jogo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita os dados de um jogo da lista
        /// </summary>
        /// <param name="jogo">Dados do jogo</param>
        public void Alterar(Jogo jogo)
        {
            try
            {
                Jogo jogotemp = BuscarPorId(jogo.Id);

                if (jogo == null)
                    throw new Exception("Pedido não encontrado");

                jogotemp.Nome = jogo.Nome;
                jogotemp.Descricao = jogo.Descricao;
                jogotemp.DataLancamento = jogo.DataLancamento;
               
                _ctx.Jogo.Update(jogotemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns></returns>
        public Jogo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogo.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o jogo pelo nome
        /// </summary>
        /// <param name="nome">Nome do jogo</param>
        /// <returns>Retorna um jogo</returns>

        public List<Jogo> BuscarPorNome(string nome)
        {
            try
            {
                List<Jogo> jogo = _ctx.Jogo.Where(c => c.Nome.Contains(nome)).ToList();
                return jogo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um jogo da lista 
        /// </summary>
        /// <param name="id">Id do jogo</param>
        public void Excluir(Guid id)
        {
            try
            {
                Jogo jogo = BuscarPorId(id);

                if (jogo == null)
                    throw new Exception("Jogo não encontrado");

                _ctx.Jogo.Remove(jogo);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Lista de jogos</returns>
        public List<Jogo> Listar()
        {
            try
            {
                return _ctx.Jogo.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
