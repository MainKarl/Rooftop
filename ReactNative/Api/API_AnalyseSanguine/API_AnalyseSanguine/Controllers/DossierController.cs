using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/dossier")]
    [Produces("application/json")]
    public class ToDoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dossier>> GetAllDossier()
        {
            try
            {
                var item = _context.Dossiers.ToList();
                return Ok(item);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public ActionResult CreateDossier(Dossier dossier)
        {
            try
            {
                _context.Dossiers.Add(dossier);
                _context.SaveChanges();

                return Ok(dossier);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Dossier> GetDossier(long id)
        {
            try
            {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("update")]
        public ActionResult UpdateDossier(long id, Dossier dossier)
        {
            try
            {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                if (item == null)
                    return NotFound();

                item.Prenom = dossier.Prenom;
                item.Nom = dossier.Nom;
                item.DateNaissance = dossier.DateNaissance;
                item.Sexe = dossier.Sexe;
                item.Note = dossier.Note;
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDossier(long id)
        {
            try
            {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();
                if (item is null)
                    return NotFound();

                _context.Dossiers.Remove(item);
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("clear")]
        public ActionResult DeleteAll()
        {
            try
            {
                var dossiers = _context.Dossiers.ToList();

                _context.Dossiers.RemoveRange(dossiers);
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
