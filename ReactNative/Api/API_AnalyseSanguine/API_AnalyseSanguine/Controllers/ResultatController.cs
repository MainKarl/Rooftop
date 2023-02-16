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

        /// <summary>
        /// Retourne tout les résultats
        /// 
        /// Retourne une erreur si la liste est vide
        /// </summary>
        /// <returns>la liste des résultats</returns>
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

        /// <summary>
        /// Retourne un résultat en fonction de l'Id
        /// 
        /// Retourne une erreur si aucun résultat n'a été trouvé
        /// </summary>
        /// <param name="id">Id du résultat</param>
        /// <returns>Le résultat trouvé</returns>
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

        /// <summary>
        /// Crée un résultat
        /// 
        /// Retourne une erreur si les valeurs ne sont pas valides
        /// </summary>
        /// <param name="resultat">Valeur du résultat a créer</param>
        /// <returns>Le résultat créé</returns>
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

        /// <summary>
        /// Modifier les valeurs d'un résultat en fonction de l'Id
        /// 
        /// Retourne une erreur si aucun résultat n'a été trouvé
        /// </summary>
        /// <param name="id">Id du résultat a modifier</param>
        /// <param name="resultat">Nouvelles valeur du résultat</param>
        /// <returns>Le résultat avec ses nouvelles valeurs</returns>
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

        /// <summary>
        /// Supprime un résultat en fonction de l'Id
        /// 
        /// Retourne une erreur si aucun résultat n'est trouvé
        /// </summary>
        /// <param name="id">Id du résultat a supprimer</param>
        /// <returns>Vrai si le résultat a été supprimé</returns>
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
