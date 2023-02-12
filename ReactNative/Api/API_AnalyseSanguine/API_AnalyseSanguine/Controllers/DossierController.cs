using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API_AnalyseSanguine.Services.Interfaces;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/dossier")]
    [Produces("application/json")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class DossierController : ControllerBase
    {
        private readonly IDossierService _service;

        public DossierController(IDossierService service)
        {
            _service = service;
        }

        [HttpGet("getsimple")]
        public async Task<IActionResult> GetDossierSimple()
        {
            try
            {
                var result = _service.GetDossierSimple();
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

        [HttpGet("getdetaille")]
        public async Task<IActionResult> GetDossierDetaille(int id)
        {
            try
            {
                var result = _service.GetDossierDetaille(id);
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
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<IActionResult> CreateDossier(Dossier dossier)
        {
            try
            {
                var result = _service.CreateDossier(dossier);
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
        public async Task<IActionResult> UpdateDossier(int id, Dossier dossier)
        {
            try
            {
                var result = _service.UpdateDossier(id, dossier);
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
        public async Task<IActionResult> DeleteDossier(long id)
        {
            try
            {
                var result = _service.DeleteDossier(id);
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
