import React, {useState} from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  FlatList,
  TextInput,
  Touchable,
} from 'react-native';
import PatientFolder from './PatientFolder';

const FolderList = () => {
  const [patientFolders, setpatientFolders] = useState([
    {key: '8761', FirstName: 'Victor', LastName: 'Turgeon'},
    {key: '8321', FirstName: 'Louis', LastName: 'Garceau'},
    {key: '1761', FirstName: 'Maxime', LastName: 'Aubin'},
    {key: '6561', FirstName: 'Karl', LastName: 'Mainville'},
    {key: '8431', FirstName: 'Jean-Philippe', LastName: 'Belval'},
    {key: '5461', FirstName: 'Laurent', LastName: 'Brochu'},
    {key: '7651', FirstName: 'Maxime', LastName: 'Lefebvre'},
  ]);

  return (
    <View style={styles.searchFolderList}>
      <TextInput style={styles.searchBarInput} placeholder="Rechercher" />
      <FlatList
        data={patientFolders}
        renderItem={({item}) => (
          <PatientFolder
            folderkey={item.key}
            FirstName={item.FirstName}
            LastName={item.LastName}
          />
        )}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    display: 'flex',
    flexDirection: 'row',
    height: '100%',
  },
  searchFolderList: {
    borderColor: '#808080',
    borderWidth: 2,
    borderRadius: 5,
    borderStyle: 'solid',
    flex: 0.2,
    margin: 5,
  },
  textCounter: {
    padding: 5,
  },
  item: {
    paddingTop: 10,
    paddingBottom: 10,
    paddingLeft: 15,
    paddingRight: 15,
  },
  searchBarInput: {},
});

export default FolderList;
