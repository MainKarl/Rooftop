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
import RequestDetails from './Components/RequestDetails';

const App = () => {
  const [count, setCount] = useState(0);
  const [selectedFolder, setselectedFolder] = useState('');
  const [selectedRequest, setselectedRequest] = useState({key: '',
  FirstNameTechnician: '',
  LastNameTechnician: '',
  AccessCode: '',
  SamplingDate: '',
  FirstNameDoctor: '',
  LastNameDoctor: '',});
  const [elementVisible, setElementVisible] = useState(true);

  function updateVisible(request)
  {
    setElementVisible(!elementVisible)
    setselectedRequest(request)
  }

  const onSelectedFolder = selectedFolderId => {
    setselectedFolder(selectedFolderId);
  };
  const isDarkMode = useColorScheme() === 'dark';
  return (
    // eslint-disable-next-line no-undef
    <View>
      <View>
        {elementVisible ? (
          <View style={styles.container}>
            <FolderList onSelectedFolder={onSelectedFolder} />
            <FolderDetails selectedFolder={selectedFolder} updateVisible={updateVisible} />
          </View>
        ) : null}
      </View>
      <View style={styles.container}>
        {elementVisible ? null : (
          <View>
            <RequestDetails updateVisible={updateVisible} selectedRequest={selectedRequest} />
          </View>
        )}
      </View>
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
