using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Common;
using Example.Application.PessoaService.Models.DTOs;

namespace Example.Application.PessoaService.Models.Response
{
    public class GetAllPessoaResponse : BaseResponse
    {
        public List<PessoaDTO> Pessoas { get; set; }
    }
}