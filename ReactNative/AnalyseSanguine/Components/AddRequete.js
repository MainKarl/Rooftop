import React, {useState} from 'react';
import {
  StyleSheet,
  TextInput,
  View,
  Text,
  Button
} from 'react-native';
import CheckBox from '@react-native-community/checkbox';

const ModalAddRequete = props => {
  const CheckboxData = [
    
  ]
  let isSelected;

  return(
  <View>
    <Text style={{fontSize:50, fontWeight:'bold'}}>Créer une requête</Text>
    <View style={styles.Form}>
      <TextInput placeholder='Nom du technicien'/>
      <View style={{paddingTop:40}}>
        <Text style={{fontWeight: "bold", fontSize:30}}>Biochimie</Text>
        <View style={styles.Biologie}>
          <View style = {{flex:0.1}}>
            <CheckBox
            disabled={false}
            value={isSelected}
            onValueChange={(newValue) => isSelected}
            />
          </View>
          <View style={styles.Label}>
            <Text>ACURI</Text>
          </View>
        </View>
      </View>
      <Button
        title='cancel'
        onPress={() => props.updateformAddRequeteVisible()}
        />
    </View>
  </View>
  );
};

const styles = StyleSheet.create({
  Form: {
    height: '100%',
    width: 500,
    marginTop: 30,
    marginLeft: 50
  },
  Biologie: {
    display: 'flex',
    flexDirection: 'row',
  },
  Label:{
    flex: 0.9,
    marginTop: 5
  }
});

export default ModalAddRequete;