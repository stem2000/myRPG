using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTargetLinker : MonoBehaviour
{
    [SerializeField] private List<Target> targets;
    private AbilityButtonUI abilityButtonUI;
    private Ability activeAbility; 
    private Target activeTarget;


    public void Start(){
        abilityButtonUI = this.gameObject.GetComponent<AbilityButtonUI>();}


    public void SetActiveAbility(Ability ability){
        activeAbility = ability;
        abilityButtonUI.SetActiveAbilityPick(activeAbility.GetPick());
        Debug.Log(activeAbility.GetName());}
}
