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
import { create } from 'react-test-renderer';

const FolderCreateForm = props => {
    const [patientInfo, setpatientInfo] = useState(null);
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [sexe, setSexe] = useState(0)
    const [date, setDate] = useState(new Date())
    const [isLiked, setIsLiked] = useState([
        { value: 0, label: 'Homme', selected: false },
        { value: 1, label: 'Femme', selected: false },
        { value: 2, label: 'Autres', selected: false }
    ]);

    useEffect(()=> {
        if(props.IsEditing){
            const url = AnalyseConfig.API_URL + 'dossier/getdetaille?id=' + props.selectedFolder;
            fetch(url)
            .then((response) => {
                if (response.ok) {
                    response.json().then((data) => {
                        setpatientInfo(data);
                        onSexeChange(data.sexe)
                        setFirstName(data.prenom)
                        setLastName(data.nom)
                        setDate(new Date(data.dateNaissance))
                        return
                    });
                }
                else {
                    console.log(response);
                    return
                }
    
            }).catch((error) => {
                console.log(error);
                return
            });
        }
    }, [])

    const onFirstNameChange = (newFirstName) => {
        setFirstName(newFirstName);
    }

  const onLastNameChange = newLastName => {
    setLastName(newLastName);
  };

    const onSexeChange = (newSexe) => {
        let updatedState = isLiked.map((isLikedItem) =>
            isLikedItem.value === newSexe
                ? { ...isLikedItem, selected: true }
                : { ...isLikedItem, selected: false }
        );
        setIsLiked(updatedState);
        setSexe(newSexe);
    }

    const onSubmit = () => {
        Alert.alert('Création de dossier de patient', 'Voulez-vous vraiment créer le patient \n' + firstName + ' ' + lastName + ' ?', [
            {
                text: 'Annuler',
                onPress: () => {}
            },
            {
                text: 'Confirmer',
                onPress: () => {
                    sendFormToAPI();
                }
            }
        ]);
    }

    const sendFormToAPI = () => {
        let method = props.IsEditing ? "update": "create";
        const url = AnalyseConfig.API_URL + "dossier/" + method;
        const formObj = {
            prenom: firstName,
            nom: lastName,
            dateNaissance: date,
            sexe: sexe,
          };

          const body = JSON.stringify(formObj);
          
        fetch(url, {
            method: 'POST',
            headers: {
                accept: 'application.json',
                'Content-Type': 'application/json'
            },
            body: body,
            Cache: 'default'
        }).then((response) => {
            if (response.ok) {
                props.onChangeState(0);
              } else {
                Alert.alert(
                  'Erreur de connexion',
                  "Un erreur s'est produite lors de la connexion au serveur.",
                  [
                    {
                      text: 'Ok',
                    },
                  ],
                );
              }
        }).catch((error) => {
            console.log(error);
        })
    }

    return (
        <View style={styles.container}>
            <Text style={styles.title}>{props.IsEditing ? 'Modification' : 'Création'} d'un dossier de patient</Text>
            <View style={styles.formRow}>
                <Text style={styles.formLabel}>Prénom du patient:</Text>
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
            <View style={styles.formRow}>
                <Text style={styles.formLabel}>Date de naissance du patient:</Text>
                <DatetimePicker
                    mode="date"
                    value={date}
                    onChange={(event, value) => { setDate(value); }} />
            </View>
            <Button title={props.IsEditing ? 'Modifer' : 'Créer'} onPress={onSubmit}></Button>
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
    marginBottom: 30,
  },
});

export default FolderCreateForm;
