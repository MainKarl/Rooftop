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
  Alert,
  BackHandler
} from 'react-native';
import PatientFolder from './PatientFolder';
import AddButton from './AddButton';
import AnalyseConfig from '../analyseConfig.json';
import AlertConnectionFailed from './AlertConnectionFailed';

const FolderList = props => {
  const [initialData, setInitialData] = useState([]);
  const [filteredData, setfilteredData] = useState();
  const [currentActive, setcurrentActive] = useState(null);

  const fetchDossiersSimples = () => {
    const url = AnalyseConfig.API_URL + 'dossier/getsimple';
    props.setIsLoading(true);
    fetch(url)
      .then((response) => {
        if (response.ok) {
          response.json().then((data) => {
            data.map((x) => {
              x.active = false;
            });
            setInitialData(data);
            setfilteredData(data);
            props.setIsLoading(false);
          });
        }
        else {
          AlertConnectionFailed(fetchDossiersSimples);
        }
      }).catch((error) => {
        AlertConnectionFailed(fetchDossiersSimples);
      });
  }

  useEffect(() => {
    fetchDossiersSimples();
  }, [props.actualState]);


  const changeActiveFolder = activeFolderId => {
    if (props.actualState !== 0) {
      Alert.alert('Quitter la page', 'Est-ce que vous êtes sur de changer de page?', [
        {
          text: 'Annuler'
        },
        {
          text: 'Confirmer',
          onPress: () => {
            const part_filteredFolder = filteredData.map((v, i) => {
              if (v.idDossier === activeFolderId) {
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
          }
        }
      ]);
    }
    else {
      const part_filteredFolder = filteredData.map((v, i) => {
        if (v.idDossier === activeFolderId) {
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
    }
  };

  const filterFolders = searchTerm => {
    searchTerm = searchTerm.toLowerCase().trim();
    const newFilteredFolders = initialData
      .filter(
        v =>
          String(v.idDossier).toLowerCase().includes(searchTerm) ||
          v.prenom.toLowerCase().includes(searchTerm) ||
          v.nom.toLowerCase().includes(searchTerm) ||
          (v.prenom + ' ' + v.nom).toLowerCase().includes(searchTerm) ||
          (v.nom + ' ' + v.prenom).toLowerCase().includes(searchTerm),
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
    props.changeEditingMode(false)
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
            key={item.idDossier}
            folderkey={item.idDossier}
            prenom={item.prenom}
            nom={item.nom}
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
