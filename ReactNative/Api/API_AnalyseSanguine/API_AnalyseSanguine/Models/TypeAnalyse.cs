using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_AnalyseSanguine.Models
{
    public class TypeAnalyse
    {
        [Key]
        [Required]
        public int IdTypeAnalyse { get; set; }
        [Required]
        public string Nom { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }



        //Lien
        [Required]
        public List<TypeValeur> LstValeurs { get; set; }

        public List<RequeteAnalyse> RequeteAnalyses { get; set; }
    }
}
