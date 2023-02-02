using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class RequeteAnalyse
    {
        [Key]
        [Required]
        public int IdRequete { get; set; }
        [Required]
        public Guid CodeAcces { get; set; }
        [Required]
        public DateTime DateEchantillon { get; set; } = DateTime.Now;
        [Required]
        public string AnalyseDemande { get; set; }
        [Required]
        public string NomTechnicien { get; set; }


        //Lien
        [Required]
        public Dossier Dossier { get; set; }
        [Required]
        public Medecin Medecin { get; set; }
        [Required]
        public List<ResultatAnalyse> LstResultats { get; set; }
        [Required]
        public List<TypeAnalyse> LstTypeAnalyse { get; set; }

    }

    public class RequeteValidator : AbstractValidator<RequeteAnalyse>
    {
        public RequeteValidator()
        {
            RuleFor(x => x.IdRequete).NotEmpty();
            RuleFor(x => x.CodeAcces).NotEmpty().WithMessage("Veuillez spécifier un code");
            RuleFor(x => x.DateEchantillon).LessThan(DateTime.Now).WithMessage("Veuillez sélectionner une date valide");
            RuleFor(x => x.NomTechnicien).NotEmpty().WithMessage("Veuillez spécifier un technicien");
        }
    }
}
