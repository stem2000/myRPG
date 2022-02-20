using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectManager : MonoBehaviour
{

    [SerializeField] private FileManager fileManager;
    [SerializeField] private List<Town> towns;
    [SerializeField] private List<ItemsInfo> ItemsInfo;


    public void Start() {
        string townPlace = String.Empty;

        foreach(Town town in towns){ 
            townPlace = fileManager.LoadFromFile(town.GetFileName());
            town.SetPlaces(fileManager.ConvertJsonToItemsInfo(townPlace));}}


    public void OnApplicationQuit() {
        foreach(Town town in towns){ 
            fileManager.SaveToFile(town.GetItems(),town.GetFileName());}}

    public void UpdateScrollViewFromPlaces(string id){
        
    }

    public void UpdateScrollViewFromTowns(string id){
        
    }
}

 
