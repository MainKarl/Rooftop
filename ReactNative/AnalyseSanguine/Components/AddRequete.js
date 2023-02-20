import React, { useEffect, useState } from 'react';
import { StyleSheet, TextInput, View, Text, Button, ScrollView, PlatformColor } from 'react-native';
import CheckBox from '@react-native-community/checkbox';
import DropDownPicker from 'react-native-dropdown-picker';
import AnalyseConfig from '../analyseConfig.json';
import RequeteAnalyses from './RequeteAnalyses';
import AlertConnectionFailed from './AlertConnectionFailed';
import CustomAlert from './CustomAlert';
import customRadioButton from './CustomRadioButton';

const ModalAddRequete = props => {
  const CheckboxData = [];
  let isSelected;

  const [open, setOpen] = useState(false);
  const [value, setValue] = useState(null);
  const [medecins, setMedecins] = useState([]);
  const [analyses, setAnalyses] = useState([]);
  const [analyseDemande, setAnalyseDemande] = useState("-");
  const [nomTechnicien, setNomTechnicien] = useState("");
  const [errorTechnicien, setErrorTechnicien] = useState(true);
  const [selectedAnalyses, setselectedAnalyses] = useState([]);

  const onNomTechnicienChange = (nouveauNom) => {
    if (nouveauNom == '')
      setErrorTechnicien(true);
    else
      setErrorTechnicien(false);
    
    setNomTechnicien(nouveauNom);
  }


  function createRequete() {
    if (value != null && !errorTechnicien) {
      CustomAlert({ 
        type:'alert_confirmation', 
        title:'Validation de création', 
        message: 'Est-ce que vous voulez vraiment créer la requête de prélévement?',
        onSelect: () => {
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
            console.log(response);
            if (response.ok) {
              CustomAlert({ 
                type:'alert_message', 
                title:'Création', 
                message:'La requête de prélévement de ' + props.patientInfo.prenom + ' ' + props.patientInfo.nom + ' a été créée!', 
                onSelect: () => {props.updateformAddRequeteVisible(); } 
              });
            } else {
              response.json().then((item) => {
                CustomAlert({
                  type: 'alert_submit_failed',
                  message: item
                });
              });
            }
          }).catch((error) => {
            CustomAlert({
              type: 'alert_submit_failed',
              message: error
            });
          })
        },
        onCancel: () => {}
      });
    }
    else {
      CustomAlert({
        type: 'alert_submit_failed',
        message: 'le médecin ou le technicien ne peut pas être vide.'
      });
    }
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
    <ScrollView>
      <Text style={{ fontSize: 50, fontWeight: 'bold', paddingLeft: 45 }}>Créer une requête</Text>
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
            { value == null && <Text style={styles.error}>Un médecin doit être sélectionné!</Text>}
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
            { errorTechnicien && <Text style={styles.error}>Le nom du technicien ne peut pas être vide!</Text> }
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
            <View>
            </View>
          </View>
        </ScrollView>
        <Button
          title='Créer'
          style={styles.button}
          onPress={() => createRequete()}
        />
        <Button
          title="Annuler"
          style={styles.button}
          onPress={() => props.updateformAddRequeteVisible()}
        />
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  Form: {
    marginTop: 20,
    marginLeft: 50,
    marginRight: 50,
    marginBottom: 20
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
    zIndex: 100
  },
  actualInfo: {
    fontWeight: 'bold',
  },
  info: {
    zIndex: 1000,
    elevation: 1000
  },
  error: {
    color: 'red'
  },
  button: {
    marginBottom: 15
  }
});

export default ModalAddRequete;
