using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using API_AnalyseSanguine.Services.Interfaces;

namespace API_AnalyseSanguine.Services
{
    public class MedecinService : IMedecinService
    {
        private readonly ApplicationDbContext _context;

        public MedecinService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Medecin CreateMedecin(Medecin medecin)
        {
            try
            {
                _context.Medecins.Add(medecin);
                _context.SaveChanges();

                return medecin;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteMedecin(int id)
        {
            try
            {
                var item = _context.Medecins.Where(a => a.IdMedecin == id).FirstOrDefault();

                if (item == null)
                    return false;

                _context.Medecins.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Medecin> GetAllMedecin()
        {
            try
            {
                return _context.Medecins.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Medecin GetMedecin(int id)
        {
            try
            {
                return _context.Medecins.Where(c => c.IdMedecin == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Medecin UpdateMedecin(int id, Medecin medecin)
        {
            try
            {
                var item = _context.Medecins.Where(a => a.IdMedecin == id).FirstOrDefault();

                if (item == null)
                    return null;

                item.Prenom = medecin.Prenom;
                item.Nom = medecin.Nom;
                _context.SaveChanges();

                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
