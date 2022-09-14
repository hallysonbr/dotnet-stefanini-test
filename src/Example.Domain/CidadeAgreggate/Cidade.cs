using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Domain.CidadeAgreggate
{
    public class Cidade
    {
        public Cidade(string nome, string uF)
        {
            this.Nome = nome;
            this.UF = uF;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public static Cidade Create(string nome, string uf)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Invalid " + nameof(nome));

            if(nome.Length > 200)
                throw new NomeInvalidException();
            
            if(string.IsNullOrWhiteSpace(uf))
                throw new ArgumentException("Invalid " + nameof(uf));

             if(uf.Length != 2)
                throw new UFInvalidException();
            
            return new Cidade(nome, uf);
        }

        public void Update(string nome, string uf)
        {
            if((!string.IsNullOrWhiteSpace(nome)) && nome.Length <= 200)
                Nome = nome;
            
            if((!string.IsNullOrWhiteSpace(uf)) && uf.Length == 2)
                UF = uf;
        }        
    }
}