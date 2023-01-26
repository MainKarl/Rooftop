
```plantuml
@startuml
hide circle
hide method
hide attribute
package Entité{
    class "Dossier" as file
    class "RequetePrelevement" as sampleRequest
    class "ResultatPrelevement" as sampleResult
}

file "1" o-- "*" sampleRequest
sampleRequest "1" *-- "1" sampleResult
@enduml