﻿using API_AnalyseSanguine.Models;

namespace API_AnalyseSanguine.Services
{
    public interface IRequeteService
    {
        public IEnumerable<RequeteAnalyse> GetAllRequete(int id);
        public RequeteAnalyse GetRequete(int id);
        public RequeteAnalyse CreateRequete(RequeteAnalyse RequeteAnalyse);
        public RequeteAnalyse UpdateRequete(int id, RequeteAnalyse RequeteAnalyse);
        public bool DeleteRequete(int id);
    }
}
