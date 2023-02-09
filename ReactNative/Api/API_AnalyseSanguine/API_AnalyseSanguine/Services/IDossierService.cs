using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Services
{
    public interface IDossierService
    {
        public List<Dossier> Get();
        public List<DossierSimpleDto> GetDossierSimple();
        public DossierDetailleDto GetDossierDetaille(int id);
        public Dossier CreateDossier(Dossier dossier);
        public void UpdateDossier(long id, Dossier dossier);
        public void DeleteDossier(long id);
    }
}
