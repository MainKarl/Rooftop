import React, {useState} from 'react';
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

const FolderList = props => {
  const initialData = [
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
    {key: '3422', FirstName: 'Kevin', LastName: 'Gauvin', active: false},
    {key: '1268', FirstName: 'Raphaël', LastName: 'Seyer', active: false},
    {key: '8963', FirstName: 'Samuel', LastName: 'Guérin', active: false},
    {key: '0942', FirstName: 'Justin', LastName: 'Leblanc', active: false},
    {key: '2479', FirstName: 'Loïc', LastName: 'Brunet', active: false},
    {key: '4768', FirstName: 'Marie Claire', LastName: 'Uwambajimana', active: false},
    {key: '2368', FirstName: 'Mercedes', LastName: 'Siandja Nana', active: false},
    {key: '3421', FirstName: 'Simon', LastName: 'Dénommé', active: false},
    {key: '7677', FirstName: 'Tristan', LastName: 'Bousquet', active: false},
    {key: '8989', FirstName: 'Zachary', LastName: 'Cloutier-Cyr', active: false},
    {key: '6532', FirstName: 'Nicolas', LastName: 'St-Arnault', active: false},
    {key: '7022', FirstName: 'Stéphane', LastName: 'Denis', active: false},
    {key: '2003', FirstName: 'Martin', LastName: 'Beauregard', active: false},
  ];

  const [filteredData, setfilteredData] = useState(initialData);
  const [currentActive, setcurrentActive] = useState(null);

  const changeActiveFolder = activeFolderId => {
    const part_filteredFolder = filteredData.map((v, i) => {
      if (v.key === activeFolderId) {
        v.active = true;
        return v;
      } else {
        v.active = false;
        return v;
      }
    });
    props.onSelectedFolder(activeFolderId);
    setcurrentActive(activeFolderId);
    setfilteredData(part_filteredFolder);
  };

  const filterFolders = searchTerm => {
    searchTerm = searchTerm.toLowerCase().trim();
    const newFilteredFolders = initialData
      .filter(
        v =>
          v.key.toLowerCase().includes(searchTerm) ||
          v.FirstName.toLowerCase().includes(searchTerm) ||
          v.LastName.toLowerCase().includes(searchTerm) ||
          (v.FirstName + ' ' + v.LastName).toLowerCase().includes(searchTerm) ||
          (v.LastName + ' ' + v.FirstName).toLowerCase().includes(searchTerm),
      )
      .map(v => {
        if (v.key == currentActive) {
          v.active = true;
          return v;
        } else {
          v.active = false;
          return v;
        }
      });

    setfilteredData(newFilteredFolders);
  };

  return (
    <View style={styles.searchFolderList}>
      <TextInput
        onChangeText={searchTerm => filterFolders(searchTerm)}
        style={styles.searchBarInput}
        placeholder="Rechercher"
      />
      <FlatList
        data={filteredData}
        extraData={filteredData}
        style={styles.listStyle}
        renderItem={({item}) => (
          <PatientFolder
            folderkey={item.key}
            FirstName={item.FirstName}
            LastName={item.LastName}
            isActive={item.active}
            changeActiveEvent={changeActiveFolder}
          />
        )}  />
        <CustomButton style={styles.button} />
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
    position: 'relative'
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
  listStyle: {
    width:'100%',
    height: '100%',
    marginBottom: 0,
    marginTop: 30,
    position: 'absolute'
  },
  searchBarInput: {
    width: '100%'
  },
  button: { position: 'absolute' }
});

export default FolderList;
