import React, { useState } from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  FlatList,
  TextInput,
  Touchable,
  TouchableHighlight,
  TouchableOpacity,
  PlatformColor,
} from 'react-native';

const PatientFolder = props => {
  return (
    <TouchableOpacity
      onPress={() => props.changeActiveEvent(props.folderkey)}
      style={props.isActive ? styles.currentItem : styles.item}>
      <Text>
        {props.folderkey} - {props.nom}, {props.prenom}
      </Text>
      <View
        // eslint-disable-next-line react-native/no-inline-styles
        style={{
          borderColor: props.isActive
            ? PlatformColor('SystemAccentColor')
            : '#808080',
          borderBottomWidth: 1,
          paddingLeft: 10,
          paddingRight: 10,
        }}
      />
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  item: {
    paddingTop: 10,
    paddingBottom: 10,
    paddingLeft: 15,
    paddingRight: 15,
  },
  currentItem: {
    paddingTop: 10,
    paddingBottom: 10,
    paddingLeft: 15,
    paddingRight: 15,
    backgroundColor: PlatformColor('SystemAccentColor'),
  },
});

export default PatientFolder;
