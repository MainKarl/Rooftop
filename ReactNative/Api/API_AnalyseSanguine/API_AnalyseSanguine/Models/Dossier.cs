
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class Dossier
    {
        [Key]
        public int IdDossier { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        public byte Sexe { get; set; }
        public string? Note { get; set; }

        //lien
        public List<RequeteAnalyse>? LstRequetes { get; set; }

    }

    public class DossierValidator : AbstractValidator<Dossier>
    {
        public DossierValidator()
        {
            RuleFor(e => e.Prenom)
                .NotEmpty()
                .WithMessage("Veuillez spécifier un prénom");

            RuleFor(e => e.Nom)
                .NotEmpty()
                .WithMessage("Veuillez spécifier un nom");

            RuleFor(e => e.Sexe)
                .NotNull()
                .WithMessage("Veuillez spécifier un sexe");

            RuleFor(e => e.DateNaissance)
                .NotEmpty()
                .WithMessage("Veuillez spécifier une date de naissance");

            RuleFor(e => e.DateNaissance)
               .LessThan(DateTime.Now).WithMessage("Veuillez sélectionner une date valide");
        }

    }
}
