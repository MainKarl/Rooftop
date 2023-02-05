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

const RequestDetails = props => {
  const [patientInfo, setpatientInfo] = useState({
    key: '8761',
    FirstName: 'Victor',
    LastName: 'Turgeon',
    Gender: 'M',
    BirthDate: '2003-02-02',
      NumAssMaladie: 'TURV 0000 0000',
      Note: '',
  });

    return (
        <View>
            <Text>Voici les détails de la requête!</Text>
        </View>
    );

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

export default RequestDetails;