using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Common;

namespace Example.Application.PessoaService.Models.Response
{
    public class CreatePessoaResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}