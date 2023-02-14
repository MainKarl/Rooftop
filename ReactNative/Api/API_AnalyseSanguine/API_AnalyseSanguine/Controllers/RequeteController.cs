using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AnalyseSanguine.Dtos;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/requete")]
    [Produces("application/json")]
    public class RequeteController : ControllerBase
    {
        private readonly IRequeteService _service;

        public RequeteController(IRequeteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequete(int idDossier)
        {
            try
            {
                var result = _service.GetAllRequete(idDossier);
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
        public async Task<IActionResult> GetRequete(int id)
        {
            try
            {
                var result = _service.GetRequete(id);
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
        public async Task<IActionResult> CreateRequete(CreateRequeteDto createRequeteDto)
        {
            try
            {
                List<TypeAnalyse> typeAnalyses = _service.GetCorrespondantTypeAnalyses(createRequeteDto.lstAnalyses);

                RequeteAnalyse requete = new RequeteAnalyse()
                {
                    CodeAcces = Guid.NewGuid(),
                    DateEchantillon = DateTime.Now,
                    DossierIdDossier = createRequeteDto.DossierIdDossier,
                    LstTypeAnalyse = typeAnalyses,
                    MedecinIdMedecin = createRequeteDto.MedecinIdMedecin,
                    NomTechnicien = createRequeteDto.NomTechnicien,
                    AnalyseDemande = createRequeteDto.analyseDemande
                };
                var result = _service.CreateRequete(requete);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRequete(int id, RequeteAnalyse requeteAnalyse)
        {
            try
            {
                var result = _service.UpdateRequete(id, requeteAnalyse);
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
        public async Task<IActionResult> DeleteRequete(int id)
        {
            try
            {
                var result = _service.DeleteRequete(id);
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

        [HttpPost("addResults")]
        public IActionResult AddResultatsRequete(List<CreateResultDto> resultats)
        {
            try
            {
                var result = _service.AddResultatsRequete(resultats);
                if (result == null) 
                { 
                    return Problem(); 
                }
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
