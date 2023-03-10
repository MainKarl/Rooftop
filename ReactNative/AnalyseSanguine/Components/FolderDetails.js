import React, { useEffect, useState } from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  FlatList,
  TextInput,
  Touchable,
  TouchableHighlight,
  TouchableOpacity,
  PlatformColor,
  ActivityIndicator,
} from 'react-native';
import RequestList from './RequestList';
import ModalAddRequete from './AddRequete';
import AnalyseConfig from '../analyseConfig.json';

const FolderDetails = props => {
  const [patientInfo, setpatientInfo] = useState(null);
  const [DetailVisible, setDetailVisible] = useState(true);
  const [formAddRequeteVisible, setformAddRequeteVisible] = useState(false);
  const [nouvelleNote, setNouvelleNote] = useState("");
  const SexeDict = ["Homme", "Femme", "Autre"];

  useEffect(() => {
    if (props.selectedFolder != '') {
      const url =
        AnalyseConfig.API_URL +
        'dossier/getdetaille?id=' +
        props.selectedFolder;
      props.setIsLoading(true);
      fetch(url)
        .then(response => {
          if (response.ok) {
            response.json().then((data) => {
              data.dateNaissanceText = String(data.dateNaissance).split('T')[0];
              data.sexeText = SexeDict[data.sexe];
              setpatientInfo(data);
              setNouvelleNote(data.note ? data.note : "")
              props.setIsLoading(false);
            });
          } else {
            console.log(response);
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  }, [props.selectedFolder, DetailVisible]);

  function updateformAddRequeteVisible() {
    if (formAddRequeteVisible) {
      setpatientInfo("Dirty");
    }
    setformAddRequeteVisible(!formAddRequeteVisible);
    setDetailVisible(!DetailVisible);
    console.log(formAddRequeteVisible);
  }

  function updateNote() {
    const url = AnalyseConfig.API_URL + "dossier/updatenote";
    var formObj = {
      id: patientInfo.idDossier,
      note: nouvelleNote,
    };
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
        //Afficher Confirmation

        let obj = patientInfo
        obj.note = nouvelleNote
        setpatientInfo(obj)
      } else {
        //AlertConnectionFailed(sendFormToAPI)
      }
    }).catch((error) => {
      console.log(error);
      //AlertConnectionFailed(sendFormToAPI)
    })
  }

  function setNewNote(text) {
    setNouvelleNote(text)
  }

  const callCreateForm = () => {
    props.changeEditingMode(true)
    props.onChangeState(1);
  }

  if (DetailVisible) {
    if (patientInfo && patientInfo.idDossier === props.selectedFolder) {
      return (
        <View style={{ flex: 0.8, margin: 5, display: 'flex', flexDirection: 'column' }}>
          <View style={styles.detailsDisplay}>
            <View style={styles.patientInfo}>
              <View style={styles.flexHalf}>
                <View style={{ display: 'flex', flexDirection: 'row' }}>
                  <View style={{ flex: 0.7, display: 'flex', flexDirection: 'column' }}>
                    <View style={{ flex: 1, display: 'flex', flexDirection: 'column', paddingTop: '3%', paddingLeft: '1%' }}>
                      <Text style={styles.infoText}>
                        Num??ro de dossier:{' '}
                        <Text style={styles.actualInfo}>{patientInfo.idDossier}</Text>
                      </Text>
                      <Text style={styles.infoText}>
                        Nom:{' '}
                        <Text style={styles.actualInfo}>{patientInfo.nom}</Text>
                      </Text>
                      <Text style={styles.infoText}>
                        Pr??nom:{' '}
                        <Text style={styles.actualInfo}>{patientInfo.prenom}</Text>
                      </Text>
                      <Text style={styles.infoText}>
                        Sexe:{' '}
                        <Text style={styles.actualInfo}>{patientInfo.sexeText}</Text>
                      </Text>
                      <Text style={styles.infoText}>
                        Date de naissance:{' '}
                        <Text style={styles.actualInfo}>{patientInfo.dateNaissanceText}</Text>
                      </Text>
                    </View>
                  </View>
                  <View style={{ flex: 0.3, paddingTop: '2%' }}>
                    <Button title="Modifier" onPress={callCreateForm}></Button>
                  </View>
                </View>
              </View>
              <View style={styles.flexHalf}>
                <View style={{ flex: 1 }}>
                  <Text style={{ marginBottom: 12 }}>Notes:</Text>
                  <TextInput
                    style={{ flex: 1 }}
                    multiline
                    value={nouvelleNote}
                    onChangeText={(newNote) => setNewNote(newNote)}
                    scrollEnabled>
                  </TextInput>
                  <View style={{ display: 'flex', flexDirection: 'row' }}>
                    <View style={{ flex: 0.7 }}>
                      <Button title="Sauvegarder" onPress={() => updateNote()}></Button>
                    </View>
                    <View style={{ flex: 0.3 }}>
                      <Button
                        title="Annuler"
                        onPress={() => setNouvelleNote(patientInfo.note ? patientInfo.note : "")}></Button>
                    </View>
                  </View>
                </View>
              </View>
            </View>
            <View style={styles.requestsList}>
              <View style={styles.addButton}>
                <Button
                  style={{}}
                  title="Cr??er une requ??te"
                  onPress={() => updateformAddRequeteVisible()}
                />
              </View>
              <View style={styles.requetesEtResultat}>
                <RequestList requests={patientInfo.lstRequetes} onSelectedRequest={props.onSelectedRequest} onChangeState={props.onChangeState} />
              </View>
            </View>
          </View>
        </View >
      );
    } else if (props.isLoading) {
      return (
        <View style={{ flex: 0.8, margin: 5 }}>
          <View style={styles.texteErreur}>
            <ActivityIndicator size="large" />
          </View>
        </View>
      );
    }
  } else if (formAddRequeteVisible) {
    {
      return (
        <View style={{ flex: 0.8, margin: 5 }}>
          <ModalAddRequete
            patientInfo={patientInfo}
            updateformAddRequeteVisible={() => updateformAddRequeteVisible()}
          />
        </View>
      );
    }
  } else if (formAddRequeteVisible) {
    {
      return (
        <View style={{ flex: 0.8, margin: 5 }}>
          <ModalAddRequete
            updateformAddRequeteVisible={() => updateformAddRequeteVisible()}
          />
        </View>
      );
    }
  }
};

const styles = StyleSheet.create({
  texteErreur: {
    textAlign: 'center',
    marginTop: 300,
  },
  addButton: {
    borderWidth: 2,
    borderRadius: 5,
    borderBottomLeftRadius: 0,
    borderBottomRightRadius: 0,
    borderStyle: 'solid',
    borderColor: PlatformColor('SystemAccentColor'),
    backgroundColor: PlatformColor('SystemAccentColor'),
    marginBottom: 0,
  },
  detailsDisplay: {
    display: 'flex',
    flexDirection: 'column',
    flex: 1
  },
  requestsList: {
    flex: 0.8,
    display: 'flex',
    flexDirection: 'column',
  },
  patientInfo: {
    flex: 0.2,
    display: 'flex',
    flexDirection: 'row',
    marginBottom: 12,
  },
  requetesEtResultat: {
    borderColor: '#808080',
    borderTopWidth: 0,
    borderWidth: 2,
    borderRadius: 5,
    borderTopLeftRadius: 0,
    borderTopRightRadius: 0,
    borderStyle: 'solid',
    flex: 1
  },
  flexHalf: {
    flex: 0.5,
    paddingHorizontal: 12,
  },
  infoText: {
    margin: 'auto',
    fontSize: 17
  },
  actualInfo: {
    fontWeight: 'bold',
  },
});

export default FolderDetails;
