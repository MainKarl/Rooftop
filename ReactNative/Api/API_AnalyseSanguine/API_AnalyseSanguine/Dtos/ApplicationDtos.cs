using API_AnalyseSanguine.Models;
using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Dtos
{
    public record DossierSimpleDto(int IdDossier, string Prenom, string Nom);
    public record DossierDetailleDto(int IdDossier, string Prenom, string Nom, DateTime DateNaissance, byte Sexe, string Note, List<RequeteAnalyseDto> LstRequetes);
    public record RequeteAnalyseDto(int IdRequete, Guid CodeAcces, DateTime DateEchantillon, string NomMedecin);
    public record CreateRequeteDto(int IdRequete, string NomTechnicien, int DossierIdDossier, int MedecinIdMedecin, List<int> lstAnalyses, string analyseDemande);
    public record CreateResultDto(int IdRequete, TypeValeur TypeValeur, string Valeur);
}
