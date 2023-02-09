import React from 'react';
import Icon from "react-native-vector-icons/Ionicons";
import {
    View,
    Button,
    StyleSheet,
    TouchableOpacity,
    Text,
} from 'react-native';
 
const App = props => {
    return (
        <TouchableOpacity style={styles.container} onPress={props.onClick}>
            <Text style={styles.button}>+</Text>
        </TouchableOpacity>
    );
};

const styles = StyleSheet.create({
    container: {
        marginLeft: 'auto',
        marginTop: 'auto',
        margin: 15,
        backgroundColor: 'rgb(119, 186, 153)',
        borderRadius: 150,
        height: 35,
        aspectRatio:1/1,
    },
    button: {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        fontWeight: 'bold',
        fontSize: 22,
        textAlign: 'center',
    }
});

export default App;


