import React, { useEffect, useState } from 'react';
import {
  View,
  StyleSheet,
  Text,
  TextInput,
  Button,
  Alert
} from 'react-native';
import DatetimePicker from '@react-native-community/datetimepicker';
import CustomRadioButton from './CustomRadioButton';
import AnalyseConfig from '../analyseConfig.json';
import AlertConnectionFailed from './AlertConnectionFailed';
import { create } from 'react-test-renderer';
import CustomAlert from './CustomAlert';

const FolderCreateForm = props => {
  const [errorDate, setErrorDate] = useState(false);

  const [patientInfo, setpatientInfo] = useState(null);
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [sexe, setSexe] = useState(null)
  const [date, setDate] = useState(new Date())
  const [isLiked, setIsLiked] = useState([
    { value: 0, label: 'Homme', selected: false },
    { value: 1, label: 'Femme', selected: false },
  ]);

  useEffect(() => {
    if (props.IsEditing) {
      getDetail()
    }
  }, [])

  function getDetail() {
    props.setIsLoading(true);
    const url = AnalyseConfig.API_URL + 'dossier/getdetaille?id=' + props.selectedFolder;
    fetch(url)
      .then((response) => {
        if (response.ok) {
          response.json().then((data) => {
            console.log(data)
            setpatientInfo(data);
            onSexeChange(data.sexe)
            setFirstName(data.prenom)
            setLastName(data.nom)
            setDate(new Date(data.dateNaissance))
            props.setIsLoading(false);
            return
          });
        }
        else {
          //AlertConnectionFailed(getDetail)
          return
        }
      }).catch((error) => {
        //AlertConnectionFailed(getDetail)
        return
      });
  }

  const onFirstNameChange = (newFirstName) => {
    setFirstName(newFirstName);
  }

  const onLastNameChange = newLastName => {
    setLastName(newLastName);
  };

  const onSetDate = newDate => {
    var testDate = new Date(newDate);
    testDate.setHours(0, 0, 0, 0);
    setErrorDate(false);
    if (testDate > new Date())
      setErrorDate(true);
    else
      setDate(newDate);
  }

  const onSexeChange = (newSexe) => {
    let updatedState = isLiked.map((isLikedItem) =>
      isLikedItem.value === newSexe
        ? { ...isLikedItem, selected: true }
        : { ...isLikedItem, selected: false }
    );
    setIsLiked(updatedState);
    setSexe(newSexe);
    console.log(newSexe)
  }

  const onSubmit = () => {
    if (errorDate) {
      CustomAlert({
        type: 'alert_submit_failed',
        message: 'la date de naissance doit ??tre avant aujourd\'hui'
      });
    }
    else if (sexe != 0 && !sexe) {
      CustomAlert({
        type: 'alert_submit_failed',
        message: 'le sexe de la personne doit ??tre s??lectionn??'
      });
    }
    else {
      Alert.alert('Cr??ation de dossier de patient', 'Voulez-vous vraiment cr??er le patient \n' + firstName + ' ' + lastName + ' ?', [
        {
          text: 'Annuler',
          onPress: () => { }
        },
        {
          text: 'Confirmer',
          onPress: () => {
            sendFormToAPI();
          }
        }
      ]);
    }
  }

  const sendFormToAPI = () => {
    let method = props.IsEditing ? "update" : "create";
    const url = AnalyseConfig.API_URL + "dossier/" + method;
    var formObj = {
      prenom: firstName,
      nom: lastName,
      dateNaissance: date,
      sexe: sexe,
    };
    if (props.IsEditing) {
      formObj.idDossier = patientInfo.idDossier
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
        props.onChangeState(0);
      } else {
        //AlertConnectionFailed(sendFormToAPI)
      }
    }).catch((error) => {
      console.log(error);
      //AlertConnectionFailed(sendFormToAPI)
    })
  }


  return (
    <View style={styles.container}>
      <Text style={styles.title}>{props.IsEditing ? 'Modification' : 'Cr??ation'} d'un dossier de patient</Text>
      <Text style={styles.button}></Text>
      <View style={styles.formRow}>
        <Text style={styles.formLabel}>Pr??nom du patient:</Text>
        <TextInput style={styles.formInput} defaultValue={props.IsEditing && patientInfo ? patientInfo.prenom : ""} onChangeText={newName => onFirstNameChange(newName)} />
      </View>
      <View style={styles.formRow}>
        <Text style={styles.formLabel}>Nom du patient:</Text>
        <TextInput style={styles.formInput} defaultValue={props.IsEditing && patientInfo ? patientInfo.nom : ""} onChangeText={newName => onLastNameChange(newName)} />
      </View>
      <View style={styles.formRow}>
        <Text style={styles.formLabel}>Sexe du patient:</Text>
        <View style={styles.formInput}>
          {isLiked.map((item) => (
            <CustomRadioButton
              onSelect={() => onSexeChange(item.value)}
              key={item.value}
              item={item} />
          ))}
        </View>
      </View>
      {errorDate && <Text style={styles.error}>La date de naissance ne peut pas ??tre dans le future</Text>}
      <View style={styles.formRow}>
        <Text style={styles.formLabel}>Date de naissance du patient:</Text>
        <DatetimePicker
          mode="date"
          value={date}
          onChange={(event, value) => { onSetDate(value); }} />
      </View>
      <Text style={styles.button}></Text>
      <Button title={props.IsEditing ? 'Modifer' : 'Cr??er'} onPress={onSubmit}></Button>
      <Text style={styles.button}></Text>
      <Button title="Annuler" onPress={() => props.onChangeState(0)}></Button>
    </View>
  );
  setIsLiked(updatedState);
  setSexe(newSexe);
};

const styles = StyleSheet.create({
  container: {
    flex: 0.8,
    margin: 5,
    borderColor: '#808080',
    borderWidth: 2,
    borderRadius: 5,
    borderStyle: 'solid',
    paddingTop: '2%',
    paddingBottom: '2%',
    paddingLeft: '5%',
    paddingRight: '5%',
  },
  title: {
    fontSize: 50,
    marginBottom: 20,
  },
  formRow: {
    width: '100%',
    minHeight: 40,
    display: 'flex',
    flexWrap: 'wrap',
    flexDirection: 'row',
    marginBottom: '1%',
  },
  formLabel: {
    width: '15%',
  },
  formInput: {
    width: '85%',
  },
  radioButton: {
    marginBottom: '2%',
  },
  button: {
    marginTop: '2%',
  },
  error: {
    color: 'red',
    marginTop: 10,
    marginBottom: 10,
  }
});

export default FolderCreateForm;
