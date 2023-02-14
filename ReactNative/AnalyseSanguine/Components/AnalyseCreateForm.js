import React from "react";
import { useEffect, useState } from "react";
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
import AnalyseCreateField from "./AnalyseCreateField";
import AnalyseConfig from "../analyseConfig.json";

const AnalyseCreateForm = (props) => {

    const [results, setResults] = useState([]);
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        var lstResults = [];

        props.request.lstTypeAnalyse.forEach(typeAnalyse => {
            typeAnalyse.lstValeurs.forEach(x => {
                lstResults.push({
                    valeur: "",
                    typeValeur: x,
                    idRequete: props.request.idRequete,
                });
            });
        });

        setResults(lstResults);

        const url = AnalyseConfig.API_URL + 'typeanalyse/categories';
        fetch(url)
            .then(response => {
                if (response.ok) {
                    response.json().then(data => {
                        console.log(data);
                        var filteredCategories = [];
                        var neededCategoryIds = [];
                        var neededTypeIds = [];

                        props.request.lstTypeAnalyse.forEach(ta => {
                            if (!neededCategoryIds.includes(ta.categoryId))
                                neededCategoryIds.push(ta.categoryId);
                            if (!neededTypeIds.includes(ta.idTypeAnalyse))
                                neededTypeIds.push(ta.idTypeAnalyse);
                        })

                        data.forEach(c => {
                            if (neededCategoryIds.includes(c.id)) {
                                var filteredType = [];
                                c.typeAnalyseList.forEach(t => {
                                    if (neededTypeIds.includes(t.idTypeAnalyse))
                                        filteredType.push(t);
                                });

                                c.typeAnalyseList = filteredType;
                                filteredCategories.push(c);
                            }
                        });

                        setCategories(filteredCategories);
                    });
                } else {
                    console.log(response);
                }
            })
            .catch(error => {
                console.log(error);
            });

    }, [props.request]);

    const onChangeResultValue = (id, value) => {
    }

    return (
        <View style={styles.container}>
            <Button
                title={'Retourner à la liste de requêtes'}
                onPress={() => props.onChangeMode(false)}></Button>
            <ScrollView>
                {
                    categories && categories.length > 0 &&
                    categories.map((cat) => (
                        <View style={styles.category}>
                            <Text style={styles.categoryTitle}>{cat.name}</Text>
                            {
                                cat.typeAnalyseList.map((t) => (
                                    < View style={styles.type} >
                                        <Text style={styles.typeTitle}>{t.nom}</Text>
                                        {
                                            results && results.length > 0 &&
                                            results.map((r) => (
                                                r.typeValeur.typeAnalyseId == t.idTypeAnalyse &&
                                                <AnalyseCreateField onChangeResultValue={onChangeResultValue} result={r} />
                                            ))
                                        }
                                    </View>

                                ))
                            }
                        </View>
                    ))
                }
            </ScrollView >
        </View >
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
    category: {
        margin: 5,
        padding: 12,
        borderColor: '#808080',
        borderWidth: 2,
        borderRadius: 5,
        borderStyle: 'solid',
    },
    categoryTitle: {
        fontWeight: "bold",
        fontSize: 20

    },
    type: {
        margin: 5,
        padding: 12,
        borderRadius: 5,
    },
    typeTitle: {
        fontWeight: "bold",
    },
    result: {

    }
})

export default AnalyseCreateForm;