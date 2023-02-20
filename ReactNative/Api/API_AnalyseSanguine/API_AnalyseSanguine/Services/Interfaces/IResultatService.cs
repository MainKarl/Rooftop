using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Services.Interfaces
{
    public interface IResultatService
    {
        public IEnumerable<ResultatAnalyse> GetAllResultat();
        public ResultatAnalyse GetResultat(int id);
        public ResultatAnalyse CreateResultat(ResultatAnalyse resultat);
        public ResultatAnalyse UpdateResultat(int id, ResultatAnalyse resultat);

        public bool UpdateCouleurResultatBulk(List<ResultatColor> resultat);
        public bool DeleteResultat(int id);
    }
}
