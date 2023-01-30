# Modèle de conception

```plantuml
@startuml
hide circle
package ElectronAnalyseSanguine {
    package UI {
        class MedecinFormPage {
            AjouterMedecin()
        }

        class RequetePage {
            AvoirRequeteAnalyse()
            AjouterAnalyse()
            ImprimerRequete()
        }

        class RequeteFormPage {
            AjouterRequete()
        }

        class DossierPage {
            AvoirDossierPatient()
        }

        class DossierFormPage {
            AjouterDossier()
        }


    }

    package Controller {
        class MedecinMgmt {
            AjouterMedecin()
        }

        class RequeteAnalyseMgmt {
            AjouterRequete()
        }

        class ResultatMgmt {
            AjouterAnalyse()
        }

        class DossierMgmt {
            AjouterDossier()
        }
    }

    package Models {
        class Medecin {
            Id : uint
            FirstName : string
            LastName : string
        }

        class ResultatAnalyze {
            Id : uint
            RequestId : uint
            Results : string
        }

        class RequeteAnalyze {
            Id : uint
            FileId : uint
            DoctorId : uint
            SamplingDate : DateTime
            RequestedAnalysis : json
            TechName : string
            AccessCode : guid
        }

        class Dossier {
            Id : uint
            Sexe : byte
            FirstName : string
            LastName : string
            BirthDate : Date
            Note : Note
        }
    }
}

Medecin <-- MedecinMgmt
ResultatAnalyze <-- ResultatMgmt
RequeteAnalyze <-- RequeteAnalyseMgmt
Dossier <-- DossierMgmt

MedecinMgmt <-- MedecinFormPage
DossierMgmt <-- DossierPage
DossierMgmt <-- DossierFormPage
RequeteAnalyseMgmt <-- RequeteFormPage
RequeteAnalyseMgmt <-- RequetePage

DossierFormPage <-- DossierPage
RequeteFormPage <-- RequetePage
@enduml
```
