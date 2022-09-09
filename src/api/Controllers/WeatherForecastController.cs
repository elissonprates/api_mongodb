using aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    readonly PrimeiroServico _primeiroServico;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, PrimeiroServico primeiroServico)
    {
        _logger = logger;

        _primeiroServico = primeiroServico;
    }

    [HttpGet]
    public IActionResult Get(int? codigo)
    {
        return Ok(_primeiroServico.Obter(codigo));
    }
}