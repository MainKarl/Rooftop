using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/typevaleur")]
    [Produces("application/json")]
    public class TypeValeurController : ControllerBase
    {
        private readonly ITypeValeurService _service;

        public TypeValeurController(ITypeValeurService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypeValeur()
        {
            try
            {
                var result = _service.GetAllTypeValeur();
                if (result == null)
                {
                    return Problem();
                }
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeValeur(long id)
        {
            try
            {
                var result = _service.GetTypeValeur(id);
                if (result == null)
                {
                    return Problem();
                }
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTypeValeur(TypeValeur typeValeur)
        {
            try
            {
                var result = _service.CreateTypeValeur(typeValeur);
                if (result == null)
                {
                    return Problem();
                }
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
