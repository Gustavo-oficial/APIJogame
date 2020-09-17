using API.Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Interfaces
{
    public interface IJogador
    {
        ////Metodo para ler e mostrar os jogadores ja cadastrados
        List<Jogador> Listar();

        //Metodo para procurar um jogador pelo seu respectivo nome
        List<Jogador> BuscarPorNome(string nome);

        //Metodo para procurar um jogador pelo seu id
        Jogador BuscarPorId(Guid id);

        //Metodo para cadastrar um jogador
        void Cadastrar(Jogador jogador);

        //Metodo para alterar dados de um determinado jogador
        void Alterar(Jogador jogador);

        //Metodo para excluir um jogador da lista 
        void Excluir(Guid id);
    }
}
