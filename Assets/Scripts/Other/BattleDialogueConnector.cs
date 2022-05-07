using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BattleDialogueConnector : MonoBehaviour
{
    public static String personID = "";
    public static int altNodeIfWin = 0;
    public static int altNodeIfLose = 0;
    public static string enemyName = "";
    public static void SetAltNode(bool playerWon){
        if(playerWon){
            PlayerPrefs.SetInt(personID,altNodeIfWin);}
        else{
            PlayerPrefs.SetInt(personID,altNodeIfLose);}}}
