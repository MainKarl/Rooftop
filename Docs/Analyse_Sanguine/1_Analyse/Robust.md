# Analyse de robustesse

```plantuml
Left to right direction
actor user
entity Dossier
entity RequêteAnalyse
entity RésultatAnalyse
entity Médecin

boundary GérerDossiers
boundary GérerRequêtes
boundary GérerMédecins

control CréerMédecin
control CréerRequêtePrélèvement
control CréerDossier
control AjouterRésultatAnalyse

user -- GérerDossiers
user -- GérerRequêtes
user -- GérerMédecins

GérerMédecins -- CréerMédecin
GérerRequêtes -- CréerRequêtePrélèvement
GérerDossiers -- CréerDossier
GérerRequêtes -- AjouterRésultatAnalyse

CréerMédecin -- Médecin
CréerRequêtePrélèvement -- RequêteAnalyse
CréerDossier -- Dossier
AjouterRésultatAnalyse -- RésultatAnalyse

```