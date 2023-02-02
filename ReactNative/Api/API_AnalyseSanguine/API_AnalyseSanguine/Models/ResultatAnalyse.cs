using FluentValidation;
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

    public class ResultatAnalyseValidator : AbstractValidator<ResultatAnalyse>
    {
        public ResultatAnalyseValidator()
        {
            RuleFor(e => e.Valeur)
                .NotEmpty()
                .WithMessage("La valeur ne peut pas être vide!");
        }

    }
}
