using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScrollViewFunctional : MonoBehaviour
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
        itemView.GetComponentInChildren<Text>().text = itemDescription.text;
        try{
            itemView.transform.Find("ItemImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(itemDescription.imagePath);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>ScrollViewFunctional => InitializeItemView():" + e.Message);}}





}

public class ItemViewDescription
{
    public string text;
    public string imagePath; 

    public ItemViewDescription(string text, string imagePath){
        this.text = text;
        this.imagePath = imagePath;
    }
}
