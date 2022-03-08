using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Town : MonoBehaviour
{
    [SerializeField] public List<TownPlace> townPlaces;
    public string objectId = String.Empty;


    void Start(){
        townPlaces = new List<TownPlace>();}

    public void OnMouseDown(){
        Debug.Log("TownButton activated");
        ObjectManager.LoadItemsAtScrollView(objectId);}

        
    public ItemsInfo GetItems(){
        ItemsInfo items;
        items.objectsList = new List<ItemInfo>();
        foreach(TownPlace tPlace in townPlaces){
            items.objectsList.Add(tPlace.GetItemInfo());}
        return items;}
}


interface IItemBasicFunctional{
    public void SetItemInfo(ItemInfo itemInfo);
    public ItemInfo GetItemInfo();}



