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
} from 'react-native';
import AnalyseConfig from "../analyseConfig.json";
import { Table, TableWrapper, Row, Rows, Col, Cols, Cell } from 'react-native-table-component';
import linq from "linq";

const RequestDetails = props => {

  const [request, setRequest] = useState(null);
  const [testData, setTestData] = useState();
  const [tableHead, setTableHead] = useState(['Test', 'Result', 'Reference']);
  const [tableData, setTableData] = useState();

  const loadResults = () => {
    console.log(request)
    let differentTests = 0
    let arrayTest = [];
    let arrayFinal = [];
    request.lstTypeAnalyse.map((analyse) => {
      arrayTest.push(analyse.idTypeAnalyse)
    })
    console.log("ARRAY TEST")
    console.log(arrayTest)
    arrayTest.map((type) => {
      let result = request.lstResultats.filter(resultat => resultat.typeValeur.typeAnalyseId == type)
      arrayFinal.push([type, result])
    })
    console.log("ARRAY FINAL")
    console.log(arrayFinal)
    setTableData(arrayFinal)
    //setTableData(arrayTest)
  }

  const setValues = (data) => {
    setRequest(data)
    console.log("DATA")
    console.log(data)
    let differentTests = 0
    let arrayTest = [];
    let arrayFinal = [];
    data.lstTypeAnalyse.map((analyse) => {
      arrayTest.push(analyse.nom)
    })
    console.log("ARRAY TEST")
    console.log(arrayTest)
    arrayTest.map((type) => {
      let result = request.lstResultats.filter(resultat => resultat.typeValeur.nom == type)
      let arrayResults = []
      result.map((result) => {
        arrayResults.push([result.typeValeur.nom, result.valeur, result.typeValeur.reference])
      })
      arrayFinal.push([type, arrayResults])
    })
    console.log("ARRAY FINAL")
    console.log(arrayFinal)
  }

  useEffect(() => {

    if (props.requestId != "") {
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
  }, [props.requestId]);

  const printRequest = () => {
    console.log(request)
  }

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
              {arrayFinal.map((typeAnalyse) => {
                <View>
                  <View>
                    typeAnalyse[0]
                  </View>
                  <View style={styles.tableStyle}>
                    <Table borderStyle={{ borderWidth: 2, borderColor: '#c8e1ff' }}>
                      <Row data={tableHead} style={styles.head} textStyle={styles.text} />
                      <Rows data={typeAnalyse[0]} textStyle={styles.text} />
                    </Table>
                  </View>
                </View>
              })}
              <View style={styles.tableStyle}>
                <Table borderStyle={{ borderWidth: 2, borderColor: '#c8e1ff' }}>
                  <Row data={tableHead} style={styles.head} textStyle={styles.text} />
                  <Rows data={tableData} textStyle={styles.text} />
                </Table>
              </View>

            </View>
          </View>
        )}
      </View>
      <Button
        title={'Entrer les résultats'}
        onPress={() => props.onChangeState(3)} />
    </View>
  );
};

const styles = StyleSheet.create({
  head: { height: 40, backgroundColor: '#f1f8ff' },
  text: { margin: 6 },
  container: {
    flex: 0.8,
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
    height: '90%',
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
  }
});

export default RequestDetails;