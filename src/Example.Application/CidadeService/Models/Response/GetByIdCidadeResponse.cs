using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.CidadeService.Models.DTOs;

namespace Example.Application.CidadeService.Models.Response
{
    public class GetByIdCidadeResponse
    {
        public CidadeDTO Cidade { get; set; }
    }
}