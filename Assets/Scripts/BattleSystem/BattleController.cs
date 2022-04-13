using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
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
    private BattlerAbilitySet playerAbilitiesInfo;
    private BattlerAbilitySet opponentThisTurnInfo;
    [SerializeField] private string EndTurnPick;
    [SerializeField] private AbilityViewAdapter abilityViewAdapter;
    [SerializeField] private BattleInfoAdapter battleInfoAdapter;
  

    void Start(){
        playerAbilitiesInfo = new BattlerAbilitySet();
        opponentThisTurnInfo = new BattlerAbilitySet();}


    public bool ApplicabilityAbilityCheck(Ability abilityForAply,int thisAbilityCount){
        int abilityCost = abilityForAply.GetCastCost() - AbilityCostDecrease(abilityForAply.GetId());
        if(player.CheckIsCpEnough(abilityCost) && AbilityCountLimitationCheck(abilityForAply,thisAbilityCount)){
            player.TakeCp(abilityCost);
            abilityForAply.SetCastCost(abilityCost);
            return true;}
        return false;}

    public void AbilityCancellation(Ability ability){
        player.AddCp(ability.GetCastCost());}

    
    public void EndTurn(){
        PushTurnNumberIfEnd();
        IncreaseTurnNumber();
        GetAbilitiesOfAllTypes();
        ClearContainers(playerAbilitiesContainers);
        ClearAbilityViewPanel();
        CostAbilitiesCleaning(playerAbilitiesInfo);

        CastAttackAbilities(playerAbilitiesInfo);
        CastDefenceAbilities(playerAbilitiesInfo);

        GiveDamageToBattler(playerOponnent,playerAbilitiesInfo,opponentThisTurnInfo);
        RestoreCpOfTheBattlers();
        
        PushCostAbilitiesInfo(playerAbilitiesInfo);}


    private void ClearAbilityViewPanel(){
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


    private void GetAbilitiesOfAllTypes(){
        Ability luckAbility;
        Ability costAbility;
        playerAbilitiesInfo.attackAbilities = new List<Ability>(playerAbilitiesContainers[0].GetAllAbilities());
        playerAbilitiesInfo.defenceAbilities = new List<Ability>(playerAbilitiesContainers[1].GetAllAbilities());
        luckAbility = playerAbilitiesContainers[2].ReturnFirstAbility();
        if(luckAbility != null){
            ((LuckAbility)luckAbility).SetPlayingTurn(TURNNUMBER);
            playerAbilitiesInfo.luckAbilities.Add(luckAbility);}
        costAbility = playerAbilitiesContainers[3].ReturnFirstAbility();
        if(costAbility != null){
            ((CostAbility)costAbility).SetPlayingTurn(TURNNUMBER);
            playerAbilitiesInfo.costAbilities.Add(costAbility);}
        playerAbilitiesInfo.ultimateAbilities = new List<Ability>(playerAbilitiesContainers[4].GetAllAbilities());}

    
    private void ClearContainers(List<AbilitiesContainer> abilitiesContainers){
        foreach(AbilitiesContainer abilitiesContainer in abilitiesContainers){
            abilitiesContainer.RemoveAllActiveAbilites();}}


    private void RestoreCpOfTheBattlers(){
        player.RestoreCp();
        playerOponnent.RestoreCp();}


    private void IncreaseTurnNumber(){
        TURNNUMBER++;}


    private void CastAttackAbilities(BattlerAbilitySet player){
        int totalDamage = 0;
        int abilityDamage = 0;
        foreach(Ability ability in player.attackAbilities){
            abilityDamage = ((AttackAbility)ability).CastAttackAbility();
            totalDamage += abilityDamage;
            PushAttackAbilityInfo(ability.GetPick(),ability.GetName(),abilityDamage);}
        player.totalAttackDamage = totalDamage;}


    private void CastDefenceAbilities(BattlerAbilitySet player){
        int totalDefence = 0;
        int abilityDefence = 0;
        foreach(Ability ability in player.defenceAbilities){
            abilityDefence = ((DefenceAbility)ability).CastDefenceAbility();
            totalDefence += abilityDefence;
            PushDefenceAbilityInfo(ability.GetPick(),ability.GetName(),abilityDefence);}
        player.totalBlockedDamage = totalDefence;}

    private int AbilityCostDecrease(String abilityId){
        int lessCost = 0;
        foreach(Ability ability in playerAbilitiesInfo.costAbilities){
                lessCost += ((CostAbility)ability).CastAbility(abilityId,TURNNUMBER);}
        return lessCost;}

    private void CostAbilitiesCleaning(BattlerAbilitySet battlerAbilitySet){
       for(int i = 0; i < battlerAbilitySet.costAbilities.Count; i++){
            if(((CostAbility)battlerAbilitySet.costAbilities[i]).GetPlayingTurn() < TURNNUMBER)
                battlerAbilitySet.costAbilities.RemoveAt(i);}}


    public void PushCostAbilitiesInfo(BattlerAbilitySet battlerAbilitySet){
        foreach(Ability ability in battlerAbilitySet.costAbilities){
            PushCostAbilityInfo(ability.GetPick(),ability.GetName(),((CostAbility)ability).GetPlayingTurn());}}


    private void GiveDamageToBattler(Battler receivingDamage, BattlerAbilitySet givingSet, BattlerAbilitySet receivingSet){
        receivingDamage.TakeHp(givingSet.totalAttackDamage-receivingSet.totalBlockedDamage);}


    private void PushAttackAbilityInfo(string imagePath,string abilityName, int abilityDamage){
        string battleInfoText = string.Empty;
         battleInfoText = string.Format("Способность <color=green>{0}</color> дает <color=red>{1}</color> урона ",
                                            abilityName, abilityDamage.ToString());
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}


    private void PushDefenceAbilityInfo(string imagePath,string abilityName, int abilityResist){
        string battleInfoText = string.Empty;
         battleInfoText = string.Format("Способность <color=green>{0}</color> дает <color=red>{1}</color> отраженного урона ",
                                            abilityName, abilityResist.ToString());
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}

    
    private void PushCostAbilityInfo(string imagePath,string abilityName, int turnNumber){
        string battleInfoText = string.Empty;
        if(turnNumber != TURNNUMBER)
            battleInfoText = string.Format("Способность <color=green>{0}</color> сработает на <color=yellow>{1}</color> ход",
                                            abilityName, turnNumber.ToString());
        if(turnNumber == TURNNUMBER)
            battleInfoText = string.Format("Способность <color=green>{0}</color> активна",
                                            abilityName, turnNumber.ToString());
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}


    private void PushTurnNumberIfEnd(){
        string battleInfoText = string.Empty;
            battleInfoText = string.Format("Ход <color=yellow>{0}</color>",TURNNUMBER);
        battleInfoAdapter.AddItemToContent(battleInfoText,EndTurnPick);}

    private void SetBattleResults(){

    }
}

public class BattlerAbilitySet{
    public List<Ability> attackAbilities;
    public int totalAttackDamage;
    public List<Ability> defenceAbilities;
    public int totalBlockedDamage;
    public List<Ability> luckAbilities;
    public List<Ability> costAbilities;
    public List<Ability> ultimateAbilities;
    public BattlerAbilitySet(){
        luckAbilities = new List<Ability>();
        costAbilities = new List<Ability>();}}