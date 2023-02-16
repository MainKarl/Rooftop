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

        /// <summary>
        /// Récupère tous les médecins.
        /// 
        /// Retourne une erreur si la liste est vide
        /// </summary>
        /// <returns>Liste de tous les médecins</returns>
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

        /// <summary>
        /// Récupère les informations du médecin ayant l'Id fourni.
        /// 
        /// Retourne une erreur si aucun médecin n'a été trouvé avec l'Id fourni
        /// </summary>
        /// <param name="id">Id du médecin a trouver</param>
        /// <returns>Les informations du médecin</returns>
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

        /// <summary>
        /// Crée un médecin avec les informations fournis.
        /// 
        /// Retourne une erreur si le médecin n'a pas été créé
        /// </summary>
        /// <param name="medecin">Information du médecin a être créé</param>
        /// <returns>le médecin créé</returns>
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

        /// <summary>
        /// Modifie les informations du médecin lié a l'Id fourni avec les informations fourni.
        /// 
        /// Retourne une erreur si aucun médecin n'a été trouvé
        /// </summary>
        /// <param name="id">Id du médecin a modifier</param>
        /// <param name="medecin">Nouvelles informations du médecin</param>
        /// <returns>Le médecin et ses nouvelles informations</returns>
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

        /// <summary>
        /// Supprime le médecin lié a l'Id fourni
        /// 
        /// Retourne une erreur si aucun médecin n'a été trouvé
        /// </summary>
        /// <param name="id">Id du médecin a supprimer</param>
        /// <returns>Vrai si le médecin a été supprimé</returns>
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
