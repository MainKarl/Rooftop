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
const AnalyseCreateForm = (props) => {

    useEffect(() => {
        console.log(props.request);
    }, [props.request]);

    return (
        <View style={styles.container}>
            <Button
                title={'Retourner à la liste de requêtes'}
                onPress={() => props.onChangeMode(false)}></Button>
            <Text>Requête: </Text>
            <ScrollView>
                {

                }
            </ScrollView>
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