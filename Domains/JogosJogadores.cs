using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Domains
{
    public class JogosJogadores : BaseDomains
    {

        public Guid IdJogador { get; set; }
        [ForeignKey("IdJogador")]
        public Jogador Jogador { get; set; }


        public Guid IdJogo { get; set; }
        [ForeignKey("IdJogo")]
        public Jogo Jogo { get; set; }
    }
}
