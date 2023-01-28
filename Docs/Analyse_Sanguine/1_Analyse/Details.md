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
    }

    class "RequeteAnalyze" as analysisRequest{
        uint Id
        uint FileId
        uint DoctorId
        DateTime SamplingDate
        json RequestedAnalysis
        string TechName
        guid AccessCode
    }
    
    class "ResultatAnalyze" as analysisResult{
        uint Id
        uint RequestId
        string Results
    }

    class "Medecin" as doctor{
        uint Id
        string FirstName
        string LastName
    }

    file "1" *-- "*" analysisRequest
    analysisRequest "1" *-- "1" analysisResult
    analysisRequest "*" o-- "1" doctor
}