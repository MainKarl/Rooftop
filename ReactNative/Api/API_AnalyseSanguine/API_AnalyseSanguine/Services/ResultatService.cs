using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;

namespace API_AnalyseSanguine.Services
{
    public class ResultatService : IResultatService
    {
        private readonly ApplicationDbContext _context;

        public ResultatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResultatAnalyse CreateResultat(ResultatAnalyse resultat)
        {
            try
            {
                _context.ResultatAnalyses.Add(resultat);
                _context.SaveChanges();

                return resultat;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool DeleteResultat(int id)
        {
            try
            {
                var item = _context.ResultatAnalyses.Find(id);

                if (item == null)
                    return false;

                _context.ResultatAnalyses.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<ResultatAnalyse> GetAllResultat()
        {
            try
            {
                return _context.ResultatAnalyses.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ResultatAnalyse GetResultat(int id)
        {
            try
            {
                var item = _context.ResultatAnalyses.Find(id);
                if (item == null)
                    return null;

                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ResultatAnalyse UpdateResultat(int id, ResultatAnalyse resultat)
        {
            try
            {
                var item = _context.ResultatAnalyses.Find(id);

                if (item == null)
                    return null;

                item.Valeur = resultat.Valeur;
                _context.SaveChanges();

                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
