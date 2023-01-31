using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class TypeValeur
    {
        [Key]
        [Required]
        public int IdTypeValeur { get; set; }
        [Required]
        public string Unite { get; set; }
        [Required]
        public string Nom { get; set; }

        //Lien
        public TypeAnalyse TypeAnalyse { get; set; }
    }
}
