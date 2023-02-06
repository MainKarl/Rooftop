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
import Icon from "react-native-vector-icons/Ionicons";

const RequestDetails = props => {
  return (
    <View style={styles.container}>
      <View style={styles.detailsPadding}>
        <View style={styles.returnButton}>
          <Button
            title={'Retourner à la liste de requêtes'}
            onPress={() => props.onChangeState(0)}></Button>
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
              <Text style={styles.actualInfo}>{props.selectedRequest.LastNameDoctor + ", " + props.selectedRequest.FirstNameDoctor}</Text>
            </Text>
            <Text style={styles.infoText}>
              Nom du technicien:{' '}
              <Text style={styles.actualInfo}>{props.selectedRequest.LastNameTechnician + ", " + props.selectedRequest.FirstNameTechnician}</Text>
            </Text>
            <View style={styles.printButton}>
              <Button
                title={'Imprimer la requête'}
                onPress={() => props.onChangeState(0)}></Button>
                {/* <Icon name="print" color="black" size={20} style={styles.customIcon}></Icon> */}
            </View>
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
    paddingTop: 60,
  },
  detailsBox: {
    borderColor: '#808080',
    borderWidth: 2,
    borderRadius: 5,
    borderStyle: 'solid',
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
  printButton: {
    width: 250
  },
  customIcon: {
    marginLeft: 1,
    marginRight: 0,
    marginTop: 0
}
});

export default RequestDetails;