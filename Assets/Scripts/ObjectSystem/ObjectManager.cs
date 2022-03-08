using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private TownPlace townPlacePrefab;
    [SerializeField] private FileManager fileManager;
    [SerializeField] private List<Town> towns;
    private static string currentIdToLoad = String.Empty;
    [SerializeField]private static Dictionary<string,ItemsInfo> idToItem = new Dictionary<string, ItemsInfo>();
    public UnityEvent<ItemsInfo> getObjectsFromOM = new UnityEvent<ItemsInfo>();


    public static void LoadItemsAtScrollView(string id){
        Debug.Log("LoadItemsAtScrollView");
        currentIdToLoad = id;}


    public void Start() {
        loadTowns();}

    public void OnDestroy(){
        getObjectsFromOM.RemoveAllListeners();}

    public void Update(){
        ItemsInfo item;
        if(currentIdToLoad != String.Empty){
            if(idToItem.TryGetValue(currentIdToLoad,out item)){
                Debug.Log("Update.Invoke");
                currentIdToLoad = String.Empty;
                getObjectsFromOM?.Invoke(item);}}}


    public void OnApplicationQuit() {
        foreach(Town town in towns){ 
            fileManager.SaveToFile(town.GetItems(),town.objectId);}}


    private void loadTowns(){
        string townPlaces = String.Empty;
        foreach(Town town in towns){ 
            townPlaces = fileManager.LoadFromFile(town.objectId);// not objectId but filename
            loadPlaces(town,fileManager.ConvertJsonToItemsInfo(townPlaces));
            idToItem.Add(town.objectId,town.GetItems());// dictionary dublicate objects
            loadQuestGivers(town);}}

     private void loadPlaces(Town town,ItemsInfo places){
        TownPlace tPlace = null;
        foreach(ItemInfo itemInfo in places.objectsList){
            tPlace = GameObject.Instantiate(townPlacePrefab);
            tPlace.SetItemInfo(itemInfo);
            town.townPlaces.Add(tPlace);}}


    private void loadQuestGivers(Town town){
        string questGivers = String.Empty;
        foreach(TownPlace tPlace in town.townPlaces){ 
            questGivers = fileManager.LoadFromFile(tPlace.GetItemInfo().filename);
            tPlace.SetQuestGivers(fileManager.ConvertJsonToItemsInfo(questGivers));
            idToItem.Add(tPlace.GetItemInfo().id,fileManager.ConvertJsonToItemsInfo(questGivers));}}


}
