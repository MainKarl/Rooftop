
```plantuml
@startuml
hide circle
hide method
hide attribute
package Entité{
    class "Dossier" as file
    class "RequeteAnalyse" as analysisRequest
    class "ResultatAnalyse" as analysisResult
    class "Medecin" as doctor
}

file "1" *-- "*" analysisRequest
analysisRequest "1" *-- "1" analysisResult
analysisRequest "*" o-- "1" doctor
@enduml