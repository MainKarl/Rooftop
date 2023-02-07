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
} from 'react-native';
import PatientFolder from './PatientFolder';
import CustomButton from './AddButton';

const RequestList = props => {

  return (
    <View>
      <Text style={styles.detailsBoxInside}>Requêtes du patient:</Text>
      {props.requests && props.requests.length > 0 && props.requests.map(request => (
        <Button
          title={"Numéro de requête: " + request.codeAcces + ', Date de prélèvement: ' + request.dateEchantillon + ", Médecin: " + request.nomMedecin}
          onPress={() => props.onChangeState(2)}></Button>
      ))}
    </View>
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
