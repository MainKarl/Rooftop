import React, {useState} from 'react';
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
} from 'react-native';
import RequestList from './RequestList';

const FolderDetails = props => {
  const [patientInfo, setpatientInfo] = useState({
    key: '8761',
    FirstName: 'Victor',
    LastName: 'Turgeon',
    Gender: 'M',
    BirthDate: '2003-02-02',
    NumAssMaladie: 'TURV 0000 0000',
    Note: '',
  });

  if (patientInfo.key === props.selectedFolder) {
    return (
      <View style={{flex: 0.8, margin: 5}}>
        <View style={styles.detailsDisplay}>
          <View style={styles.patientInfo}>
            <View style={styles.flexHalf}>
              <Text style={styles.infoText}>
                Numéro de dossier:{' '}
                <Text style={styles.actualInfo}>{patientInfo.key}</Text>
              </Text>
              <Text style={styles.infoText}>
                Nom:{' '}
                <Text style={styles.actualInfo}>{patientInfo.LastName}</Text>
              </Text>
              <Text style={styles.infoText}>
                Prénom:{' '}
                <Text style={styles.actualInfo}>{patientInfo.FirstName}</Text>
              </Text>
              <Text style={styles.infoText}>
                Sexe:{' '}
                <Text style={styles.actualInfo}>{patientInfo.Gender}</Text>
              </Text>
              <Text style={styles.infoText}>
                Date de naissance:{' '}
                <Text style={styles.actualInfo}>{patientInfo.BirthDate}</Text>
              </Text>
              <Text>
                Numéro d'assurance maladie:{' '}
                <Text style={styles.actualInfo}>
                  {patientInfo.NumAssMaladie}
                </Text>
              </Text>
            </View>
            <View style={styles.flexHalf}>
              <Text style={styles.infoText}>Notes:</Text>
              <TextInput
                style={{height: '70%'}}
                multiline
                scrollEnabled></TextInput>
              <View style={{display: 'flex', flexDirection: 'row'}}>
                <View style={{flex: 0.7}}>
                  <Button title="Sauvegarder" disabled></Button>
                </View>
                <View style={{flex: 0.3}}>
                  <Button style={{flex: 0.3}} title="Annuler" disabled></Button>
                </View>
              </View>
            </View>
          </View>
          <View style={styles.requetesEtResultat}>
          <RequestList onChangeState={props.onChangeState} />
          </View>
        </View>
      </View>
    );
  } else {
    return (
      <View style={{flex: 0.8, margin: 5}}>
        <Text style={styles.texteErreur}>
          L'information du patient n'a pas été trouvée!
        </Text>
      </View>
    );
  }
};

const styles = StyleSheet.create({
  texteErreur: {
    textAlign: 'center',
    marginTop: 300,
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
