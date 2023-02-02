using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/typevaleur")]
    [Produces("application/json")]
    public class TypeValeurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TypeValeurController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TypeValeur>> GetAllTypeValeur()
        {
            try
            {
                var item = _context.TypeValeurs.ToList();
                return Ok(item);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TypeValeur> GetTypeValeur(long id)
        {
            try
            {
                var item = _context.TypeValeurs.Where(a => a.IdTypeValeur == id).FirstOrDefault();

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
        public ActionResult CreateTypeValeur(TypeValeur typeValeur)
        {
            try
            {
                _context.TypeValeurs.Add(typeValeur);
                _context.SaveChanges();

                return Ok(typeValeur);
            }
            catch
            {
                return Problem();
            }
        }
    }
}
