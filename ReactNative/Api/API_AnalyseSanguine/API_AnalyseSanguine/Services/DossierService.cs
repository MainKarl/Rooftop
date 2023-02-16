using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
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
            try
            {
                _context.Dossiers.Add(dossier);
                _context.SaveChanges();

                return dossier;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteDossier(long id)
        {
            try
            {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                if (item == null)
                    return false;

                _context.Dossiers.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DossierDetailleDto GetDossierDetaille(int id)
        {
            try
            {

                Dossier item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                if (item == null)
                    return null;

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

                lstRequetesDto = lstRequetesDto.OrderByDescending(c=>c.DateEchantillon).ToList();

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
            catch (Exception e)
            {
                return null;
            }
        }

        public List<DossierSimpleDto> GetDossierSimple()
        {
            try
            {
                List<Dossier> item = _context.Dossiers.ToList();
                return item.Select(item => new DossierSimpleDto(
                    item.IdDossier,
                    item.Prenom,
                    item.Nom
                    )).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Dossier UpdateDossier(int id, Dossier dossier)
        {
            try
            {
                var item = _context.Dossiers.Where(a => a.IdDossier == id).FirstOrDefault();

                if (item == null)
                    return null;
                
                item.Prenom = dossier.Prenom;
                item.Nom = dossier.Nom;
                item.DateNaissance = dossier.DateNaissance;
                item.Sexe = dossier.Sexe;
                item.Note = dossier.Note;
                _context.SaveChanges();

                return item;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
