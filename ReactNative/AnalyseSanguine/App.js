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
import RequestDetails from './Components/RequestDetails';
import FolderCreate from './Components/FolderCreateForm';
import {Colors} from 'react-native/Libraries/NewAppScreen';

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
  const [informationState, setInformationState] = useState(0);

  const onChangeInformationState = (informationState) => {
    setInformationState(informationState);
  }

  function updateVisible(request)
  {
    setInformationState(0)
    setselectedRequest(request)
  }

  const onSelectedFolder = selectedFolderId => {
    setselectedFolder(selectedFolderId);
  };
  const isDarkMode = useColorScheme() === 'dark';

  let rightDetail;
  if (informationState === 0) { rightDetail = <FolderDetails onChangeState={onChangeInformationState}  selectedFolder={selectedFolder} />; }
  else if (informationState === 1) { rightDetail = <FolderCreate onChangeState={onChangeInformationState} />; }
  else if (informationState === 2) { rightDetail = <RequestDetails onChangeState={onChangeInformationState} />; }
  return (
    // eslint-disable-next-line no-undef
    <View style={styles.container}>
      <FolderList onChangeState={onChangeInformationState} onSelectedFolder={onSelectedFolder} />
      {rightDetail}
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
