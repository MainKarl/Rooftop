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
} from 'react-native';
import RequestList from './RequestList';
import ModalAddRequete from './AddRequete';
import AnalyseConfig from '../analyseConfig.json';


const FolderDetails = props => {
  const [patientInfo, setpatientInfo] = useState(null);
  const [DetailVisible, setDetailVisible] = useState(true);
  const [formAddRequeteVisible, setformAddRequeteVisible] = useState(false);

  useEffect(() => {

    if (props.selectedFolder != "") {

      const url = AnalyseConfig.API_URL + 'dossier/getdetaille?id=' + props.selectedFolder;
      fetch(url)
        .then((response) => {
          if (response.ok) {
            response.json().then((data) => {
              setpatientInfo(data);
            });
          }
          else {
            console.log(response);
          }

        }).catch((error) => {
          console.log(error);
        });
    }
  }, [props.selectedFolder])

  function updateformAddRequeteVisible() {
    setformAddRequeteVisible(!formAddRequeteVisible)
    setDetailVisible(!DetailVisible)
    console.log(formAddRequeteVisible)
  }

  if (DetailVisible) {

    if (patientInfo && patientInfo.idDossier === props.selectedFolder) {
      return (
        <View style={{ flex: 0.8, margin: 5 }}>
          <View style={styles.detailsDisplay}>
            <View style={styles.patientInfo}>
              <View style={styles.flexHalf}>
                <Text style={styles.infoText}>
                  Numéro de dossier:{' '}
                  <Text style={styles.actualInfo}>{patientInfo.idDossier}</Text>
                </Text>
                <Text style={styles.infoText}>
                  Nom:{' '}
                  <Text style={styles.actualInfo}>{patientInfo.nom}</Text>
                </Text>
                <Text style={styles.infoText}>
                  Prénom:{' '}
                  <Text style={styles.actualInfo}>{patientInfo.prenom}</Text>
                </Text>
                <Text style={styles.infoText}>
                  Sexe:{' '}
                  <Text style={styles.actualInfo}>{patientInfo.sexe}</Text>
                </Text>
                <Text style={styles.infoText}>
                  Date de naissance:{' '}
                  <Text style={styles.actualInfo}>{patientInfo.dateNaissance}</Text>
                </Text>
                {/* <Text>
                Numéro d'assurance maladie:{' '}
                <Text style={styles.actualInfo}>
                  {patientInfo.NumAssMaladie}
                </Text>
              </Text>*/}
              </View>
              <View style={styles.flexHalf}>
                <Text style={styles.infoText}>Notes:</Text>
                <TextInput
                  style={{ height: '70%' }}
                  multiline
                  scrollEnabled></TextInput>
                <View style={{ display: 'flex', flexDirection: 'row' }}>
                  <View style={{ flex: 0.7 }}>
                    <Button title="Sauvegarder" disabled></Button>
                  </View>
                  <View style={{ flex: 0.3 }}>
                    <Button style={{ flex: 0.3 }} title="Annuler" disabled></Button>
                  </View>
                </View>
              </View>
            </View>
            <View style={styles.requetesEtResultat}>
              <View style={styles.addButton}>
                <Button
                  style={{}}
                  title='Créer une requête'
                  onPress={() => updateformAddRequeteVisible()}
                />
              </View>
              <RequestList requests={patientInfo.lstRequetes} onSelectedRequest={props.onSelectedRequest} onChangeState={props.onChangeState} />
            </View>
          </View>
        </View>
      );
    } else {
      return (
        <View style={{ flex: 0.8, margin: 5 }}>
          <Text style={styles.texteErreur}>
            L'information du patient n'a pas été trouvée!
          </Text>
        </View>
      )
    }
  }
  else if (formAddRequeteVisible) {
    {
      return (
        <View style={{ flex: 0.8, margin: 5 }}>
          <ModalAddRequete updateformAddRequeteVisible={updateformAddRequeteVisible} />
        </View>
      )
    }
  };
}

const styles = StyleSheet.create({
  texteErreur: {
    textAlign: 'center',
    marginTop: 300,
  },
  addButton: {
    backgroundColor: PlatformColor('SystemAccentColor'),
    marginBottom: 0
  },
  detailsDisplay: {
    display: 'flex',
    flexDirection: 'column',
    height: '100%',
  },
  patientInfo: {
    flex: 0.2,
    marginBottom: 10,
    display: 'flex',
    flexDirection: 'row',
  },
  requetesEtResultat: {
    flex: 0.8,
    borderColor: '#808080',
    borderWidth: 2,
    borderRadius: 5,
    borderStyle: 'solid',
  },
  flexHalf: {
    flex: 0.5,

    padding: 15,
  },
  infoText: {
    marginBottom: 10,
  },
  actualInfo: {
    fontWeight: 'bold',
  },
});

export default FolderDetails;
