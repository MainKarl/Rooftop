using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Services
{
    public interface ITypeAnalyseService
    {
        public IEnumerable<Category> GetAllCategoriesAndTypeAnalyse();
        public IEnumerable<TypeAnalyse> GetAllTypeAnalyse();
        public TypeAnalyse GetTypeAnalyse(long id);
        public TypeAnalyse CreateTypeAnalyse(TypeAnalyse typeAnalyse);

    }
}
