import React, { useEffect, useState } from 'react';
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
import AddButton from './AddButton';
import AnalyseConfig from '../analyseConfig.json';

const FolderList = props => {
  const [initialData, setInitialData] = useState([
    { key: '8761', FirstName: 'Victor', LastName: 'Turgeon', active: false },
    { key: '8321', FirstName: 'Louis', LastName: 'Garceau', active: false },
    { key: '1761', FirstName: 'Maxime', LastName: 'Aubin', active: false },
    { key: '6561', FirstName: 'Karl', LastName: 'Mainville', active: false },
    {
      key: '8431',
      FirstName: 'Jean-Philippe',
      LastName: 'Belval',
      active: false,
    },
    { key: '5461', FirstName: 'Laurent', LastName: 'Brochu', active: false },
    { key: '7651', FirstName: 'Maxime', LastName: 'Lefebvre', active: false },
  ]);
  const [filteredData, setfilteredData] = useState();
  const [currentActive, setcurrentActive] = useState(null);


  useEffect(() => {
    console.log("Entered useEffect...");
    const url = AnalyseConfig.API_URL + 'dossier';
    fetch(url)
      .then((response) => {
        if (response.ok) {
          response.json().then((data) => {
            console.log(data);
            setInitialData(data);
            setfilteredData(data);
          });
        }
        else {
          console.log(response);
        }

      }).catch((error) => {
        console.log(error);
      });
  }, []);


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

    // Permet de changer entre detail de folder et création de folder
    props.onChangeState(0);
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

  const callCreateForm = () => {
    props.onChangeState(1);
  }

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
        renderItem={({ item }) => (
          <PatientFolder
            folderkey={item.key}
            FirstName={item.FirstName}
            LastName={item.LastName}
            isActive={item.active}
            changeActiveEvent={changeActiveFolder}
          />
        )} />
      <AddButton style={styles.button} onClick={callCreateForm} />
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
    width: '100%',
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
