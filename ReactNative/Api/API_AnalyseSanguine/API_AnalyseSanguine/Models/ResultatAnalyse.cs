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
        public string Valeur { get; set; }


        //Lien
        [Required]
        public int IdRequete { get; set; }
        [Required]
        public TypeValeur TypeValeur { get; set; }
    }

    public class ResultatAnalyseValidator : AbstractValidator<ResultatAnalyse>
    {
        public ResultatAnalyseValidator()
        {
            RuleFor(e => e.Valeur)
                .NotEmpty()
                .WithMessage("Veuillez spécifier une valeur");
        }

    }
}
