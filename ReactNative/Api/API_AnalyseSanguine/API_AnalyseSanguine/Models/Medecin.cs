using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class Medecin
    {
        [Key]
        [Required]
        public int IdMedecin { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }

        //Lien
        public List<RequeteAnalyse> LstRequetes { get; set; }
    }
}
