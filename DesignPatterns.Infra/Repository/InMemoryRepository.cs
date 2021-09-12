using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Domain;


namespace DesignPatterns.Infra.Repository
{
    public class InMemoryRepository : IVeiculoRepository
    {
        
        private readonly IList<Veiculo> entities = new List<Veiculo>();

        public Veiculo GetById(Guid id) => entities.SingleOrDefault(c => c.Id == id);

        public IEnumerable<Veiculo> GetAll()
         {
             return entities.ToList();
         }
         public void Add(Veiculo veiculo) => entities.Add(veiculo);
         public void Delete(Veiculo veiculo) => entities.Remove(veiculo);
         public void Update(Veiculo veiculo)
         {
             entities.Remove(GetById(veiculo.Id));
             entities.Add(veiculo);
         }
    }
}