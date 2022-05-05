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
        Ability abilityForActiveList = Instantiate(ability);
        abilityForActiveList.CalculateCastCost();
        if(battleController.ApplicabilityAbilityCheck(abilityForActiveList,CountofAllAbilities()))
           activeAbilities.Add(abilityForActiveList);}

    public void TakeAbilityFromActiveList(string id){
        for(int i = activeAbilities.Count - 1; i >= 0; i--){
            if(activeAbilities[i].GetId() == id){
                 battleController.AbilityCancellation(activeAbilities[i]);
                 activeAbilities.RemoveAt(i);
                 return;}}}

    
    public int CountOfAbility(string id){
        int count = 0;
        foreach(Ability ability in activeAbilities){
            if(id.Equals(ability.GetId()))
                count++;}
        return count;}

    public Ability ReturnFirstAbility(){
        if(activeAbilities.Count != 0){
            return activeAbilities[0];}
        return null;}

    public int CountofAllAbilities(){
        return activeAbilities.Count;}

    public List<Ability> GetAllAbilities(){
        return activeAbilities;}

    public void RemoveAllActiveAbilites(){
        activeAbilities.Clear();}


    
    
}
