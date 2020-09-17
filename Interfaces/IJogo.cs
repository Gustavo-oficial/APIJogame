using API.Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Interfaces
{
    public interface IJogo
    {
        //Metodo para ler e mostar o item, no caso, o jogo que ja foram adicionados
        List<Jogo> Listar();

        //Metodo para buscar um jogo ja listado pelo seu respectivo nome
        List<Jogo> BuscarPorNome(string nome);

        //Metodo para buscar um jogo por um id
        Jogo BuscarPorId(Guid id);

        // Metodo para adicionar um jogo
        void Adicionar(Jogo jogo);

        //Metodo para alterar dados de um determinado jogo
        void Alterar(Jogo jogo);

        //Metodo para excluir um jogo da lista 
        void Excluir(Guid id);
    }
}
