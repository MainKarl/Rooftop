import React, { useEffect, useState } from 'react';
import { StyleSheet, TextInput, View, Text, Button, ScrollView, PlatformColor } from 'react-native';
import CheckBox from '@react-native-community/checkbox';
import DropDownPicker from 'react-native-dropdown-picker';
import AnalyseConfig from '../analyseConfig.json';
import RequeteAnalyses from './RequeteAnalyses';
import AlertConnectionFailed from './AlertConnectionFailed';

const ModalAddRequete = props => {
  const CheckboxData = [];
  let isSelected;

  const [open, setOpen] = useState(false);
  const [value, setValue] = useState(null);
  const [medecins, setMedecins] = useState([]);
  const [analyses, setAnalyses] = useState([]);
  const [analyseDemande, setAnalyseDemande] = useState("-");
  const [nomTechnicien, setNomTechnicien] = useState("");
  const [selectedAnalyses, setselectedAnalyses] = useState([]);

  const onNomTechnicienChange = (nouveauNom) => {
    setNomTechnicien(nouveauNom);
  }


  function createRequete() {
    let method = "create";
    const url = AnalyseConfig.API_URL + "requete/" + method;

    const formObj = {
      NomTechnicien: nomTechnicien,
      DossierIdDossier: props.patientInfo.idDossier,
      MedecinIdMedecin: value,
      lstAnalyses: selectedAnalyses,
      analyseDemande: analyseDemande
    }

    const body = JSON.stringify(formObj);

    fetch(url, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: body,
      cache: 'default'
    }).then((response) => {
      if (response.ok) {
        props.updateformAddRequeteVisible();
      } else {
        console.log(response);
      }
    }).catch((error) => {
      console.log(error);
    })
  }

  useEffect(() => {
    if (props.selectedFolder != '') {
      let url = AnalyseConfig.API_URL + 'medecin';
      fetch(url)
        .then(response => {
          if (response.ok) {
            response.json().then(data => {
              const medecinItems = data.map(m => {
                return { label: m.prenom + ' ' + m.nom, value: m.idMedecin };
              });

              setMedecins(medecinItems);
            });
          } else {
            console.log(response);
          }
        })
        .catch(error => {
          console.log(error);
        });

      url = AnalyseConfig.API_URL + 'typeanalyse/categories';
      fetch(url)
        .then(response => {
          if (response.ok) {
            response.json().then(data => {
              console.log(data);
              setAnalyses(data);
            });
          } else {
            console.log(response);
          }
        })
        .catch(error => {
          console.log(error);
        });

    }
  }, [props.selectedFolder]);


  return (
    <View>

      <Text style={{ fontSize: 50, fontWeight: 'bold' }}>Créer une requête</Text>
      <View style={styles.Form}>
        <View style={styles.info}>
          <Text style={styles.infoText}>
            Numéro de dossier:{' '}
            <Text style={styles.actualInfo}>{props.patientInfo.idDossier}</Text>
          </Text>
          <Text style={styles.infoText}>
            Nom: <Text style={styles.actualInfo}>{props.patientInfo.nom}</Text>
          </Text>
          <Text style={styles.infoText}>
            Prénom:{' '}
            <Text style={styles.actualInfo}>{props.patientInfo.prenom}</Text>
          </Text>
          <Text style={styles.infoText}>
            Sexe: <Text style={styles.actualInfo}>{props.patientInfo.sexeText}</Text>
          </Text>
          <Text style={styles.infoText}>
            Date de naissance:{' '}
            <Text style={styles.actualInfo}>
              {props.patientInfo.dateNaissanceText}
            </Text>
          </Text>
          <View>
            <View style={styles.infoText}>
              <DropDownPicker
                placeholder="Choisir un médecin associé"
                open={open}
                value={value}
                items={medecins}
                setOpen={setOpen}
                setValue={setValue}
                setItems={setMedecins}
              />
            </View>
            <TextInput placeholder="Nom du technicien" onChangeText={newName => onNomTechnicienChange(newName)} />
          </View>

        </View>
        <ScrollView style={{
          borderColor: '#808080',
          borderWidth: 2,
          borderRadius: 5,
          borderStyle: 'solid',
          marginTop: 10,
          marginBottom: 10,
        }}>
          <RequeteAnalyses analyses={analyses} selectedAnalyses={selectedAnalyses} setselectedAnalyses={setselectedAnalyses} />
          <View style={styles.Biologie}>
            <View style={{ flex: 0.1 }}>
            </View>
          </View>
        </ScrollView>
        <Button
          title='Créer'
          onPress={() => createRequete()}
        />
        <Button
          title="Annuler"
          onPress={() => props.updateformAddRequeteVisible()}
        />
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  Form: {
    height: '90%',
    width: '90%',
    marginTop: 30,
    marginLeft: 50,

  },
  Biologie: {
    display: 'flex',
    flexDirection: 'row',
  },
  Label: {
    flex: 0.9,
    marginTop: 5,
  },
  infoText: {
    marginBottom: 10,
  },
  actualInfo: {
    fontWeight: 'bold',
  },
  info: {
    zIndex: 1000,
    elevation: 1000,
    width: '50%'
  }
});

export default ModalAddRequete;
