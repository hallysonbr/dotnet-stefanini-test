using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.CidadeService.Models.DTOs;
using Example.Application.CidadeService.Models.Request;
using Example.Application.CidadeService.Models.Response;
using Example.Application.Common;
using Example.Domain.CidadeAgreggate;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.CidadeService.Service
{
    public class CidadeService : BaseService<CidadeService>, ICidadeService
    {
         private readonly ExampleContext _db;

        public CidadeService(ILogger<CidadeService> logger, ExampleContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.CreateAsync)}");

            if (request == null)
                throw new ArgumentException("Request empty!");

            var obj = Cidade.Create(request.Nome, request.UF);

            await _db.Cidades.AddAsync(obj);

            await _db.SaveChangesAsync();

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.CreateAsync)}");

            return new CreateCidadeResponse() { Id = obj.Id };
        }

        public async Task<DeleteCidadeResponse> DeleteAsync(int id)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.DeleteAsync)}");

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Object does not exists!");

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.DeleteAsync)}");

            return new DeleteCidadeResponse();
        }

        public async Task<GetAllCidadeResponse> GetAllAsync()
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.GetAllAsync)}");
            
            var entity = await _db.Cidades.ToListAsync();
            
            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.GetAllAsync)}");

            return new GetAllCidadeResponse()
            {
                Cidades = entity != null ? entity.Select(a => (CidadeDTO)a).ToList() : new List<CidadeDTO>()
            };
        }

        public async Task<GetByIdCidadeResponse> GetByIdAsync(int id)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.GetByIdAsync)}");

            var response = new GetByIdCidadeResponse();

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Cidade = (CidadeDTO)entity;

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.GetByIdAsync)}");

            return response;
        }

        public async Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request)
        {
            RegisterLog("Executando", $"{this.GetType().Name}|{nameof(this.UpdateAsync)}");

            if (request == null)
                throw new ArgumentException("Request empty!");            
            
            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.UF);
                await _db.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Object does not exists!");

            RegisterLog("Finalizado", $"{this.GetType().Name}|{nameof(this.UpdateAsync)}");

            return new UpdateCidadeResponse();
        }
    }
}