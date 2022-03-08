using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ItemView : MonoBehaviour
{
    private Text itemName;
    private Text itemDescription;
    private Text itemButtonText;
    private Image itemImage;
    private String objectId; // the name of the file in which the value is stored
    private Button itemButton;


    public void Awake(){
        itemName = gameObject.transform.Find("ItemName").GetComponentInChildren<Text>();
        itemDescription = gameObject.transform.Find("ItemDescription").GetComponentInChildren<Text>();
        itemButtonText = gameObject.transform.Find("ItemButton").Find("ItemButtonText").GetComponentInChildren<Text>();
        itemImage = gameObject.transform.Find("ItemImage").GetComponent<Image>();
        itemButton = gameObject.transform.Find("ItemButton").GetComponent<Button>();} 


    public void OnDestroy(){
        itemButton.onClick.RemoveAllListeners();}


    public void InitializeItemView(ItemInfo itemInfo){
        itemName.text = itemInfo.name;
        itemDescription.text = itemInfo.description;
        setItemButtonText(itemInfo.type);
        objectId = itemInfo.id;
        try{
            itemImage.sprite = Resources.Load<Sprite>(itemInfo.imagePath);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>ScrollViewFunctional => InitializeItemView():" + e.Message);}}


    private void setItemButtonText(string type){
        switch(type){
            case ItemViewTypes.Place:
                itemButtonText.text = "Отправиться";
                itemButton.onClick.AddListener(() => ObjectManager.LoadItemsAtScrollView(objectId));
            break;
            case ItemViewTypes.QuestGiver:
                itemButtonText.text = "Взаимодействовать";
                itemButton.onClick.AddListener(() => ObjectManager.LoadItemsAtScrollView(objectId));
            break;
            case ItemViewTypes.Man:
                itemButtonText.text = "Говорить";
                itemButton.onClick.AddListener(() => ObjectManager.LoadItemsAtScrollView(objectId));
            break;
            default:
                itemButtonText.text = "";
            break;}}
}

static class ItemViewTypes{
     public const string Place = "Place";
     public const string QuestGiver = "QuestGiver";
     public const string Man = "Man";
}