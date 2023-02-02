
using FluentValidation;
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

    public class DossierValidator : AbstractValidator<Dossier>
    {
        public DossierValidator()
        {
            RuleFor(e => e.Prenom)
                .NotEmpty()
                .WithMessage("Le prénom ne peut pas être vide!");

            RuleFor(e => e.Nom)
                .NotEmpty()
                .WithMessage("Le nom ne peut pas être vide!");

            RuleFor(e => e.Sexe)
                .NotEmpty()
                .WithMessage("Le sexe ne peut pas être vide!");

            RuleFor(e => e.DateNaissance)
                .NotEmpty()
                .WithMessage("La date de naissance ne peut pas être vide!");

            RuleFor(e => e.DateNaissance)
               .LessThan(DateTime.Now).WithMessage("La date de naissance ne peut pas être après aujour'hui!");
        }

    }
}
