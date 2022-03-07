using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
public class ScrollViewAdapter : MonoBehaviour
{

    public RectTransform prefab;
    public RectTransform content;
    public static event getItems getObjectsFromOM;


    public static void FillScrollView(string id){
        getObjectsFromOM?.Invoke(id);}


    public void LoadItems(ItemsInfo items){
        DestroyItems();
        foreach(ItemInfo item in items.objectsList){
            var itemView = GameObject.Instantiate(prefab.gameObject) as GameObject;
            itemView.transform.SetParent(content,false);
            itemView.GetComponent<ItemView>().InitializeItemView(item);}}//GetComponent???

    private void DestroyItems(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}


}

static class ItemViewTypes{
     public const string Place = "Place";
     public const string QuestGiver = "QuestGiver";
}

public delegate ItemsInfo getItems(string id);