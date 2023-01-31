using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class ResultatAnalyse
    {
        [Key]
        [Required]
        public int IdResultatAnalyse { get; set; }
        [Required]
        public float Valeur { get; set; }


        //Lien
        [Required]
        public RequeteAnalyse RequeteAnalyse { get; set; }
        [Required]
        public TypeValeur TypeValeur { get; set; }
    }
}
