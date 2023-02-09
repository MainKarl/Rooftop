import { Alert } from "react-native";
import React from "react";

const AlertConnectionFailed = (fetchFunction) => {
    Alert.alert(
        'Erreur de connexion au serveur',
        'Voulez-vous réessayer?',
        [
            {
                text: 'Réessayer',
                onPress: () => fetchFunction()
            }
        ]
    );
}

export default AlertConnectionFailed;