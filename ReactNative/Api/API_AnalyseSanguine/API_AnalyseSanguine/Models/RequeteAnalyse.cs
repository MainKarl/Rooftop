using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class RequeteAnalyse
    {
        [Key]
        [Required]
        public int IdRequete { get; set; }
        [Required]
        public Guid CodeAcces { get; set; }
        [Required]
        public DateTime DateEchantillon { get; set; } = DateTime.Now;
        [Required]
        public string AnalyseDemande { get; set; }
        [Required]
        public string NomTechnicien { get; set; }


        //Lien
        [Required]
        public Dossier Dossier { get; set; }
        [Required]
        public Medecin Medecin { get; set; }
        public List<ResultatAnalyse> LstResultats { get; set; }
        public List<TypeAnalyse> LstTypeAnalyse { get; set; }

    }
}
