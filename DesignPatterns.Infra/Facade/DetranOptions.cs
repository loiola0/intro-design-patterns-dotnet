using System;

namespace DesignPatterns.Infra.Facade
{
    public class DetranOptions
    {
        public Guid Id {get;set;} = Guid.NewGuid();

        public string BaseUrl {get;set;}

        public string VistoriaUri {get;set;}

        public int QuantidadeDiasParaAgendamento {get;set;}

    }
}