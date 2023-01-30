# Diagramme de détails

```plantuml

hide circle
left to right direction
package Entité{
    class "Dossier" as file{
        uint Id
        byte Sexe
        string FirstName
        string LastName
        Date BirthDate
        string Note

        Afficher()        
    }

    class "RequeteAnalyze" as analysisRequest{
        uint Id
        uint FileId
        uint DoctorId
        DateTime SamplingDate
        json RequestedAnalysis
        string TechName
        guid AccessCode

        Afficher()
        Ajouter()
    }
    
    class "ResultatAnalyze" as analysisResult{
        uint Id
        uint RequestId
        string Results

        Ajouter()
        Ajouter()
        Imprimer()
    }

    class "Medecin" as doctor{
        uint Id
        string FirstName
        string LastName

        Ajouter()
    }

    file "1" *-- "*" analysisRequest
    analysisRequest "1" *-- "1" analysisResult
    analysisRequest "*" o-- "1" doctor
}

```
