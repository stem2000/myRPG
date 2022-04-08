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
    private AbilityItemUI abilityItemUI;
    private AbilitiesContainer abilitiesContainer;



    
    public void Awake(){
        abilityItemUI = gameObject.GetComponent<AbilityItemUI>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(PushAbilityToContainer);}


    public void InitializeAbilityItem(Ability ability, AbilitiesContainer abilitiesContainer){
        this.ability = ability;
        this.abilitiesContainer = abilitiesContainer;
        textForItem = ability.GetName() + "[<color=#2338B7>" + ability.GetCastCost() + "</color>]";
        pickForItem = ability.GetPick();
        abilityItemUI.SetAbilityText(textForItem);
        abilityItemUI.SetAbilityPick(pickForItem);}

    public void PushAbilityToContainer(){
        abilitiesContainer.SetActiveAbility(ability);}

}
