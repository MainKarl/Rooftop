
using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class Dossier
    {
        [Key]
        [Required]
        public int IdDossier { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        public byte Sexe { get; set; }
        public string Note { get; set; }

        //lien
        public List<RequeteAnalyse> LstRequetes { get; set; }

    }
}
