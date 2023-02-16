import { Alert } from "react-native";
import React from "react";

const CustomAlert = ({ type, title, message, onSelect, onCancel }) => {
    switch(type) {
        case 'alert_connection_failed':
            Alert.alert(
                'Erreur de connexion au serveur',
                'Voulez-vous réessayer?',
                [
                    {
                        text: 'Réessayer',
                        onPress: () => onSelect()
                    }
                ]
            );
            break;

        case 'alert_submit_failed':
            Alert.alert(
                'Erreur',
                'La soumission du formulaire a échouée, car\n' + message,
                [ { text: 'Ok' } ]
            );
            break;
        
        case 'alert_confirmation':
            Alert.alert(
                title, 
                message, 
                [
                    {
                        text: 'Annuler',
                        onPress: () => onCancel()
                    },
                    {
                        text: 'Confirmer',
                        onPress: () => onSelect()
                    }
                ]
            );
            break;

        case 'alert_message':
            Alert.alert(
                title, 
                message, 
                [
                    {
                        text: "Ok",
                        onPress: () => onSelect()
                    }
                ]
            );
            break;

        default:
            break;
    }
}

export default CustomAlert;
