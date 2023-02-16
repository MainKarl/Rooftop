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
import linq from "linq";

const RequestDetails = props => {

  const [request, setRequest] = useState(null);
  const [resultsExist, setResultsExist] = useState(true);
  const [resultMode, setResultMode] = useState(false);
  const [testData, setTestData] = useState([]);
  const [tableHead, setTableHead] = useState(['Type de valeur', 'Valeur', 'Référence']);
  const [tableData, setTableData] = useState();
  const [arrayTestReal, setArrayTestReal] = useState();

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
    let arrayTest = [];
    let arrayFinal = [];
    data.lstTypeAnalyse.map((analyse) => {
      arrayTest.push(analyse.nom)
    })
    arrayTest.map((type) => {
      let result = []
      if (data.lstResultats)
      {
          setResultsExist(true)
          result = data.lstResultats.filter(resultat => resultat.typeValeur.nom == type)
      }
      console.log("ARRAY TEST")
      console.log(arrayTest)
      let arrayResults = []
      result.map((result) => {
        arrayResults.push([result.typeValeur.nom, result.valeur, result.typeValeur.reference])
      })
      arrayFinal.push([type, arrayResults])
     })
     console.log("WILL IT WORK?")
     console.log(arrayFinal)
     setTestData(arrayFinal)
     //console.log("ARRAY FINAL WORKED")
  }

  useEffect(() => {

    if (props.selectedRequest != "") {
      const url = AnalyseConfig.API_URL + 'requete/' + props.selectedRequest;
      fetch(url)
        .then((response) => {
          if (response.ok) {
            response.json().then((data) => {
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

  console.log("TEST DATA")
  console.log(testData)
  return (
    <View style={styles.container}>
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

                <ScrollView
                style={{
                  // borderColor: '#808080',
                  // borderWidth: 2,
                  // borderRadius: 5,
                  // borderStyle: 'solid',
                  height: '80%'
                }}>
                  {testData.map((typeAnalyse) => (
                    <View>
                      <View style={styles.tableStyle}>
                        <Text style={styles.tableTitle}>
                          {typeAnalyse[0]}
                        </Text>
                        <Table borderStyle={{ borderWidth: 2, borderColor: '#808080' }}>
                          <Row data={tableHead} style={styles.head} textStyle={styles.text} />
                          <Rows data={typeAnalyse[1]} textStyle={styles.text} />
                        </Table>
                      </View>
                    </View>
                  ))}
                </ScrollView>
              ) : <Text style={styles.noDataText}>Il n'y a pas de résultats pour cette analyse</Text> }
              
            </View>
            </View>
          )}
        <Button
          title={'Entrer les résultats'}
          onPress={() => onChangeMode(true)} />
      </View>
      {resultMode && <AnalyseCreateForm onChangeMode={onChangeMode} request={request} />}
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
  }
});

export default RequestDetails;