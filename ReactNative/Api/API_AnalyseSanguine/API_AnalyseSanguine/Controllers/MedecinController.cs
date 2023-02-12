using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Services.Interfaces;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/medecin")]
    [Produces("application/json")]
    public class MedecinController : ControllerBase
    {
        private readonly IMedecinService _service;

        public MedecinController(IMedecinService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedecin()
        {
            try
            {
                var result = _service.GetAllMedecin();
                if (result == null)
                {
                    return Problem();
                }
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedecin(int id)
        {
            try
            {
                var result = _service.GetMedecin(id);
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
        public async Task<IActionResult> CreateMedecin(Medecin medecin)
        {
            try
            {
                var result = _service.CreateMedecin(medecin);
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
        public async Task<IActionResult> UpdateMedecin(int id, Medecin medecin)
        {
            try
            {
                var result = _service.UpdateMedecin(id, medecin);
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
        public async Task<IActionResult> DeleteMedecin(int id)
        {
            try
            {
                var result = _service.DeleteMedecin(id);
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
