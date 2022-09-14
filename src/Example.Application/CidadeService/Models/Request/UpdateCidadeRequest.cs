using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Application.CidadeService.Models.Request
{
    public class UpdateCidadeRequest
    {
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}