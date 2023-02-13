using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/resultat")]
    [Produces("application/json")]
    public class ResultatController : ControllerBase
    {
        private readonly IResultatService _service;

        public ResultatController(IResultatService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResultat()
        {
            try
            {
                var result = _service.GetAllResultat();
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
        public async Task<IActionResult> GetResultat(int id)
        {
            try
            {
                var result = _service.GetResultat(id);
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
        public async Task<IActionResult> CreateResultat(ResultatAnalyse resultat)
        {
            try
            {
                var result = _service.CreateResultat(resultat);
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateResultat(int id, ResultatAnalyse resultat)
        {
            try
            {
                var result = _service.UpdateResultat(id, resultat);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultat(int id)
        {
            try
            {
                var result = _service.DeleteResultat(id);
                if (result == false)
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
