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

        /// <summary>
        /// Récupère l’Id, le prénom et le nom de chaque dossier.
        /// 
        /// Retourne une erreur si la liste est null
        /// </summary>
        /// <returns>Liste JSON des résultats obtenus</returns>
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

        /// <summary>
        /// Récupère l'Id, le prénom, le nom, la date de naissance, le sexe, la note associée et la liste de requêtes du dossier ayant l'Id passé en paramètre.
        /// 
        /// Retourne une erreur si aucun dossier n'a été trouvé avec l'Id fourni
        /// </summary>
        /// <param name="id">Id du dossier voulu</param>
        /// <returns>JSON contenant les informations trouvées</returns>
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

        /// <summary>
        /// Crée un dossier avec les informations fournies dans le formulaire de création de dossiers.
        /// 
        /// Retourne un message d'erreur en fonction de la valeur invalide
        /// </summary>
        /// <param name="dossier">Modèle contenant les informations du formulaire</param>
        /// <returns>Le dossier créé</returns>
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

        /// <summary>
        /// Récupère un dossier avec l'Id fourni et change ses valeurs en fonction des valeurs obtenues du formulaire de modification de dossier.
        /// 
        /// Retourne une erreur si aucun dossier n'a été trouvé avec l'Id fourni
        /// </summary>
        /// <param name="id">Id du dossier à modifier</param>
        /// <param name="dossier">Valeur à appliquer au dossier</param>
        /// <returns>Le dossier avec les nouvelles valeurs</returns>
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

        /// <summary>
        /// Supprime un dossier en fonction de l'Id fourni.
        /// 
        /// Retourne une erreur si aucun dossier n'a été trouvé avec l'Id fourni
        /// </summary>
        /// <param name="id">Id du dossier à supprimer</param>
        /// <returns>True si la suppression a été complétée</returns>
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
