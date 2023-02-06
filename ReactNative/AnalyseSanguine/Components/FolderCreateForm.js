import React, { useState } from 'react';
import {
    View,
    StyleSheet,
    Text,
    TextInput,
    Button,
    Alert
} from 'react-native';
import DatetimePicker from '@react-native-community/datetimepicker';
import CustomRadioButton from './CustomRadioButton';

const FolderCreateForm = props => {
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [sexe, setSexe] = useState(0)
    const [isLiked, setIsLiked] = useState([
        { value: 0, label: 'Homme', selected: false },
        { value: 1, label: 'Femme', selected: false },
        { value: 2, label: 'Autres', selected: false }
    ])
    
    const onFirstNameChange = (newFirstName) => {
        setFirstName(newFirstName);
    }

    const onLastNameChange = (newLastName) => {
        setLastName(newLastName);
    }

    const onSexeChange = (newSexe) => {
        let updatedState = isLiked.map((isLikedItem) =>
            isLikedItem.value === newSexe 
            ? { ...isLikedItem, selected: true }
            : { ...isLikedItem, selected: false }
        );
        setIsLiked(updatedState);
        setSexe(newSexe);
    }

    const onSubmit = () => {
        Alert.alert('Création de dossier de patient', 'Voulez-vous vraiment créer le patient \n' + firstName + ' ' + lastName + ' ?', [
            {
                text: 'Annuler',
                onPress: () => {
                    
                }
            },
            {
                text: 'Confirmer',
                onPress: () => {
                    
                }
            }
        ]);
    }

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Création d'un dossier de patient</Text>
            <View style={styles.formRow}>
                <Text style={styles.formLabel}>Prénom du patient:</Text>
                <TextInput style={styles.formInput} onChangeText={ newName => onFirstNameChange(newName) } />
            </View>
            <View style={styles.formRow}>
                <Text style={styles.formLabel}>Nom du patient:</Text>
                <TextInput style={styles.formInput} onChangeText={ newName => onLastNameChange(newName) } />
            </View>
            <View style={styles.formRow}>
                <Text style={styles.formLabel}>Sexe du patient:</Text>
                <View style={styles.formInput}>
                    {isLiked.map((item) => (
                        <CustomRadioButton
                            onSelect={ () => onSexeChange(item.value) }
                            key={item.value}
                            item={item} />
                    ))}
                </View> 
            </View>
            <View style={styles.formRow}>
                <Text style={styles.formLabel}>Date de naissance du patient:</Text>
                <DatetimePicker mode="date" value={ new Date() } />
            </View>
            <Button title="Créer" onPress={onSubmit}></Button>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 0.8,
        margin: 5,
        borderColor: '#808080',
        borderWidth: 2,
        borderRadius: 5,
        borderStyle: 'solid',
        paddingTop: '2%',
        paddingBottom: '2%',
        paddingLeft: '5%',
        paddingRight: '5%',
    },
    title: {
        fontSize: 50,
        marginBottom: 20,
    },
    formRow: {
        width: '100%',
        minHeight: 40,
        display: 'flex',
        flexWrap: 'wrap',
        flexDirection: 'row',
        marginBottom: '1%',
    },
    formLabel: {
        width: '15%'
    },
    formInput: {
        width: '85%',
    },
    radioButton: {
        marginBottom: '1%'
    }
});

export default FolderCreateForm;