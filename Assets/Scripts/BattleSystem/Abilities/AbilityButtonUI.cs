using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityButtonUI : MonoBehaviour
{
    private Image itemImage;
    private Text itemText;

    [SerializeField] private string defautPicture;


    public void Start(){
        itemImage = this.gameObject.GetComponent<Image>();
        itemText = this.gameObject.GetComponentInChildren<Text>();}


    public void SetButtonPick(string pickName){
         try{
           itemImage.sprite = Resources.Load<Sprite>(pickName);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>AbilityButtonUI => SetActiveAbilityPick():" + e.Message);}}

    public void SetDefaultButtonPick(){
        SetButtonPick(defautPicture);}

}
