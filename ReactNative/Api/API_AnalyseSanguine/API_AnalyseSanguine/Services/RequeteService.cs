using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Services
{
    public class RequeteService : IRequeteService
    {
        private readonly ApplicationDbContext _context;

        public RequeteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public RequeteAnalyse CreateRequete(RequeteAnalyse requeteAnalyse)
        {
            try
            {
                _context.RequeteAnalyses.Add(requeteAnalyse);
                _context.SaveChanges();

                return requeteAnalyse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteRequete(int id)
        {
            try
            {
                var item = _context.RequeteAnalyses.Where(a => a.IdRequete == id).FirstOrDefault();

                if (item == null)
                    return false;

                _context.RequeteAnalyses.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<RequeteAnalyse> GetAllRequete(int id)
        {
            try
            {
                return _context.RequeteAnalyses.Where(c => c.DossierIdDossier == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RequeteAnalyse GetRequete(int id)
        {
            try
            {
                return _context.RequeteAnalyses.Include(c => c.Medecin).Where(c => c.IdRequete == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RequeteAnalyse UpdateRequete(int id, RequeteAnalyse RequeteAnalyse)
        {
            try
            {
                var item = _context.RequeteAnalyses.Find(id);

                if (item == null)
                    return null;

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

                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TypeAnalyse> GetCorrespondantTypeAnalyses(List<int> analyseIds)
        {
            try
            {
                return _context.TypeAnalyses.Where(y => analyseIds.Contains(y.IdTypeAnalyse)).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
