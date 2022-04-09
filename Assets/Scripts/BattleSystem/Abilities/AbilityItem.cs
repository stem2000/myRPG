using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class AbilityItem : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]public string textForItem;
    [HideInInspector]public string pickForItem;

    private Ability ability;
    private AbilityItemUI abilityItemUI;
    private AbilitiesContainer abilitiesContainer;



    
    public void Awake(){
        abilityItemUI = gameObject.GetComponent<AbilityItemUI>();}


    public void InitializeAbilityItem(Ability ability, AbilitiesContainer abilitiesContainer){
        this.ability = ability;
        this.abilitiesContainer = abilitiesContainer;
        SetItemText(abilitiesContainer.CountOfAbility(ability));
        pickForItem = ability.GetPick();
        abilityItemUI.SetAbilityText(textForItem);
        abilityItemUI.SetAbilityPick(pickForItem);}

    
    private void SetItemText(int abilityCount){
         textForItem = ability.GetName() + "[<color=#2338B7>" + ability.GetCastCost() + "</color>]" + 
         " [<color=green>" + abilityCount + "</color>]";}

    public void PushAbilityToContainer(){
        abilitiesContainer.PushAbilityToActiveList(ability);
        SetItemText(abilitiesContainer.CountOfAbility(ability));
        abilityItemUI.SetAbilityText(textForItem);}

    public void TakeAbilityFromContainer(){
        abilitiesContainer.TakeAbilityFromActiveList(ability);
        SetItemText(abilitiesContainer.CountOfAbility(ability));
         abilityItemUI.SetAbilityText(textForItem);}

    public void OnPointerClick(PointerEventData eventData){
        if (eventData.button == PointerEventData.InputButton.Left){
            PushAbilityToContainer();
            eventData.Reset();}
        else if (eventData.button == PointerEventData.InputButton.Right){
            TakeAbilityFromContainer();
            eventData.Reset();}}

}
