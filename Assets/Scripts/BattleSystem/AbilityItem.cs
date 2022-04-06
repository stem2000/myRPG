using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AbilityItem : MonoBehaviour
{
    [HideInInspector]public string abilityname;
    [HideInInspector]public string abilitypickPath;

    private Image abilityPick;
    private Text abilityText;

    
    public void Awake(){
        abilityText =  gameObject.transform.Find("Text").GetComponent<Text>();
        abilityPick =  gameObject.transform.Find("AbilityPick").GetComponent<Image>();}

    public void InitializeAbilityItem(Ability ability){
        abilityname = ability.GetName();
        abilitypickPath = ability.GetPick();
        abilityText.text = abilityname;
        try{
            abilityPick.sprite = Resources.Load<Sprite>(abilitypickPath);}
        catch(Exception e){
            Debug.Log("<color=red>FileLoadError: </color>AbilityItem => InitializeAbilityItem():" + e.Message);}}
}
