import React, {useState} from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  FlatList,
  TextInput,
  Touchable,
  useColorScheme,
  PlatformColor,
} from 'react-native';
import FolderList from './Components/FolderList';
import FolderDetails from './Components/FolderDetails';
import {Colors} from 'react-native/Libraries/NewAppScreen';

const App = () => {
  const [count, setCount] = useState(0);
  const [selectedFolder, setselectedFolder] = useState('');

  const onSelectedFolder = selectedFolderId => {
    setselectedFolder(selectedFolderId);
  };
  const isDarkMode = useColorScheme() === 'dark';
  return (
    // eslint-disable-next-line no-undef
    <View style={styles.container}>
      <FolderList onSelectedFolder={onSelectedFolder} />
      <FolderDetails selectedFolder={selectedFolder} />
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

export default App;
