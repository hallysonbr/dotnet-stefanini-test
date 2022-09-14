using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Application.CidadeService.Models.DTOs
{
    public class CidadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public static explicit operator CidadeDTO(Domain.CidadeAgreggate.Cidade v)
        {
            return new CidadeDTO()
            {
                Id = v.Id,
                Nome = v.Nome,
                UF = v.UF
            };
        }
    }
}