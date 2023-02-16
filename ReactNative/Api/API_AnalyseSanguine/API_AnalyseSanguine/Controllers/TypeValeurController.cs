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

        /// <summary>
        /// Retourne tout les type de valeur
        /// 
        /// Retourne une erreur si la liste est vide
        /// </summary>
        /// <returns>La liste des types de valeur</returns>
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

        /// <summary>
        /// Retourne un type de valeur en fonction de l'Id
        /// 
        /// Retourne une erreur si aucun Type de valeur n'a été trouvé
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crée un type de valeur
        /// 
        /// Retourne une erreur si une valeur n'est pas valide
        /// </summary>
        /// <param name="typeValeur">Informations du type de valeur a créer</param>
        /// <returns>Type de valeur créé</returns>
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
