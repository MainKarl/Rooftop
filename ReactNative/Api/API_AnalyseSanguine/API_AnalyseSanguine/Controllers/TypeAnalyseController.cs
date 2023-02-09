using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
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
        private readonly ApplicationDbContext _context;

        public TypeAnalyseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<Category>> GetAllCategoriesAndTypeAnalyse()
        {
            try
            {
                var item = _context.Categories.Include(x => x.TypeAnalyseList).ToList();
                return Ok(item);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<TypeAnalyse>> GetAllTypeAnalyse()
        {
            try
            {
                var item = _context.TypeAnalyses.ToList();
                return Ok(item);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TypeAnalyse> GetTypeAnalyse(long id)
        {
            try
            {
                var item = _context.TypeAnalyses.Where(a => a.IdTypeAnalyse == id).FirstOrDefault();

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public ActionResult CreateTypeAnalyse(TypeAnalyse typeAnalyse)
        {
            try
            {
                _context.TypeAnalyses.Add(typeAnalyse);
                _context.SaveChanges();

                return Ok(typeAnalyse);
            }
            catch
            {
                return Problem();
            }
        }
    }
}
