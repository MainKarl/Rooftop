using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Services
{
    public class TypeAnalyseService : ITypeAnalyseService
    {
        private readonly ApplicationDbContext _context;

        public TypeAnalyseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TypeAnalyse CreateTypeAnalyse(TypeAnalyse typeAnalyse)
        {
            try
            {
                _context.TypeAnalyses.Add(typeAnalyse);
                _context.SaveChanges();

                return typeAnalyse;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Category> GetAllCategoriesAndTypeAnalyse()
        {
            try
            {
                return _context.Categories.Include(x => x.TypeAnalyseList).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<TypeAnalyse> GetAllTypeAnalyse()
        {
            try
            {
                return _context.TypeAnalyses.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TypeAnalyse GetTypeAnalyse(long id)
        {
            try
            {
                return _context.TypeAnalyses.Where(a => a.IdTypeAnalyse == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
