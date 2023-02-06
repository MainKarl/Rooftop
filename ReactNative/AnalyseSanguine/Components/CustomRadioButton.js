import React from 'react';
import {
    View,
    StyleSheet,
    Text,
    TextInput,
    Button,
    Alert,
    Pressable,
    PlatformColor
} from 'react-native';

const customRadioButton = ({ onSelect, item }) => {
    return (
        <View style={styles.container}>
            <Pressable onPress={ () => {onSelect(item.value)}} style={styles.radioButton}>
                { item.selected ? <View key={item.value} style={styles.radioButtonIcon} /> : null }
            </Pressable>
            <Pressable onPress={() => {onSelect(item.value);}}>
                <Text style={styles.item} key={item.value}>{item.label}</Text>
            </Pressable>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flexDirection: 'row',
        alignItems: 'center'
    },
    item: {      
        marginBottom: 10,
        marginLeft: 10,
    },
    radioButton: {
        height: 20,
        width: 20,
        backgroundColor: '#F8F8F8',
        borderRadius: 10,
        borderWidth: 1,
        borderColor: 'E6E6E6',
        alignItems: 'center',
        justifyContent: 'center'
    },
    radioButtonIcon: {
        height: 14,
        width: 14,
        borderRadius: 7,
        backgroundColor: PlatformColor('SystemAccentColor'),
    },
});

export default customRadioButton;
