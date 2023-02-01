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
import FolderList from './Components/FolderList';

const App = () => {
  const [count, setCount] = useState(0);

  return (
    // eslint-disable-next-line no-undef
    <View style={styles.container}>
      <FolderList />
      <View style={{flex: 0.8, margin: 5}}>
        <Text style={styles.textCounter}>You clicked {count} times</Text>
        <Button onPress={() => setCount(count + 1)} title="Click me!" />
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
