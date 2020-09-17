using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Jogame.Domains
{
    public class Jogo : BaseDomains
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [NotMapped]

        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; }

        public DateTime DataLancamento { get; set; }
    }
}
