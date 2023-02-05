import React, { useState } from 'react';
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
  return (
    <View style={styles.container}>
      <View style={styles.detailsPadding}>
        <View style={styles.returnButton}>
          <Button
            title={'Retourner à la liste de requêtes'}
            onPress={() => props.updateVisible(props.selectedRequest)}></Button>
        </View>
        <View style={styles.detailsBox}>
          <View style={styles.detailsBoxInside}>
            <Text style={styles.infoText}>
              Code d'accès:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.key}</Text>
            </Text>
            <Text style={styles.infoText}>
              Date de prélèvement:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.SamplingDate}</Text>
            </Text>
            <Text style={styles.infoText}>
              Nom du médecin:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.LastNameDoctor}</Text>
            </Text>
            <Text style={styles.infoText}>
              Prénom du médecin:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.FirstNameDoctor}</Text>
            </Text>
            <Text style={styles.infoText}>
              Nom du technicien:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.LastNameTechnician}</Text>
            </Text>
            <Text style={styles.infoText}>
              Prénom du technicien:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.FirstNameTechnician}</Text>
            </Text>
          </View>
        </View>
      </View>
    </View>
  );

};

const styles = StyleSheet.create({
  container: {
    height: '100%',
    width: '100%'
  },
  detailsPadding: {
    paddingLeft: 80,
    paddingTop: 80,
  },
  detailsBox: {
    borderColor: '#808080',
    borderWidth: 1,
    marginTop: 20,
    width: 1200,
    height: 600,
  },
  detailsBoxInside: {
    paddingLeft: 40,
    paddingTop: 40,
  },
  returnButton: {
    width: 300,
  },
  infoText: {
    marginBottom: 10,
  },
  actualInfo: {
    fontWeight: 'bold',
  },
});

export default RequestDetails;