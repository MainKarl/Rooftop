using FluentValidation;
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

    public class MedecinValidator : AbstractValidator<Medecin>
    {
        public MedecinValidator()
        {
            RuleFor(e => e.Prenom)
                .NotEmpty()
                .WithMessage("Le prénom ne peut pas être vide!");

            RuleFor(e => e.Nom)
                .NotEmpty()
                .WithMessage("Le nom ne peut pas être vide!");
        }

    }
}
