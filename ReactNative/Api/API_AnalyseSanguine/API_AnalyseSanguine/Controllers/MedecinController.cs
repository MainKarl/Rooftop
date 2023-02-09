using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Context.Data;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/medecin")]
    [Produces("application/json")]
    public class MedecinController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedecinController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dossier>> GetAllMedecin()
        {
            try
            {
                var list = _context.Medecins.ToList();
                return Ok(list);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Dossier>> GetMedecin(int id)
        {
            try
            {
                var item = _context.Medecins.Find(id);
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
        public ActionResult CreateMedecin(Medecin medecin)
        {
            try
            {
                _context.Medecins.Add(medecin);
                _context.SaveChanges();

                return Ok(medecin);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("update")]
        public ActionResult UpdateMedecin(int id, Medecin medecin)
        {
            try
            {
                var item = _context.Medecins.Find(id);

                if (item == null)
                    return NotFound();

                item.Prenom = medecin.Prenom;
                item.Nom = medecin.Nom;
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
                var item = _context.Medecins.Find(id);

                if (item == null)
                    return NotFound();

                _context.Medecins.Remove(item);
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
