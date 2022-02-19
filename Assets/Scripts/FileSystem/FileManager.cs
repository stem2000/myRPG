using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileManager : MonoBehaviour
{
    [SerializeField] private List<Town> allTowns;
    public void Start() {

    string townPlace = String.Empty;

        foreach(Town town in allTowns){ 
            townPlace = LoadFromFile(town.GetFileName());
            town.SetPlaces(ConvertJsonToTownPlaces(townPlace));}}


    public void OnApplicationQuit() {
        foreach(Town town in allTowns){ 
            SaveToFile(town.town_places,town.GetFileName());}}


    public void SaveToFile(System.Object dataForSave, string fileName){ 

        string savePath = Path.Combine(Application.dataPath,fileName);
        string json = JsonUtility.ToJson(dataForSave,true);
        
        try{
            File.WriteAllText(savePath,json);}
        catch(Exception e){ 
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => SavePlacesToFile():" + e.Message);}}

   
    public String LoadFromFile(string fileName){ 

        string savePath = Path.Combine(Application.dataPath,fileName);

        if(!File.Exists(savePath)){ 
            Debug.Log("<color=red>FileNotFound:</color>ObjectFileManager => LoadPlacesFromFile():" + fileName);
                return String.Empty;}

        try{
            string json = File.ReadAllText(savePath);
                return json;}
        catch(Exception e){ 
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => LoadPlacesFromFile():" + e.Message);
            return String.Empty;}}


    public TownPlaces ConvertJsonToTownPlaces(string json){
        if(json != String.Empty){
            TownPlaces placesList = JsonUtility.FromJson<TownPlaces>(json);
                return placesList;}
        return new TownPlaces(null);}





}
