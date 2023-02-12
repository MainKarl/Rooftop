using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Services
{
    public class TypeValeurService : ITypeValeurService
    {
        private readonly ApplicationDbContext _context;

        public TypeValeurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TypeValeur CreateTypeValeur(TypeValeur typeValeur)
        {
            try
            {
                _context.TypeValeurs.Add(typeValeur);
                _context.SaveChanges();

                return typeValeur;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<TypeValeur> GetAllTypeValeur()
        {
            try
            {
                return _context.TypeValeurs.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TypeValeur GetTypeValeur(long id)
        {
            try
            {
                return _context.TypeValeurs.Where(a => a.IdTypeValeur == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
