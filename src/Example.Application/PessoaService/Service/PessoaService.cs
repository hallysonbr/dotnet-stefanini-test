using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Common;
using Example.Application.PessoaService.Models.DTOs;
using Example.Application.PessoaService.Models.Request;
using Example.Application.PessoaService.Models.Response;
using Example.Domain.PessoaAggregate;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.PessoaService.Service
{
    public class PessoaService : BaseService<PessoaService>, IPessoaService
    {
        private readonly ExampleContext _db;

        public PessoaService(ILogger<PessoaService> logger, ExampleContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.CreateAsync)}");

            if (request == null)
                throw new ArgumentException("Request empty!");

            var obj = Pessoa.Create(request.Nome, request.Cpf, request.CidadeId, request.Idade);

            await _db.Pessoas.AddAsync(obj);

            await _db.SaveChangesAsync();

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.CreateAsync)}");

            return new CreatePessoaResponse() { Id = obj.Id };
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.DeleteAsync)}");

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Object does not exists!");

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.DeleteAsync)}");

            return new DeletePessoaResponse();
        }

        public async Task<GetAllPessoaResponse> GetAllAsync()
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.GetAllAsync)}");

            var entity = await _db.Pessoas.Include(a => a.Cidade).ToListAsync();

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.GetAllAsync)}");

            return new GetAllPessoaResponse()
            {
                Pessoas = entity != null ? entity.Select(a => (PessoaDTO)a).ToList() : new List<PessoaDTO>()
            };
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.GetByIdAsync)}");

            var response = new GetByIdPessoaResponse();

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Pessoa = (PessoaDTO)entity;

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.GetByIdAsync)}");

            return response;
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.UpdateAsync)}");

            if (request == null)
                throw new ArgumentException("Request empty!");           

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.Cpf, request.CidadeId, request.Idade);
                await _db.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Object does not exists!");

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.UpdateAsync)}");

            return new UpdatePessoaResponse();
        }
    }
}