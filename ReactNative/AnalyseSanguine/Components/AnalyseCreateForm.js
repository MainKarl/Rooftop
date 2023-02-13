import React from "react";
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
} from "react-native";
const AnalyseCreateForm = (props) => {

    return (
        <View style={styles.container}>
            <Button
                title={'Retourner à la liste de requêtes'}
                onPress={() => props.onChangeState(2)}></Button>
            <Text>Requête: {props.selectedRequest}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        margin: 5,
        borderColor: '#808080',
        borderWidth: 2,
        borderRadius: 5,
        borderStyle: 'solid',
    },
})

export default AnalyseCreateForm;