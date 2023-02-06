using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/Requete")]
    [Produces("application/json")]
    public class RequeteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequeteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dossier>> GetAllRequete(int idDossier)
        {
            try
            {
                //Potentiellement ajouter les includes
                var list = _context.RequeteAnalyses.Where(c => c.Dossier.IdDossier == idDossier).ToList();
                return Ok(list);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Dossier>> GetRequete(int id)
        {
            try
            {
                var item = _context.RequeteAnalyses.Find(id);
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
        public ActionResult CreateRequete(RequeteAnalyse RequeteAnalyse)
        {
            try
            {
                _context.RequeteAnalyses.Add(RequeteAnalyse);
                _context.SaveChanges();

                return Ok(RequeteAnalyse);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("update")]
        public ActionResult UpdateRequete(int id, RequeteAnalyse RequeteAnalyse)
        {
            try
            {
                var item = _context.RequeteAnalyses.Find(id);

                if (item == null)
                    return NotFound();
                
                //Probablement qu'il y en a de trop
                item.AnalyseDemande = RequeteAnalyse.AnalyseDemande; //De trop?
                item.CodeAcces = RequeteAnalyse.CodeAcces;
                item.DateEchantillon = RequeteAnalyse.DateEchantillon;
                item.Dossier = RequeteAnalyse.Dossier; //De trop?
                item.LstResultats = RequeteAnalyse.LstResultats; //De trop?
                item.LstTypeAnalyse = RequeteAnalyse.LstTypeAnalyse; //De trop?
                item.Medecin = RequeteAnalyse.Medecin; //De trop?
                item.NomTechnicien = RequeteAnalyse.NomTechnicien;

                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRequete(int id)
        {
            try
            {
                var item = _context.RequeteAnalyses.Find(id);

                if (item == null)
                    return NotFound();

                _context.RequeteAnalyses.Remove(item);
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
                var RequeteAnalyses = _context.RequeteAnalyses.ToList();

                _context.RequeteAnalyses.RemoveRange(RequeteAnalyses);
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
