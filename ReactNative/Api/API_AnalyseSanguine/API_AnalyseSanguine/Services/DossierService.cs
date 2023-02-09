using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Services
{
    public class DossierService : IDossierService
    {
        private readonly ApplicationDbContext _context;

        public DossierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dossier CreateDossier(Dossier dossier)
        {
                _context.Dossiers.Add(dossier);
                _context.SaveChanges();

                return dossier;
        }

        public bool DeleteDossier(long id)
        {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                _context.Dossiers.Remove(item);
                _context.SaveChanges();

                return true;
        }

        public DossierDetailleDto GetDossierDetaille(int id)
        {
                Dossier item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();
                List<RequeteAnalyse> lstRequetes = _context.RequeteAnalyses.Where(c => c.DossierIdDossier == id).ToList();

                List<RequeteAnalyseDto> lstRequetesDto = new List<RequeteAnalyseDto>();
                if (item.LstRequetes != null)
                {
                    foreach (var requete in lstRequetes)
                    {
                        Medecin medecin = _context.Medecins.Where(a => a.IdMedecin == requete.MedecinIdMedecin).FirstOrDefault();
                        lstRequetesDto.Add(new RequeteAnalyseDto(requete.IdRequete, requete.CodeAcces, requete.DateEchantillon, medecin.Nom + ", " + medecin.Prenom));
                    }
                }

                return new DossierDetailleDto(
                    item.IdDossier,
                    item.Prenom,
                    item.Nom,
                    item.DateNaissance,
                    item.Sexe,
                    item.Note,
                    lstRequetesDto
                );
        }

        public List<DossierSimpleDto> GetDossierSimple()
        {
                List<Dossier> item = _context.Dossiers.ToList();
                return item.Select(item => new DossierSimpleDto(
                    item.IdDossier,
                    item.Prenom,
                    item.Nom
                    )).ToList();
        }

        public Dossier UpdateDossier(int id, Dossier dossier)
        {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                item.Prenom = dossier.Prenom;
                item.Nom = dossier.Nom;
                item.DateNaissance = dossier.DateNaissance;
                item.Sexe = dossier.Sexe;
                item.Note = dossier.Note;
                _context.SaveChanges();

            return item;
        }
    }
}
