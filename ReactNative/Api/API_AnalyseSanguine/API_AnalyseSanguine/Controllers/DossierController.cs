using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Controllers
{
    [ApiController]
    [Route("api/dossier")]
    [Produces("application/json")]
    public class DossierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DossierController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getsimple")]
        public ActionResult<IEnumerable<DossierSimpleDto>> GetDossierSimple()
        {
            try
            {
                List<Dossier> item = _context.Dossiers.ToList();
                return Ok(item.Select(item => new DossierSimpleDto(
                    item.IdDossier,
                    item.Prenom,
                    item.Nom
                    )));
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("getdetaille")]
        public ActionResult<IEnumerable<DossierDetailleDto>> GetDossierDetaille(int id)
        {
            try
            {
                Dossier item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();
                List<RequeteAnalyse> lstRequetes = _context.RequeteAnalyses.Where(c => c.DossierIdDossier == id).ToList();

                if (item == null)
                    return NotFound();

                List<RequeteAnalyseDto> lstRequetesDto = new List<RequeteAnalyseDto>();
                if (item.LstRequetes != null)
                {
                    foreach (var requete in lstRequetes)
                    {
                        Medecin medecin = _context.Medecins.Where(a => a.IdMedecin == requete.MedecinIdMedecin).FirstOrDefault();
                        lstRequetesDto.Add(new RequeteAnalyseDto(requete.IdRequete, requete.CodeAcces, requete.DateEchantillon, medecin.Nom + ", " + medecin.Prenom));
                    }
                }

                return Ok(new DossierDetailleDto(
                    item.IdDossier,
                    item.Prenom,
                    item.Nom,
                    item.DateNaissance,
                    item.Sexe,
                    item.Note,
                    lstRequetesDto
                ));
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
    }
}
