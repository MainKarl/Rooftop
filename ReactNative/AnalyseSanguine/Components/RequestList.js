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

const RequestList = props => {
  const initialData = [
    {key: '5346',
    FirstNameTechnician: 'Raymond',
    LastNameTechnician: 'Dupré',
    AccessCode: 'ASFH3ASGH65ASFHHDJ',
    SamplingDate: '2020-02-02',
    FirstNameDoctor: 'José',
    LastNameDoctor: 'Laplante',},
    {key: '1245',
    FirstNameTechnician: 'Raymond',
    LastNameTechnician: 'Dupré',
    AccessCode: 'ASFH3ASGH65ASFHHDJ',
    SamplingDate: '2015-02-02',
    FirstNameDoctor: 'José',
    LastNameDoctor: 'Laplante',},
    {key: '3257',
    FirstNameTechnician: 'Raymond',
    LastNameTechnician: 'Dupré',
    AccessCode: 'ASFH3ASGH65ASFHHDJ',
    SamplingDate: '2004-02-02',
    FirstNameDoctor: 'José',
    LastNameDoctor: 'Laplante',},
    {key: '5676',
    FirstNameTechnician: 'Raymond',
    LastNameTechnician: 'Dupré',
    AccessCode: 'ASFH3ASGH65ASFHHDJ',
    SamplingDate: '2012-02-02',
    FirstNameDoctor: 'José',
    LastNameDoctor: 'Laplante',},
  ];

  return (
    <View>
        {initialData.map(request => (
            <Button
            title={request.key + ', ' + request.SamplingDate}
            onPress={() => props.updateVisible(request)}></Button>
        ))}
    </View>
  );
};

const styles = StyleSheet.create({
  
});

export default RequestList;
