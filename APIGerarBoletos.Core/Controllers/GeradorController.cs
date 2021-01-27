using System;
using System.Linq;
using APIGerarBoletos.Models;
using APIGerarBoletos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIGerarBoletos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeradorController : ControllerBase
    {
        private readonly ILogger<GeradorController> _logger;

        public GeradorController(ILogger<GeradorController> logger)
        {
            //_logger = logger;
        }

        [HttpPost]
        public BoletoOut Post(BoletoIn boletoIn)
        {
            GeradorItauV2 geradorItau = new GeradorItauV2();

            if (boletoIn.Teste)
                geradorItau.GerarBoletoTeste(boletoIn);
            //else
            //    geradorItau.GerarBoleto(boletoIn);

            return new BoletoOut();
        }
    }
}
