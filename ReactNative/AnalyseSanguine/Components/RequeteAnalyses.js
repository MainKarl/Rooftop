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
  ActivityIndicator
} from 'react-native';
import PatientFolder from './PatientFolder';
import CustomButton from './AddButton';
import CheckBox from '@react-native-community/checkbox';

const RequeteAnalyses = props => {

    if(props.analyses.length == 0){
      return(
        <View style={styles.texteErreur}>
        <ActivityIndicator size="large" />
      </View>
      );
    }

    return (
      <View style={styles.flex}>
      {
        props.analyses.map((category) => (
          <View style={styles.flexItem}>
            <Text style={{fontWeight: 'bold', fontSize: 30}}>{category.name}</Text>
            {category.typeAnalyseList.map((type) => (
              <TypeAnalyse typecourant={type} />
            )
            )}
          </View>
          )
        )
      }
      </View>
    );
};

export const TypeAnalyse = props => {

  return (
    <View style={styles.flex}>
      <CheckBox 
        disable={false}
        value={false}
      />
      <Text style={{marginTop:5}}>{props.typecourant.nom}</Text>
    </View>
  )
}

const styles = StyleSheet.create({
  detailsBoxInside: {
    paddingLeft: 15,
    paddingTop: 15,
    paddingBottom: 15
  },
  flex: {
    display:'flex',
    flexDirection: 'row',
    flexWrap:'wrap',
    paddingLeft: 10,
    marginBottom: 5
  },
  flexItem: {
    flex: 0.3
  },
  texteErreur: {
    textAlign: 'center',
    marginTop: 300,
  },

});

export default RequeteAnalyses;