using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class TypeAnalyse
    {
        [Key]
        [Required]
        public int IdTypeAnalyse { get; set; }
        [Required]
        public string Nom { get; set; }


        //Lien
        public List<TypeValeur> LstValeurs { get; set; }
    }
}
