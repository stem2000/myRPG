using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityButtonUI : MonoBehaviour
{
    private Image itemImage;
    private Text itemText;


    public void Start(){
        itemImage = this.gameObject.GetComponent<Image>();
        itemText = this.gameObject.GetComponentInChildren<Text>();}


    public void SetActiveAbilityPick(string pickName){
         try{
           itemImage.sprite = Resources.Load<Sprite>(pickName);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>AbilityButtonUI => SetActiveAbilityPick():" + e.Message);}}
}
