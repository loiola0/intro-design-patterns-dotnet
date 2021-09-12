using System;
using System.Collections.Generic;
using DesignPatterns.Domain;
using Microsoft.EntityFrameworkCore;



namespace DesignPatterns.Infra.Repository.EF
{
    public class DesignRepository : IVeiculoRepository
    {

        private readonly DesignContext dbContext;

        public DesignRepository(DesignContext dbContext) => this.dbContext = dbContext;

        public void Add(Veiculo veiculo)
        {
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => dbContext.Veiculos.ToListAsync().Result;
    
        public Veiculo GetById(Guid id) => dbContext.Veiculos.SingleOrDefaultAsync().Result;

        public void Update(Veiculo veiculo)
        {
           dbContext.Entry(veiculo).State = EntityState.Modified;
           dbContext.SaveChanges();
        }
    }
}