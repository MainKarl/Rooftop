using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/typeanalyse")]
    [Produces("application/json")]
    public class TypeAnalyseController : ControllerBase
    {
        private readonly ITypeAnalyseService _service;

        public TypeAnalyseController(ITypeAnalyseService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retourne une liste de toutes les catégories ainsi que les types d'analyse qui leur sont assignés
        /// 
        /// Retourne une erreur si la liste est vide
        /// </summary>
        /// <returns>La liste des toutes les catégorie et les types d'analyse</returns>
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategoriesAndTypeAnalyse()
        {
            try
            {
                var result = _service.GetAllCategoriesAndTypeAnalyse();
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
        /// Retourne tout les types d'analyse
        /// 
        /// Retourne une erreur si la liste est vide
        /// </summary>
        /// <returns>La liste des types d'analyse</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTypeAnalyse()
        {
            try
            {
                var result = _service.GetAllTypeAnalyse();
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
        /// Retourne un type d'analyse en fonction de l'Id
        /// 
        /// Retourne une erreur si aucun type d'analyse n'est trouvé
        /// </summary>
        /// <param name="id">l'Id du type d'analyse</param>
        /// <returns>Le type d'analyse trouvé</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeAnalyse(long id)
        {
            try
            {
                var result = _service.GetTypeAnalyse(id);
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
        /// Crée un type d'analyse
        /// 
        /// Retourne une erreur si une valeur n'est pas valide
        /// </summary>
        /// <param name="typeAnalyse">Les informations pour le type d'analyse a créer</param>
        /// <returns>Le type d'analyse créé</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateTypeAnalyse(TypeAnalyse typeAnalyse)
        {
            try
            {
                var result = _service.CreateTypeAnalyse(typeAnalyse);
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
