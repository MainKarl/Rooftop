import React, { useState, useEffect } from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  FlatList,
  TextInput,
  Touchable,
  InteractionManager,
  PlatformColor,
  ScrollView,
} from 'react-native';
import PatientFolder from './PatientFolder';
import CustomButton from './AddButton';

const RequestList = props => {

  return (
    <>
    <Text style={styles.detailsBoxInside}>Requêtes du patient:</Text>
    <ScrollView>
      {props.requests && props.requests.length > 0 && props.requests.map(request => (
        <Button
          title={"(" + String(request.dateEchantillon).replace("T", " ").slice(0, String(request.dateEchantillon).lastIndexOf(':')) + ") | " + request.codeAcces + ' | ' + "Médecin: " + request.nomMedecin}
          onPress={() => {
            props.onSelectedRequest(request.idRequete);
            props.onChangeState(2);
          }}></Button>
      ))}
      {props.requests && props.requests.length < 1 && (
        <View>
          <Text style={styles.noDataText}>Ce dossier ne contient aucune requête</Text>
        </View>
      )}
    </ScrollView>
    </>
  );
};

const styles = StyleSheet.create({
  detailsBoxInside: {
    paddingLeft: 15,
    paddingTop: 15,
    paddingBottom: 15
  },
  noDataText: {
    marginBottom: 10,
    marginLeft: 10,
    marginTop: '8%',
    fontSize: 30,
    textAlign: 'center'
  },
});

export default RequestList;
