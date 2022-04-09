using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoBehaviour
{
    private int PLAYERMAXATTACKABILITIES = 2;
    private int PLAYERMAXDEFENCEABILITIES = 2;
    private int PLAYERMAXLUCKABILITIES = 1;
    private int PLAYERMAXCOSTABILITIES = 1;
    private int PLAYERMAXULTIMATEBILITIES = 1;
    private int TURNNUMBER = 1;
    public Battler player;
    public Battler playerOponnent;
    public List<AbilitiesContainer> playerAbilitiesContainers;
    private BattlerAbilitySet playerThisTurnAbilites;
    private BattlerAbilitySet opponentThisTurnAbilites;
    [SerializeField] private AbilityViewAdapter abilityViewAdapter;

    void Start()
    {
        playerThisTurnAbilites = new BattlerAbilitySet();}

    public bool ApplicabilityAbilityCheck(Ability abilityForAply,int thisAbilityCount){
        if(player.CheckIsCpEnough(abilityForAply.GetCastCost()) && AbilityCountLimitationCheck(abilityForAply,thisAbilityCount)){
            player.TakeCp(abilityForAply.GetCastCost());
            return true;}
        return false;}

    public void AbilityCancellation(Ability ability){
        player.AddCp(ability.GetCastCost());}

    
    public void EndTurn(){
        GetAbilitiesOfAllTypes();
        ClearContainers(playerAbilitiesContainers);
        ClearAbilityViewPanel();
        RestoreCpOfTheBattlers();}

    public void CastAttackAndDefenseAbilities(Battler defendingBattler, List<AttackAbility> attackAbility, List<DefenceAbility> defenceAbility){

    }

    public void ClearAbilityViewPanel(){
        abilityViewAdapter.DestroyAbilities();}
    public bool AbilityCountLimitationCheck(Ability abilityForAply,int thisAbilityCount){
        if(abilityForAply.GetType() == typeof(AttackAbility) && thisAbilityCount >= PLAYERMAXATTACKABILITIES)
            return false;
        else if(abilityForAply.GetType() == typeof(DefenceAbility) && thisAbilityCount >= PLAYERMAXDEFENCEABILITIES)
            return false;
        else if(abilityForAply.GetType() == typeof(CostAbility) && thisAbilityCount >= PLAYERMAXCOSTABILITIES)
            return false;
        else if(abilityForAply.GetType() == typeof(LuckAbility) && thisAbilityCount >= PLAYERMAXLUCKABILITIES)
            return false;
        else if(abilityForAply.GetType() == typeof(UltimateAbility) && thisAbilityCount >= PLAYERMAXULTIMATEBILITIES)
            return false;
        else return true;}


    public void GetAbilitiesOfAllTypes(){
        playerThisTurnAbilites.attackAbility = new List<Ability>(playerAbilitiesContainers[0].GetAllAbilities());
        playerThisTurnAbilites.defenceAbility = new List<Ability>(playerAbilitiesContainers[1].GetAllAbilities());
        playerThisTurnAbilites.luckAbility = new List<Ability>(playerAbilitiesContainers[2].GetAllAbilities());
        playerThisTurnAbilites.costAbility = new List<Ability>(playerAbilitiesContainers[3].GetAllAbilities());
        playerThisTurnAbilites.ultimateAbility = new List<Ability>(playerAbilitiesContainers[4].GetAllAbilities());}

    
    public void ClearContainers(List<AbilitiesContainer> abilitiesContainers){
        foreach(AbilitiesContainer abilitiesContainer in abilitiesContainers){
            abilitiesContainer.RemoveAllActiveAbilites();}}

    public void RestoreCpOfTheBattlers(){
        player.RestoreCp();
        playerOponnent.RestoreCp();}

}

public class BattlerAbilitySet{
    public List<Ability> attackAbility;
    public List<Ability> defenceAbility;
    public List<Ability> luckAbility;
    public List<Ability> costAbility;
    public List<Ability> ultimateAbility;}