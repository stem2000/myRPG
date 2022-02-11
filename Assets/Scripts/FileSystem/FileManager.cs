using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileManager : MonoBehaviour
{
    [SerializeField] private List<Town> allTowns;
    public void Start() {
        foreach(Town town in allTowns){ 
            town.SetPlaces(LoadPlacesFromFile(town.GetFileName()));}}


    public void OnApplicationQuit() {
        foreach(Town town in allTowns){ 
            SavePlacesToFile(town.town_places,town.GetFileName());}}


    public void SavePlacesToFile(TownPlaces placesForSave, string fileName){ 

        string savePath = Path.Combine(Application.dataPath,fileName);
        string json = JsonUtility.ToJson(placesForSave,true);
        
        try{
            File.WriteAllText(savePath,json);}
        catch(Exception e){ 
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => SavePlacesToFile():" + e.Message);}}

   
    public TownPlaces LoadPlacesFromFile(string fileName){ 

        string savePath = Path.Combine(Application.dataPath,fileName);

        if(!File.Exists(savePath)){ 
            Debug.Log("<color=red>FileNotFound:</color>ObjectFileManager => LoadPlacesFromFile():" + fileName);
                return new TownPlaces(null);}

        try{
            string json = File.ReadAllText(savePath);
            TownPlaces placesList = JsonUtility.FromJson<TownPlaces>(json);
                return placesList;}
        catch(Exception e){ 
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => LoadPlacesFromFile():" + e.Message);
            return new TownPlaces(null);}}







}
