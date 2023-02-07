import React, {useEffect, useState} from 'react';
import {StyleSheet, TextInput, View, Text, Button} from 'react-native';
import CheckBox from '@react-native-community/checkbox';
import DropDownPicker from 'react-native-dropdown-picker';
import AnalyseConfig from '../analyseConfig.json';

const ModalAddRequete = props => {
  const CheckboxData = [];
  let isSelected;

  const [open, setOpen] = useState(false);
  const [value, setValue] = useState(null);
  const [medecins, setMedecins] = useState([
    {label: 'Apple', value: 'apple'},
    {label: 'Banana', value: 'banana'},
  ]);

  useEffect(() => {
    if (props.selectedFolder != '') {
      const url = AnalyseConfig.API_URL + 'medecin';
      fetch(url)
        .then(response => {
          if (response.ok) {
            response.json().then(data => {
              const medecinItems = data.map(m => {
                return {label: m.prenom + ' ' + m.nom, value: m.idMedecin};
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
    }
  }, [props.selectedFolder]);

  return (
    <View>
      <Text style={{fontSize: 50, fontWeight: 'bold'}}>Créer une requête</Text>
      <View style={styles.Form}>
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
          Sexe: <Text style={styles.actualInfo}>{props.patientInfo.sexe}</Text>
        </Text>
        <Text style={styles.infoText}>
          Date de naissance:{' '}
          <Text style={styles.actualInfo}>
            {props.patientInfo.dateNaissance}
          </Text>
        </Text>
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
        <TextInput placeholder="Nom du technicien" />
        <View style={{paddingTop: 40}}>
          <Text style={{fontWeight: 'bold', fontSize: 30}}>Biochimie</Text>
          <View style={styles.Biologie}>
            <View style={{flex: 0.1}}>
              <CheckBox
                disabled={false}
                value={isSelected}
                onValueChange={newValue => isSelected}
              />
            </View>
            <View style={styles.Label}>
              <Text>ACURI</Text>
            </View>
          </View>
        </View>
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
    height: '100%',
    width: 500,
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
    zIndex: 1000,
  },
  actualInfo: {
    fontWeight: 'bold',
  },
});

export default ModalAddRequete;
