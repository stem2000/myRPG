using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class AbilitiesContainer : MonoBehaviour
{
    [SerializeField] private BattleController battleController;
    [SerializeField]public List<Ability> abilityPrefabs;
    [HideInInspector] public List<Ability> abilitiesForAbilityItem;
    private List<Ability> activeAbilities;
    private AbilityButtonUI abilityButtonUI;
    public void Start(){
        abilityButtonUI = this.gameObject.GetComponent<AbilityButtonUI>();
        activeAbilities = new List<Ability>();
        abilitiesForAbilityItem.Clear();
        foreach(Ability ability in abilityPrefabs){
            abilitiesForAbilityItem.Add(Instantiate(ability));}}


    public void PushAbilityToActiveList(Ability ability){
        if(battleController.ApplicabilityAbilityCheck(ability,CountofAllAbilities()))
           activeAbilities.Add(ability);
           Debug.Log("AbilitiesListSize - " + activeAbilities.Count.ToString());}

    public void TakeAbilityFromActiveList(Ability ability){
        if(activeAbilities.Contains(ability)){
            battleController.AbilityCancellation(ability);
            activeAbilities.Remove(ability);}}

    
    public int CountOfAbility(Ability argAbility){
        int count = 0;
        foreach(Ability ability in activeAbilities){
            if(ability.GetName().Equals(argAbility.GetName()))
                count++;}
        return count;}

    public int CountofAllAbilities(){
        return activeAbilities.Count;}

    public List<Ability> GetAllAbilities(){
        return activeAbilities;}

    public void RemoveAllActiveAbilites(){
        activeAbilities.Clear();}


    
    
}
