using API_AnalyseSanguine.Dtos;
using API_AnalyseSanguine.Models;

namespace API_AnalyseSanguine.Services.Interfaces
{
    public interface IRequeteService
    {
        public IEnumerable<RequeteAnalyse> GetAllRequete(int id);
        public RequeteAnalyse GetRequete(int id);
        public RequeteAnalyse CreateRequete(RequeteAnalyse RequeteAnalyse);
        public RequeteAnalyse UpdateRequete(int id, RequeteAnalyse RequeteAnalyse);
        public bool DeleteRequete(int id);

        public List<TypeAnalyse> GetCorrespondantTypeAnalyses(List<int> analyseIds);
        public RequeteAnalyse AddResultatsRequete(List<CreateResultDto> resultats);
    }
}
