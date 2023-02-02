using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace API_AnalyseSanguine.Models
{
    public class RequeteAnalyse
    {
        [Key]
        public int IdRequete { get; set; }
        public Guid CodeAcces { get; set; }
        public DateTime DateEchantillon { get; set; } = DateTime.Now;
        public string AnalyseDemande { get; set; }
        public string NomTechnicien { get; set; }


        //Lien
        public Dossier Dossier { get; set; }
        public Medecin Medecin { get; set; }
        public List<ResultatAnalyse> LstResultats { get; set; }
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
