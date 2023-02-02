import React from 'react';
import Icon from "react-native-vector-icons/Ionicons";
import {
    View,
    Button,
    StyleSheet,
    TouchableOpacity,
    Text,
} from 'react-native';
 
const App = () => {
    return (
        <TouchableOpacity style={styles.container}>
            <Icon name="add" color="white" size={36} style={styles.customIcon} />
        </TouchableOpacity>
    );
};

const styles = StyleSheet.create({
    container: {
        marginLeft: 'auto',
        margin: 15,
        height:35,
        aspectRatio:1/1,
        backgroundColor: 'rgb(119, 186, 153)',
        borderRadius: 150,
        display: 'flex'
    },
    customIcon: {
        marginLeft: 1,
        marginRight: 0,
        marginTop: 0,
        border: 0
    }
});

export default App;


