using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityItemUI : MonoBehaviour
{
    private AbilityItem abilityItem;
    private Image abilityPick;
    private Text abilityText;

    public void Awake(){
        abilityItem = this.gameObject.GetComponent<AbilityItem>();
        abilityText =  gameObject.transform.Find("Text").GetComponent<Text>();
        abilityPick =  gameObject.transform.Find("AbilityPick").GetComponent<Image>();}


    public void SetAbilityPick(string imagePath){
        try{
            abilityPick.sprite = Resources.Load<Sprite>(imagePath);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>AbilityItemUI => SetAbilityPick():" + e.Message);}}


    public void SetAbilityText(string text){
        abilityText.text = text;}

}
