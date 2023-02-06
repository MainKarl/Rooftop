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
import AnalyseConfig from '../analyseConfig.json';

const RequestList = props => {
  const [initialData, setInitialData] = useState(null);

  useEffect(() => {
    const url = AnalyseConfig.API_URL + "";
  }, [props.selectedFolder])

  return (
    <View>
      <Text style={styles.detailsBoxInside}>Requêtes du patient:</Text>
      {initialData && initialData.length > 0 && initialData.map(request => (
        <Button
          title={"Numéro de requête: " + request.key + ', Date de prélèvement: ' + request.SamplingDate + ", Médecin: " + request.LastNameDoctor + ", " + request.FirstNameDoctor}
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
