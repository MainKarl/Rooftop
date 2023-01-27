
```plantuml
@startuml
hide circle
hide method
hide attribute
package Entité{
    class "Dossier" as file
    class "RequeteAnalyse" as analysisRequest
    class "ResultatAnalyse" as analysisResult
}

file "1" o-- "*" analysisRequest
analysisRequest "1" *-- "1" analysisResult
@enduml