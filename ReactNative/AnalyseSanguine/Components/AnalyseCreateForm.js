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
    Alert,
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
        var newResults = []
        results.forEach(x => {
            if (x.typeValeur.idTypeValeur == id)
                x.valeur = value;
            newResults.push(x);
        });

        setResults(newResults);
    }

    const onSauvegarderResultats = () => {
        Alert.alert('Sauvegarde des resultats', 'Voulez-vous vraiment sauvegarder les résultats?\r\n(Cette action est irréversible)', [
            {
                text: 'Annuler',
                onPress: () => { }
            },
            {
                text: 'Confirmer',
                onPress: () => {
                    sendToAPI();
                }
            }
        ]);
    }

    const sendToAPI = () => {
        const url = AnalyseConfig.API_URL + "requete/addResults";
        var formObj = results;
        const body = JSON.stringify(formObj);

        fetch(url, {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: body,
            cache: 'default'
        }).then((response) => {
            console.log(response);
            if (response.ok) {
                props.changeCanAddResult(false);
                props.onChangeMode(false);
            } else {
                console.log(response);
            }
        }).catch((error) => {
            console.log(error);
        })
    }

    return (
        <View style={styles.container}>
            <View style={styles.returnButton}>
                <Button
                    title={'Retourner à la liste de requêtes'}
                    onPress={() => props.onChangeMode(false)}></Button>
            </View>
            <ScrollView style={styles.scroll}>
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
            <View style={styles.returnButton}>
                <Button
                    title={'Sauvegarder les résultats'}
                    onPress={() => onSauvegarderResultats()}></Button>
            </View>

        </View >
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        paddingTop: 12,
        margin: 5,
        display: 'flex',
        flexDirection: 'column',
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
    returnButton: {
        width: 300,
        marginLeft: 32,
        marginTop: 10,
        marginBottom: 10,
    },
    scroll: {
        borderColor: '#808080',
        borderTopWidth: 2,
        borderTopRadius: 5,
        borderTopStyle: 'solid',
    }
})

export default AnalyseCreateForm;