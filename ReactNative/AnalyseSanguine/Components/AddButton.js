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
            <Icon name="add" color="white" size={36} style={styles.customIcon} />
        </TouchableOpacity>
    );
};

const styles = StyleSheet.create({
    container: {
        marginLeft: 'auto',
        marginTop: 'auto',
        margin: 15,
        height: 35,
        aspectRatio:1/1,
        backgroundColor: 'rgb(119, 186, 153)',
        borderRadius: 150,
    },
    customIcon: {
        marginLeft: 1,
        marginRight: 0,
        marginTop: 0
    }
});

export default App;


