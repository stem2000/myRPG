using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScrollViewAdapter : MonoBehaviour
{

    public RectTransform prefab;
    public RectTransform content;

    public void LoadItems(ItemsInfo items){
        DestroyItems();
        foreach(ItemInfo item in items.objectsList){
            var itemView = GameObject.Instantiate(prefab.gameObject) as GameObject;
            itemView.transform.SetParent(content,false);
            InitializeItemView(itemView,item);}}

    private void DestroyItems(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}

    private void InitializeItemView(GameObject itemView, ItemInfo itemDescription){
        itemView.transform.Find("ItemName").GetComponentInChildren<Text>().text = itemDescription.name;
        itemView.transform.Find("ItemDescription").GetComponentInChildren<Text>().text = itemDescription.description;

        try{
            itemView.transform.Find("ItemImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(itemDescription.imagePath);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>ScrollViewFunctional => InitializeItemView():" + e.Message);}}





}

