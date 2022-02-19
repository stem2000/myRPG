using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScrollViewAdapter : MonoBehaviour
{

    public RectTransform prefab;
    public RectTransform content;

    public void LoadItems(List<ItemViewDescription> iwd_list){
        DestroyItems();
        foreach(ItemViewDescription item in iwd_list){
            var itemView = GameObject.Instantiate(prefab.gameObject) as GameObject;
            itemView.transform.SetParent(content,false);
            InitializeItemView(itemView,item);}}

    private void DestroyItems(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}

    private void InitializeItemView(GameObject itemView, ItemViewDescription itemDescription){
        itemView.transform.Find("ItemName").GetComponentInChildren<Text>().text = itemDescription.name;
        itemView.transform.Find("ItemDescription").GetComponentInChildren<Text>().text = itemDescription.description;
        itemView.transform.GetComponent<ItemInfo>().itemId = itemDescription.id;

        try{
            itemView.transform.Find("ItemImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(itemDescription.imagePath);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>ScrollViewFunctional => InitializeItemView():" + e.Message);}}





}

public class ItemViewDescription
{
    public string name;
    public string imagePath; 
    public string description;
    public string id;

    public ItemViewDescription(string name, string imagePath, string description, string id){
        this.name = name;
        this.imagePath = imagePath;
        this.description = description;
        this.id = id;
    }
}
