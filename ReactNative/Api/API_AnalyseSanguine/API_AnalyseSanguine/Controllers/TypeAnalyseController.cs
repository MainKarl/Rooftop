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
