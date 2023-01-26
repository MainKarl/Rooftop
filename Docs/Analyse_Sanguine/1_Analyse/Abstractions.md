
```plantuml
@startuml
hide circle
hide method
hide attribute
package Entité{
    class "Patient" as patient
    class "RequetePrelevement" as sampleRequest
    class "ResultatPrelevement" as sampleResult
}

patient "1"--"*"sampleRequest
@enduml