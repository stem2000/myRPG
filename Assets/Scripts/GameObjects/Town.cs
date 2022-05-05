using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Town : MonoBehaviour, IItemBasicFunctional
{
    [SerializeField] private List<TownPlace> townPlaces;


    public List<Tuple<ItemInfo,UIConnector>> getIncludedItems(){
        List<Tuple<ItemInfo,UIConnector>> itemsInfo = new List<Tuple<ItemInfo,UIConnector>>();
        foreach(TownPlace townPlace in townPlaces){
            itemsInfo.Add(new Tuple<ItemInfo,UIConnector>(townPlace.GetComponent<ObjectDescriptor>().objectDescription,townPlace.GetComponent<UIConnector>()));
        }
        return itemsInfo;}

}


interface IItemBasicFunctional{    
    public List<Tuple<ItemInfo,UIConnector>> getIncludedItems();}





