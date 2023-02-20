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
          <View style={{marginBottom: 45}}>
            <View style={{marginBottom:15}}>
            <Text style={{fontWeight: 'bold', fontSize: 30,}}>{category.name}</Text>
            <View
              // eslint-disable-next-line react-native/no-inline-styles
              style={{
                borderColor: '#808080',
                borderBottomWidth: 1,
                paddingLeft: 10,
                paddingRight: 20,
              }}
            />
            </View>
          <View style={styles.flexd}>
            {category.typeAnalyseList.map((type) => (

              <TypeAnalyse typecourant={type} selectedAnalyses={props.selectedAnalyses} setselectedAnalyses={props.setselectedAnalyses} />

            )
            )}
                </View>
          </View>
          )
        )
      }
      </View>
    );
};

export const TypeAnalyse = props => {

  function updateSelectedAnalyses(){
    console.log("In");
    props.setselectedAnalyses([...props.selectedAnalyses, props.typecourant.idTypeAnalyse]);
    console.log(props.selectedAnalyses);
  }

  return (

    <View style={styles.flex2}>
      <View style={styles.innerFlex}>
        <CheckBox 
          disable={false}
          value={false}
          onValueChange={updateSelectedAnalyses}
        />
        <Text style={{marginTop:5}}>{props.typecourant.nom}</Text>
      </View>
    </View>

  )
}

const styles = StyleSheet.create({
  detailsBoxInside: {
    paddingLeft: 15,
    paddingTop: 15,
    paddingBottom: 15
  },
  flexd: {
    display: 'flex',
    flexDirection: 'row',
    flexWrap: 'wrap',
  },
  flex2: {
    width: '25%'
  },
  flex4: {
    width: '76%'
  },  
  flex: {
    display:'flex',
    flexDirection: 'column',
    flexWrap:'wrap',
    marginLeft: 20
  },
  flexItem: {
    display:'flex',
    flexDirection: 'row',
    flexWrap: 'wrap'
  },
  texteErreur: {
    textAlign: 'center',
    marginTop: 300,
  },
  innerFlex: {
    display: 'flex',
    flexDirection: 'row',
  }

});

export default RequeteAnalyses;