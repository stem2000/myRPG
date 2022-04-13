using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfoItem : MonoBehaviour
{
    private BattleInfoItemUI battleInfoItemUI;
    public void Awake(){
        battleInfoItemUI = gameObject.GetComponent<BattleInfoItemUI>();}


    public void InitializeBattleInfoItem(string text, string imagePath){
        battleInfoItemUI.SetAbilityText(text);
        battleInfoItemUI.SetAbilityPick(imagePath);}
}
