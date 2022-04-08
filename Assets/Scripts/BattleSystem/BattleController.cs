using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoBehaviour
{
    public Battler player;
    public Battler playerOponnent;
    public List<AbilitiesContainer> abilitiesContainers;
    void Start()
    {
        
    }

    public bool ApplicabilityAbilityCheck(Ability abilityForAply,Ability activeAbility){
        if(player.TakeCp(abilityForAply.GetCastCost())){
            if(activeAbility != null)
                player.AddCp(activeAbility.GetCastCost());
            return true;}
        return false;}

    public void AbilityCancellation(AbilitiesContainer abilitiesContainer){
        player.AddCp(abilitiesContainer.activeAbility.GetCastCost());
        abilitiesContainer.CancelActiveAbility();}
}
