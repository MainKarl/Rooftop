using API_AnalyseSanguine.Models;

namespace API_AnalyseSanguine.Services.Interfaces
{
    public interface ITypeValeurService
    {
        public IEnumerable<TypeValeur> GetAllTypeValeur();
        public TypeValeur GetTypeValeur(long id);
        public TypeValeur CreateTypeValeur(TypeValeur typeValeur);
    }
}
