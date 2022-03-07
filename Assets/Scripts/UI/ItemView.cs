using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemView : MonoBehaviour
{
    private Text itemName;
    private Text itemDescription;
    private Text itemButtonText;
    private Image itemImage;
    private String objectId;
    private Button itemButton;


    public void Start(){
        itemName = transform.Find("ItemName").GetComponentInChildren<Text>();
        itemDescription = transform.Find("ItemDescription").GetComponentInChildren<Text>();
        itemButtonText = transform.Find("ItemButton").Find("ItemButtonText").GetComponentInChildren<Text>();
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
        itemButton = transform.Find("ItemButton").GetComponent<Button>();}


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
                itemButton.onClick.AddListener(() => {ScrollViewAdapter.FillScrollView(objectId);});
            break;
            case ItemViewTypes.QuestGiver:
                itemButtonText.text = "Взаимодействовать";
                itemButton.onClick.AddListener(() => {ScrollViewAdapter.FillScrollView(objectId);});
            break;
            default:
                itemButtonText.text = "";
            break;}}
}
