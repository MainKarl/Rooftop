using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_AnalyseSanguine.Models
{
    public class TypeValeur
    {
        [Key]
        [Required]
        public int IdTypeValeur { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public string Nom { get; set; }


        //Lien
        public int TypeAnalyseId { get; set; }
        public TypeAnalyse TypeAnalyse { get; set; }
    }
}
