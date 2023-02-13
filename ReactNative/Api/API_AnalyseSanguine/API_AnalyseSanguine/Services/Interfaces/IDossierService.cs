using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AnalyseSanguine.Services.Interfaces
{
    public interface IDossierService
    {
        public List<DossierSimpleDto> GetDossierSimple();
        public DossierDetailleDto GetDossierDetaille(int id);
        public Dossier CreateDossier(Dossier dossier);
        public Dossier UpdateDossier(int id, Dossier dossier);
        public bool DeleteDossier(long id);
    }
}
