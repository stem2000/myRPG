using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TownPlace: MonoBehaviour, IItemBasicFunctional
{

    [SerializeField] private List<Person> persons;

     public List<Tuple<ItemInfo,UIConnector>> getIncludedItems(){
        List<Tuple<ItemInfo,UIConnector>> itemsInfo = new List<Tuple<ItemInfo,UIConnector>>();
        foreach(Person person in persons){
            itemsInfo.Add(new Tuple<ItemInfo,UIConnector>(person.GetComponent<ObjectDescriptor>().objectDescription,person.GetComponent<UIConnector>()));
        }
        return itemsInfo;}

}
