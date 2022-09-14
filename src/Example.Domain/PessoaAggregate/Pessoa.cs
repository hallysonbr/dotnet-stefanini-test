using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.CidadeAgreggate;

namespace Example.Domain.PessoaAggregate
{
    public class Pessoa
    {
        public Pessoa(string nome, string cpf, int cidadeId, int idade)
        {
             this.Nome = nome;
             this.Cpf = cpf;
             this.CidadeId = cidadeId;
             this.Idade = idade;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int CidadeId { get; private set; }
        public int Idade { get; private set; }
        
        public virtual Cidade Cidade { get; private set; }

         public static Pessoa Create(string nome, string cpf, int cidadeId, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome)) 
                throw new ArgumentException("Invalid " + nameof(nome));

            if(nome.Length > 300)
                throw new NomeInvalidException();

            if (string.IsNullOrWhiteSpace(cpf)) 
                throw new ArgumentException("Invalid " + nameof(cpf));

            if(cpf.Length != 11)
                throw new CpfInvalidException();

            if(cidadeId == 0)
                throw new ArgumentException("Invalid " + nameof(Cidade));

            if (idade == 0)
                throw new ArgumentException("Invalid " + nameof(idade));


            return new Pessoa(nome, cpf, cidadeId, idade);
        }

        public void Update(string nome, string cpf,int cidadeId, int idade)
        {
            if((!string.IsNullOrWhiteSpace(nome)) && nome.Length <= 300)
                Nome = nome;

            if ((!string.IsNullOrWhiteSpace(nome)) && cpf.Length == 11) 
                Cpf = cpf;

            if(cidadeId != 0)
                CidadeId = cidadeId;

            if (idade != 0)
                Idade = idade;       
        }
    }
}