using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DesignPatterns.Domain;


namespace DesignPatterns.Infra.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        
        private readonly IOptionsMonitor<DetranOptions> _optionsMonitor;

        private readonly DetranOptions detranOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor,IHttpClientFactory httpClientFactory,IVeiculoRepository veiculoRepository)
        {
            _optionsMonitor = optionsMonitor;
            _httpClientFactory = httpClientFactory;
            _veiculoRepository = veiculoRepository;
        }

        public async Task AgendarVistoriaDetran(Guid veiculoId)
        {
            var veiculo = _veiculoRepository.GetById(veiculoId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(detranOptions.BaseUrl); 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(detranOptions.QuantidadeDiasParaAgendamento)
            };

            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(detranOptions.VistoriaUri, contentString);

        }
    }
}