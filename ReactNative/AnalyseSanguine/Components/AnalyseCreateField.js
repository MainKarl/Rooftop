import React from "react";
import { useEffect } from "react";
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
    ScrollView,
} from "react-native";

const AnalyseCreateField = (props) => {
    return (
        <View style={styles.container}>
            <Text style={styles.label}>
                {props.result.typeValeur.nom}:
            </Text>
            <TextInput style={styles.input} onChangeText={value => props.onChangeResultValue(props.result.typeValeur.idTypeValeur, value)} />

        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        display: "flex",
        flexDirection: "row",
    },
    label: {
        flex: 0.1,
    },
    input: {
        flex: 0.3,
    }
})

export default AnalyseCreateField;