using API.Jogame.Context;
using API.Jogame.Domains;
using API.Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Repositories
{
    public class JogadorRepository : IJogador
    {
        private readonly JogameContext _ctx;

        public  JogadorRepository()
        {
            _ctx = new JogameContext();
        }

        public void Alterar(Jogador jogador)
        {
            try
            {
                Jogador jogadortemp = BuscarPorId(jogador.Id);

                if (jogador == null)
                    throw new Exception("Pedido não encontrado");

                jogadortemp.Nome = jogador.Nome;
                jogadortemp.Email = jogador.Email;
                jogadortemp.Senha = jogador.Senha;
                jogadortemp.DataNasc = jogador.DataNasc;

                _ctx.Jogador.Update(jogadortemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Jogador BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogador.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jogador> BuscarPorNome(string nome)
        {
            try
            {
                List<Jogador> jogador = _ctx.Jogador.Where(c => c.Nome.Contains(nome)).ToList();
                return jogador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Cadastrar(Jogador jogador)
        {
            try
            {
                _ctx.Jogador.Add(jogador);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Jogador jogador = BuscarPorId(id);

                if (jogador == null)
                    throw new Exception("Jogador não encontrado");

                _ctx.Jogador.Remove(jogador);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jogador> Listar()
        {
            try
            {
                return _ctx.Jogador.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
