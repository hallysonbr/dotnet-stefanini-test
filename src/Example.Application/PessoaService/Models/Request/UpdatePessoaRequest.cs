using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Application.PessoaService.Models.Request
{
    public class UpdatePessoaRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int CidadeId { get; set; }
        public int Idade { get; set; }
    }
}