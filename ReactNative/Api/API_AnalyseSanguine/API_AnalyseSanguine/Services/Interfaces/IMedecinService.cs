using API_AnalyseSanguine.Context.Data;
using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Services.Interfaces
{
    public interface IMedecinService
    {
        public List<Medecin> GetAllMedecin();
        public Medecin GetMedecin(int id);
        public Medecin CreateMedecin(Medecin medecin);
        public Medecin UpdateMedecin(int id, Medecin medecin);
        public bool DeleteMedecin(int id);
    }
}
