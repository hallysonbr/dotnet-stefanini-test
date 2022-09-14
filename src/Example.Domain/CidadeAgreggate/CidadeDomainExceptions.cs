using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Domain.CidadeAgreggate
{
    public class UFInvalidException : ArgumentException
    {
        public UFInvalidException() : base("UF length must be 2.")
        {
        }
    }

    public class NomeInvalidException : ArgumentException
    {
        public NomeInvalidException() : base("Nome max length is 200.")
        {
        }
    }
}