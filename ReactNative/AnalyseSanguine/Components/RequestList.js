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
          title={"(" + String(request.dateEchantillon).replace("T", " ") + ") | " + request.codeAcces + ' | ' + "Médecin: " + request.nomMedecin}
          onPress={() => {
            props.onSelectedRequest(request.idRequete);
            props.onChangeState(2);
          }}></Button>
      ))}
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
});

export default RequestList;
