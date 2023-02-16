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

        /// <summary>
        /// Récupère la liste de toutes les requêtes liées à un dossier.
        /// 
        /// Retourne une erreur si la liste est vide
        /// </summary>
        /// <param name="idDossier">Id du dossier lier aux requêtes</param>
        /// <returns>la liste des requêtes</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRequete(int idDossier)
        {
            try
            {
                var result = _service.GetAllRequete(idDossier).OrderByDescending(x => x.DateEchantillon);
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

        /// <summary>
        /// Récupère une requête en fonction de l'Id fourni.
        /// 
        /// Retourne une erreur si aucune requête n'a été trouvée
        /// </summary>
        /// <param name="id">Id de la requête a trouver</param>
        /// <returns>La requête trouvée</returns>
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

        /// <summary>
        /// Crée une requête
        /// 
        /// Retourne une erreur si une valeur n'est pas valide
        /// </summary>
        /// <param name="createRequeteDto">Les informations de la requête a créer</param>
        /// <returns>le code de réussite</returns>
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

        /// <summary>
        /// Modifie une requête en fonction de l'Id fourni
        /// 
        /// Retourne une erreur si aucune requête n'a été trouvée
        /// </summary>
        /// <param name="id">Id de la requête a modifer</param>
        /// <param name="requeteAnalyse">Information a appliquer sur la requête</param>
        /// <returns>La requête et ses nouvelles informations</returns>
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

        /// <summary>
        /// Supprime une requête en fonction de l'Id fourni
        /// 
        /// Retourne une erreur si aucune requête n'a été trouvé
        /// </summary>
        /// <param name="id">Id de la requête a supprimer</param>
        /// <returns>Vrai si la requête à été supprimée</returns>
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

        /// <summary>
        /// Ajoute une liste de résultats a la requête appropriée
        /// 
        /// Retourne une erreur si aucune requête n'a été trouvé ou si les valeurs d'un résultat ne sont pas valides
        /// </summary>
        /// <param name="resultats">Liste des résultats a lier a la requête</param>
        /// <returns>Retourne la requête</returns>
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
