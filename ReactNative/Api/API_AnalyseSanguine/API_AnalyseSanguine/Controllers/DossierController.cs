using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API_AnalyseSanguine.Services;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/dossier")]
    [Produces("application/json")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class DossierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

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
                return StatusCode(200, result);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("getdetaille")]
        public async Task<IActionResult> GetDossierDetaille(int id)
        {
            try
            {
                var result = _service.GetDossierDetaille(id);
                return StatusCode(200, result);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<IActionResult> CreateDossier(Dossier dossier)
        {
            try
            {
                var result = _service.CreateDossier(dossier);
                return StatusCode(200, result);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateDossier(int id, Dossier dossier)
        {
            try
            {
                var result = _service.UpdateDossier(dossier.IdDossier, dossier);
                return StatusCode(200, result);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDossier(long id)
        {
            try
            {
                var result = _service.DeleteDossier(id);
                return StatusCode(200, result);
            }
            catch
            {
                return Problem();
            }
        }
    }
}
