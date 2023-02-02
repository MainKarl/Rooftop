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
import CustomButton from './Button';

const FolderList = () => {
  const [patientFolders, setpatientFolders] = useState([
    {key: '8761', FirstName: 'Victor', LastName: 'Turgeon', active: false},
    {key: '8321', FirstName: 'Louis', LastName: 'Garceau', active: false},
    {key: '1761', FirstName: 'Maxime', LastName: 'Aubin', active: false},
    {key: '6561', FirstName: 'Karl', LastName: 'Mainville', active: false},
    {
      key: '8431',
      FirstName: 'Jean-Philippe',
      LastName: 'Belval',
      active: false,
    },
    {key: '5461', FirstName: 'Laurent', LastName: 'Brochu', active: false},
    {key: '7651', FirstName: 'Maxime', LastName: 'Lefebvre', active: false},
  ]);

  const changeActiveFolder = activeFolderId => {
    const part_patientFolders = patientFolders.map((v, i) => {
      if (v.key === activeFolderId) {
        v.active = true;
        return v;
      } else {
        v.active = false;
        return v;
      }
    });
    setpatientFolders(part_patientFolders);
  };

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
            isActive={item.active}
            changeActiveEvent={changeActiveFolder}
          />
        )}
      />
      <CustomButton />
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
