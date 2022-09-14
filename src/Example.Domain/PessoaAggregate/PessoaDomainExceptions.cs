using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Domain.PessoaAggregate
{
    public class CpfInvalidException : ArgumentException
    {
       public CpfInvalidException() : base("CPF length must be 11.")
       {
       }
    }

    public class NomeInvalidException : ArgumentException
    {
        public NomeInvalidException() : base("Nome max lenght is 300.")
        {
        }
    }     
}