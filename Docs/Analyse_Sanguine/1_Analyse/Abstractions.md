# Abstractions

## Diagramme de classe

```plantuml
@startuml
hide circle
hide method
hide attribute
package Entité{
    class "Dossier" as file
    class "RequeteAnalyse" as analysisRequest
    class "Médecin" as doctor
    class "ResultatAnalyse" as analysistResult
    class "Type de test" as testType
    class "TypeAnalyse" as analysisType
    
}

file "1" *-- "*" analysisRequest
analysisRequest "*" o-- "1" doctor
analysistResult "*" --* "1" analysisRequest
testType "1" --o "1" analysistResult
testType "1" --* "*" analysisType
analysisRequest "1" o-- "*" analysisType
@enduml
```

## Glossaire

### Entités

#### Requête d'analyse sanguine (*RequeteAnalyse*)

* Définition : Une requête d'analyse sanguine est une demande provenant d'un médecin qui requiert l'évaluation de certaines propriétés d'un échantillon sanguin. Voir InfoClient/Requête *.pdf pour des exemples de requête d'analyse de divers hopitaux.
* Synonyme : N/A

#### Résultat d'analyse

* Définition : Lié à une requête d'analyse sanguine, un résultat d'analyse représente les valeurs associés aux propriétés évalués lors de l'analyse de l'échantillon. Par exemple: Hémoglobine: 11.9 g/100 mL VR : 11.5 à 15.0.
* Synonyme : N/A

#### Type d'analyse

* Défintion : Dans une requête d'analyse, les types d'analyses représentent les cases cochées. Par exemple: FSC -> Formule sanguine complète.
* Synonyme : N/A

#### Type de test

* Définition : Un type de test est lié à un type d'analyse et il représente un type de valeur avec des unités et des valeurs de référence. Par exemple: Hémoglobine g/mL VR: 11.5 à 15.0 .

#### Dossier

* Définition : Le dossier représente les informations d'un patient d'une analyse sanguine. Ce dossier est lié aux requêtes d'analyse présentes et passées.
* Synonyme : Dossier d'un patient

#### Médecin

* Définition : Le médecin est l'individu qui émet une requête d'analyse et qui recevra les résultats par la suite.
* Synonyme : N/A
