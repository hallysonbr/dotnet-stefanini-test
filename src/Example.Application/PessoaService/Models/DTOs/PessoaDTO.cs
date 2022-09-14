using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.CidadeAgreggate;

namespace Example.Application.PessoaService.Models.DTOs
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Cidade Cidade { get; set; }
        public int Idade { get; set; }

        public static explicit operator PessoaDTO(Domain.PessoaAggregate.Pessoa v)
        {
            return new PessoaDTO()
            {
                Id = v.Id,
                Nome = v.Nome,
                Cpf = v.Cpf,
                Cidade = v.Cidade,
                Idade = v.Idade
            };
        }
    }
}