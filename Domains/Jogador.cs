﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Domains
{
    public class Jogador : BaseDomains
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
