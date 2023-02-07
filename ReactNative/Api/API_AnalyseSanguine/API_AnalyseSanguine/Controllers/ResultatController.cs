using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/resultat")]
    [Produces("application/json")]
    public class ResultatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResultatController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dossier>> GetAllResultat()
        {
            try
            {
                var list = _context.ResultatAnalyses.ToList();
                return Ok(list);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Dossier>> GetResultat(int id)
        {
            try
            {
                var item = _context.ResultatAnalyses.Find(id);
                if (item == null)
                    return NotFound();

                return Ok(item); ;
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public ActionResult CreateResultat(ResultatAnalyse resultat)
        {
            try
            {
                _context.ResultatAnalyses.Add(resultat);
                _context.SaveChanges();

                return Ok(resultat);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("update")]
        public ActionResult UpdateResultat(int id, ResultatAnalyse resultat)
        {
            try
            {
                var item = _context.ResultatAnalyses.Find(id);

                if (item == null)
                    return NotFound();

                item.Valeur = resultat.Valeur;
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDossier(int id)
        {
            try
            {
                var item = _context.ResultatAnalyses.Find(id);

                if (item == null)
                    return NotFound();

                _context.ResultatAnalyses.Remove(item);
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
