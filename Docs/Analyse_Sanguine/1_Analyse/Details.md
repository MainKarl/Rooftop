# Diagramme de détails

```plantuml

hide circle
left to right direction

package Entité{
    class "Dossier" as file{
        uint NumeroDossier
        byte Sexe
        string Prenom
        string Nom
        Date DateNaissance
        string Notes
    }

    class "RequeteAnalyse" as analysisRequest{
        DateTime DatePrelevement
        string NomTechnicien
        guid CodeAcces
    }
    
    class "Medecin" as doctor{
        string Prenom
        string Nom
    }

    class "ResultatAnalyse" as analysisResult{
        float Valeur
    }
    
    class "TypeValeur" as testType{
        string Unite
        string Nom
    } 

    class "TypeAnalyse" as analysisType{
        string Nom
    }

    file "1" *-- "*" analysisRequest
    analysisRequest "*" o-- "1" doctor
    analysisResult "*" --* "1" analysisRequest
    testType "1" --o "1" analysisResult
    testType "1" --* "*" analysisType 
    analysisRequest "1" o-- "*" analysisType
}

```
