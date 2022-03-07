using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectManager : MonoBehaviour
{

    [SerializeField] private FileManager fileManager;
    [SerializeField] private List<Town> towns;
    private Dictionary<string,ItemsInfo> itemsInfo;


    public void Start() {
        loadTowns();
        itemsInfo = new Dictionary<string, ItemsInfo>();}


    public void OnApplicationQuit() {
        foreach(Town town in towns){ 
            fileManager.SaveToFile(town.GetItems(),town.GetPlacesFileLocation());}}


    private void loadTowns(){
        string townPlaces = String.Empty;
        foreach(Town town in towns){ 
            townPlaces = fileManager.LoadFromFile(town.GetPlacesFileLocation());
            town.SetPlaces(fileManager.ConvertJsonToItemsInfo(townPlaces));
            loadQuestGivers(town);}}


    private void loadQuestGivers(Town town){
        string questGivers = String.Empty;
        foreach(TownPlace tPlace in town.townPlaces){ 
            questGivers = fileManager.LoadFromFile(tPlace.GetItemInfo().filename);
            tPlace.SetQuestGivers(fileManager.ConvertJsonToItemsInfo(questGivers));}}
    

    public ItemsInfo LoadItems(string id){
        
    }

}

 
