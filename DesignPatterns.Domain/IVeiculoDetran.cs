using System;
using System.Threading.Tasks;

namespace DesignPatterns.Domain
{
    public interface IVeiculoDetran
    {
         public Task AgendarVistoriaDetran(Guid veiculoId);
    
    }
}