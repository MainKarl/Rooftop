import React, { useState, useEffect } from 'react';
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
  PlatformColor
} from 'react-native';
import AnalyseConfig from "../analyseConfig.json";
import { Table, TableWrapper, Row, Rows, Col, Cols, Cell } from 'react-native-table-component';
import AnalyseCreateForm from './AnalyseCreateForm';

const RequestDetails = props => {

  const [request, setRequest] = useState(null);
  const [resultsExist, setResultsExist] = useState(true);
  const [resultMode, setResultMode] = useState(false);
  const [testData, setTestData] = useState([]);
  const [tableHead, setTableHead] = useState(['Type de valeur', 'Valeur', 'Référence']);
  const [tableData, setTableData] = useState();
  const [arrayTestReal, setArrayTestReal] = useState();
  const [canAddResult, setCanAddResult] = useState(false);

  const onChangeMode = (mode) => {
    setResultMode(mode);
  }

  const loadResults = () => {
    let differentTests = 0
    let arrayFinal = [];
    let arrayTest = [];
    request.lstTypeAnalyse.map((analyse) => {
      arrayTest.push(analyse.idTypeAnalyse)
    })
    setArrayTestReal(arrayTest)
    // arrayTest.map((type) => {
    //   let result = request.lstResultats.filter(resultat => resultat.typeValeur.typeAnalyseId == type)
    //   arrayFinal.push([type, result])
    // })
    // console.log("ARRAY FINAL")
    // console.log(arrayFinal)
    // setTableData(arrayFinal)
    // //setTableData(arrayTest)
  }

  const setValues = (data) => {

    setRequest(data)    
    console.log("DATA")
    console.log(data)

        const url = AnalyseConfig.API_URL + 'typeanalyse/categories';
        fetch(url)
            .then(response => {
                if (response.ok) {
                    response.json().then(dataresult => {
                        console.log(dataresult);
                        var filteredCategories = [];
                        var neededCategoryIds = [];
                        var neededTypeIds = [];

                        dataresult.lstTypeAnalyse.forEach(ta => {
                            if (!neededCategoryIds.includes(ta.categoryId))
                                neededCategoryIds.push(ta.categoryId);
                            if (!neededTypeIds.includes(ta.idTypeAnalyse))
                                neededTypeIds.push(ta.idTypeAnalyse);
                        })

                        dataresult.forEach(c => {
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





    // setRequest(data)
    // let arrayTest = [];
    // let arrayFinal = [];
    // data.lstTypeAnalyse.map((analyse) => {
    //   arrayTest.push(analyse.nom)
    // })
    // console.log("RESULTS")
    // console.log(data.lstResultats)
    // arrayTest.map((type) => {
    //   let result = []
    //   if (data.lstResultats) {
    //     setResultsExist(true)
    //     result = data.lstResultats.filter(resultat => resultat.typeValeur.nom == type)
    //   }
    //   console.log("ARRAY TEST")
    //   console.log(arrayTest)
    //   let arrayResults = []
    //   result.map((result) => {
    //     arrayResults.push([result.typeValeur.nom, result.valeur, result.typeValeur.reference])
    //   })
    //   arrayFinal.push([type, arrayResults])
    // })
    // console.log("WILL IT WORK?")
    // console.log(arrayFinal)
    // setTestData(arrayFinal)
    //console.log("ARRAY FINAL WORKED")
  }

  const [results, setResults] = useState([]);
  const [categories, setCategories] = useState([]);

  useEffect(() => {

    if (props.selectedRequest != "") {
      const url = AnalyseConfig.API_URL + 'requete/' + props.selectedRequest;
      fetch(url)
        .then((response) => {
          if (response.ok) {
            response.json().then((data) => {
              if (!data.lstResultats || data.lstResultats.length <= 0)
                setCanAddResult(true);
              setValues(data)
            });
          }
          else {
            console.log(response);
          }

        }).catch((error) => {
          console.log(error);
        });
    }
  }, [props.selectedRequest]);

  const printRequest = () => {
    console.log(request)
  }

  console.log("CATEGORIES")
  console.log(categories)

  return (
    <View style={{ flex: 1 }}>
      {!resultMode && <View style={styles.container}>
        <View style={styles.detailsPadding}>
          <View style={styles.returnButton}>
            <Button
              title={'Retourner à la liste de requêtes'}
              onPress={() => props.onChangeState(0)}></Button>
          </View>
          {request && (
            <View style={styles.detailsBox}>
              <View style={styles.detailsBoxInside}>
                <View style={styles.displayFlex}>
                  <View>
                    <Text style={styles.infoText}>
                      Code d'accès:{' '}
                      <Text style={styles.actualInfo}>{request.codeAcces}</Text>
                    </Text>
                    <Text style={styles.infoText}>
                      Date de prélèvement:{' '}
                      <Text style={styles.actualInfo}>{String(request.dateEchantillon).split("T")[0]}</Text>
                    </Text>
                    <Text style={styles.infoText}>
                      Heure de prélèvement:{' '}
                      <Text style={styles.actualInfo}>{String(request.dateEchantillon).split("T")[1].replace("T", "")}</Text>
                    </Text>
                  </View>
                  <View style={styles.infoLeft}>
                    <Text style={styles.infoText}>
                      Nom du médecin:{' '}
                      <Text style={styles.actualInfo}>{request.medecin.prenom + " " + request.medecin.nom}</Text>
                    </Text>
                    <Text style={styles.infoText}>
                      Nom du technicien:{' '}
                      <Text style={styles.actualInfo}>{request.nomTechnicien}</Text>
                    </Text>
                    <View style={styles.printButton}>
                      <Button
                        title={'Imprimer la requête'}
                        onPress={() => printRequest()}></Button>
                    </View>
                  </View>
                </View>
                {resultsExist ? (

                  <ScrollView style={{
                    // borderColor: '#808080',
                    // borderWidth: 2,
                    // borderRadius: 5,
                    // borderStyle: 'solid',
                    height: '80%',
                    marginRight: '5%'
                  }}>
                    {
                      categories && categories.length > 0 &&
                      categories.map((cat) => (
                        <View style={styles.category}>
                          <Text style={styles.categoryTitle}>{cat.name}</Text>
                          {
                            cat.typeAnalyseList.map((t) => (
                              <View style={styles.type} >
                                <Text style={styles.typeTitle}>{t.nom}</Text>
                                {
                                  request && request.lstResultats && request.lstResultats.length > 0 &&
                                  request.lstResultats.map((r) => (
                                    r.typeValeur.typeAnalyseId == t.idTypeAnalyse &&
                                    <Text>{r.valeur}</Text>
                                  ))
                                }
                              </View>
                            ))
                          }
                        </View>
                      ))
                    }
                  </ScrollView >
                ) : <Text style={styles.noDataText}>Il n'y a pas de résultats pour cette analyse</Text>}

              </View>
            </View>

          )}
          {
            canAddResult &&
            <View style={{ marginTop: 12 }}>
              <Button
                title={'Entrer les résultats'}
                onPress={() => onChangeMode(true)} />
            </View>
          }

        </View>
      </View>}
      {resultMode && canAddResult && <AnalyseCreateForm changeCanAddResult={setCanAddResult} onChangeMode={onChangeMode} request={request} />}
    </View>
  );
};

const styles = StyleSheet.create({
  head: { height: 40 },
  text: { margin: 6, color: '#808080' },
  container: {
    flex: 1,
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
  detailsPadding: {
  },
  infoLeft: {
    marginLeft: 150
  },
  displayFlex: {
    display: 'flex',
    flexDirection: 'row'
  },
  detailsBox: {
    borderColor: '#808080',
    borderWidth: 2,
    borderRadius: 5,
    borderStyle: 'solid',
    marginTop: 20,
    width: '100%',
    height: '85%',
  },
  detailsBoxInside: {
    paddingLeft: 40,
    paddingTop: 40,
    display: 'flex'
  },
  returnButton: {
    width: 300,
  },
  infoText: {
    marginBottom: 10,
  },
  actualInfo: {
    fontWeight: 'bold',
  },
  printButton: {
    width: 250
  },
  customIcon: {
    marginLeft: 1,
    marginRight: 0,
    marginTop: 0
  },
  tableStyle: {
    marginTop: 30,
    marginRight: '5%'
  },
  tableTitle: {
    marginBottom: 10,
    marginLeft: 10,
    fontSize: 15
  },
  noDataText: {
    marginBottom: 10,
    marginLeft: 10,
    marginTop: '8%',
    fontSize: 30,
    textAlign: 'center'
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
    flexDirection: 'column'
},
typeTitle: {
    fontWeight: "bold",
    display: 'flex'
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
});

export default RequestDetails;