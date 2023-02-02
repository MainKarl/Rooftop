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

const PatientFolder = props => {
  return (
    <View style={styles.item}>
      <Text>
        {props.folderkey} - {props.LastName}, {props.FirstName}
      </Text>
      <View
        // eslint-disable-next-line react-native/no-inline-styles
        style={{
          borderColor: '#808080',
          borderBottomWidth: 1,
          paddingLeft: 10,
          paddingRight: 10,
        }}
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

export default PatientFolder;
