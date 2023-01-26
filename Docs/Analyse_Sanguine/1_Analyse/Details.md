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
}