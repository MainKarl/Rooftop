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
    }

    class "RequeteAnalyze" as analysisRequest{
        uint Id
        uint FileId
        uint DoctorId
        DateTime SamplingDate
        string TechName
    }
    
    class "ResultatAnalyze" as analysisResult{

    }

    file "1" o-- "*" analysisRequest
    analysisRequest "1" *-- "1" analysisResult
}