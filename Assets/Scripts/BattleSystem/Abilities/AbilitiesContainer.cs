using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilitiesContainer : MonoBehaviour
{
    [SerializeField] private BattleController battleController;
    [SerializeField]public List<Ability> abilityPrefabs;
    [HideInInspector] public List<Ability> abilities;
    private AbilityButtonUI abilityButtonUI;

    [HideInInspector] public Ability activeAbility;
    public void Start(){
        abilityButtonUI = this.gameObject.GetComponent<AbilityButtonUI>();
        abilities.Clear();
        foreach(Ability ability in abilityPrefabs){
            abilities.Add(Instantiate(ability));}}


    public void SetActiveAbility(Ability ability){
        if(battleController.ApplicabilityAbilityCheck(ability,activeAbility)){
            activeAbility = ability;
            abilityButtonUI.SetButtonPick(ability.GetPick());}}

    public void CancelActiveAbility(){
        activeAbility = null;
        abilityButtonUI.SetDefaultButtonPick();}
    
}
