# Cas d'utilisations

```plantuml
@startuml
left to right direction
actor user as user

package "Analyse sanguine"{
    usecase ([[#!UseCases/UC01.md UC01\nCréer une requête de prélévement]]) as UC01

    usecase ([[#!UseCases/UC02.md UC02\nVisualiser les requêtes de prélévement]]) as UC02

    usecase ([[#!UseCases/UC03.md UC03\nVisualiser les dossiers des patients]]) as UC03

    usecase ([[#!UseCases/UC04.md UC04\nRechercher un dossier d'un patient]]) as UC04

    usecase ([[#!UseCases/UC05.md UC05\nVisualiser un dossier d'un patient]]) as UC05

    usecase ([[#!UseCases/UC06.md UC06\nVisualiser une requête de prélévement]]) as UC06

    usecase ([[#!UseCases/UC07.md UC07\nAjout du résultat d'analyse au dossier d'un patient]]) as UC07

    usecase ([[#!UseCases/UC08.md UC08\nImprimer l'analyse d'une requête]]) as UC08

    usecase ([[#!UseCases/UC09.md UC09\nCréer un médecin]]) as UC09

    usecase ([[#!UseCases/UC10.md UC10\nCréer le dossier d'un patient]]) as UC10

    usecase ([[#!UseCases/UC11.md UC11\nModifier le dossier d'un patient]]) as UC11

    UC02 ..> UC06 : extends
    UC03 .> UC04 : extends
    UC03 ..> UC05 : extends
    UC04 ..> UC05 : extends
    UC06 ..> UC08 : extends
    UC02 ..> UC07 : extends
    UC03 ..> UC01 : extends
    UC03 ..> UC02 : extends
    UC05 ..> UC11 : extends
}

user --> UC03
user --> UC09
user --> UC10
@enduml
```
