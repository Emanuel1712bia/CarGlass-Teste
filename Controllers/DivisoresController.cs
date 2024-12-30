using Microsoft.AspNetCore.Mvc;
using NprimoAPI.Services;
using System.Collections.Generic;

namespace NprimoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisoresController : ControllerBase
    {
        private readonly DivisoresService _divisoresService;

        public DivisoresController(DivisoresService divisoresService)
        {
            _divisoresService = divisoresService;
        }

        [HttpGet("divisores")]
        public ActionResult<IEnumerable<int>> GetDivisores(int numero)
        {
            var divisores = _divisoresService.EncontrarDivisores(numero);
            return Ok(divisores);
        }

        [HttpGet("divisoresprimos")]
        public ActionResult<IEnumerable<int>> GetDivisoresPrimos(int numero)
        {
            var divisores = _divisoresService.EncontrarDivisores(numero);
            var primos = _divisoresService.EncontrarPrimos(divisores);
            return Ok(primos);
        }
    }
}