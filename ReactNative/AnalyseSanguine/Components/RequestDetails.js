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
  const [resultsExist, setResultsExist] = useState(false);
  const [resultMode, setResultMode] = useState(false);
  const [testData, setTestData] = useState([]);
  const [tableHead, setTableHead] = useState(['Type de valeur', 'Valeur', 'Référence']);
  const [tableData, setTableData] = useState();
  const [arrayTestReal, setArrayTestReal] = useState();
  const [canAddResult, setCanAddResult] = useState(false);
  const [noAnalyse, setNoAnalyse] = useState(false);

  const onChangeMode = (mode) => {
    if (mode == false)
    {
      loadResults()
      setResultMode(mode)
    }
    else
      setResultMode(mode)
  }

  const loadResults = () => {
    if (props.selectedRequest != "") {
      const url = AnalyseConfig.API_URL + 'requete/' + props.selectedRequest;
      fetch(url)
        .then((response) => {
          if (response.ok) {
            response.json().then((data) => {
              console.log(data)
              if (data.lstTypeAnalyse.length <= 0)
                setNoAnalyse(true)
              else if (!data.lstResultats || data.lstResultats.length <= 0)
                setCanAddResult(true);
              else
                setResultsExist(true)
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
  }

  const setValues = (data) => {

    setRequest(data)

    const url = AnalyseConfig.API_URL + 'typeanalyse/categories';
    fetch(url)
      .then(response => {
        if (response.ok) {
          response.json().then(dataresult => {
            var filteredCategories = [];
            var neededCategoryIds = [];
            var neededTypeIds = [];

            data.lstTypeAnalyse.forEach(ta => {
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
  }

  const [categories, setCategories] = useState([]);

  useEffect(() => {

    if (props.selectedRequest != "") {
      const url = AnalyseConfig.API_URL + 'requete/' + props.selectedRequest;
      fetch(url)
        .then((response) => {
          if (response.ok) {
            response.json().then((data) => {
              console.log(data)
              if (data.lstTypeAnalyse.length <= 0)
                setNoAnalyse(true)
              else if (!data.lstResultats || data.lstResultats.length <= 0)
                setCanAddResult(true);
              else
                setResultsExist(true)
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
            <View style={[styles.detailsBox]}>
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
                  </View>
                </View>
                {resultsExist ? (

                  <ScrollView style={{
                    height: '80%',
                    marginRight: '5%',
                    marginTop: '1%'
                  }}>
                    {
                      categories && categories.length > 0 &&
                      categories.map((cat) => (
                        <View style={styles.category}>
                          <Text style={styles.categoryTitle}>{cat.name}</Text>
                          {
                            cat.typeAnalyseList.map((t) => (
                              <View style={styles.type} >
                                <Text style={styles.typeTitle}>{t.nom} : </Text>
                                {
                                  request && request.lstResultats && request.lstResultats.length > 0 &&
                                  request.lstResultats.map((r) => (
                                    r.typeValeur.typeAnalyseId == t.idTypeAnalyse &&
                                    <View style={{ flexDirection: 'row', paddingTop: 8 }}>
                                      <Text> {r.typeValeur.nom + " : " + r.valeur}</Text>
                                      <Text style={styles.referenceText}>({r.typeValeur.reference})</Text>
                                    </View>
                                  ))
                                }
                              </View>
                            ))
                          }
                        </View>
                      ))
                    }
                  </ScrollView >
                ) : ( noAnalyse ? (<Text style={styles.noDataText}>Il n'y a pas d'analyse demandée pour cette requête</Text>): (<Text style={styles.noDataText}>Il n'y a aucun résultat d'analyse pour cette requête</Text>))}

              </View>
            </View>

          )}
          {
            canAddResult &&
            <View style={{ flex:0.1, marginTop: 12 }}>
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
    flex: 1
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
    flex: 1,
  },
  referenceText: {
    paddingLeft: 6,
    fontWeight: 'bold'
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
    marginRight: 10,
    marginBottom: 15,
    marginRight: 20
  },
  categoryTitle: {
    fontWeight: "bold",
    fontSize: 25,
    marginBottom: 15,
    marginLeft: 8
  },
  type: {
    margin: 5,
    padding: 12,
    borderRadius: 5,
    marginBottom: 8
  },
  typeTitle: {
    fontWeight: "bold",
    display: 'flex',
    fontSize: 16
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