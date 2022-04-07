using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AbilityItem : MonoBehaviour
{
    [HideInInspector]public string textForItem;
    [HideInInspector]public string pickForItem;

    private Ability ability;
    private AbilityTargetLinker atLinker;
    private AbilityItemUI abilityItemUI;



    
    public void Awake(){
        abilityItemUI = gameObject.GetComponent<AbilityItemUI>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(PushAbilityToAtLinker);}


    public void InitializeAbilityItem(Ability ability, AbilityTargetLinker atLinker){
        this.ability = ability;
        this.atLinker = atLinker;
        textForItem = ability.GetName() + "[<color=#2338B7>" + ability.GetCastCost() + "</color>]";
        pickForItem = ability.GetPick();
        abilityItemUI.SetAbilityText(textForItem);
        abilityItemUI.SetAbilityPick(pickForItem);}



    public void PushAbilityToAtLinker(){
        atLinker.SetActiveAbility(ability);}

}
