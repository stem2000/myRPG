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
    private int ENEMYSETNUMBER = 0;
    private int PREVIOUSTURNNUMBER = 0;
    private bool BATTLEISENDED = false;
    private bool PLAYERISWINNER = false;
    public Battler player;
    public Battler playerOponnent;

    public EnemySets EnemySets; 
    public List<AbilitiesContainer> playerAbilitiesContainers;
    private BattlerAbilitySet playerAbilitiesInfo;
    private BattlerAbilitySet opponenAbilitiesInfo;
    [SerializeField] private string EndTurnPick;
    [SerializeField] private string StartBattlePick;
    [SerializeField] private AbilityViewAdapter abilityViewAdapter;
    [SerializeField] private BattleInfoAdapter battleInfoAdapter;
    [SerializeField] private EndBattlePanel endBattlePanel;
  

    void Start(){
        playerAbilitiesInfo = new BattlerAbilitySet();
        opponenAbilitiesInfo = new BattlerAbilitySet();
        PushStartPhrase();}


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

        if(BATTLEISENDED)
            return;
        
        InstallEnemyAbilitiySet();//загрузка способностей врага
        IncreaseTurnNumber();
        GetAbilitiesOfAllTypes();//забрать способности из контейнеров
        ClearContainers(playerAbilitiesContainers);//очистить контейнеры
        ClearAbilityViewPanel();//очистить панель с абилками

        CostAbilitiesCleaning(playerAbilitiesInfo);//удалить сработивашие способности из списка
        LuckAbilitiesCleaning(playerAbilitiesInfo);//удалить сработивашие способности из списка
        CostAbilitiesCleaning(opponenAbilitiesInfo);
        LuckAbilitiesCleaning(opponenAbilitiesInfo);

        CastAttackAbilities(playerAbilitiesInfo,"Игрок");//кастануть атакующие способности
        CastDefenceAbilities(playerAbilitiesInfo, "Игрок");//кастануть защитные способности
        CastAttackAbilities(opponenAbilitiesInfo, EnemySets.enemyName);
        CastDefenceAbilities(opponenAbilitiesInfo, EnemySets.enemyName);

        GiveDamageToBattler(playerOponnent,playerAbilitiesInfo,opponenAbilitiesInfo);//нанести урон врагу
        GiveDamageToBattler(player,opponenAbilitiesInfo,playerAbilitiesInfo);//нанести урон игроку
        RestoreCpOfTheBattlers();//восстановить кастпоинты
        
        //endturn info
        PushAllEndTurnInfo();
        EndBattle();}

    public void EndBattle(){
        if(player.HpInfo() == 0 || playerOponnent.HpInfo() == 0){
            BATTLEISENDED = true;
            if(player.HpInfo() != 0){
                PLAYERISWINNER = true;
                PushEndBattlePhrase("Игрок победил.");}
            else{
                PLAYERISWINNER = false;
                PushEndBattlePhrase("Игрок проиграл.");}
            BattleDialogueConnector.SetAltNode(PLAYERISWINNER);
            endBattlePanel.gameObject.SetActive(true);}}


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
        TURNNUMBER++;
        PREVIOUSTURNNUMBER++;}


    private void CastAttackAbilities(BattlerAbilitySet player, String name){
        int totalDamage = 0;
        int abilityDamage = 0;
        foreach(Ability ability in player.attackAbilities){
            abilityDamage = ((AttackAbility)ability).CastAttackAbility(AbilityProbabilityIncrease(ability.GetId()));
            totalDamage += abilityDamage;
            PushAttackAbilityInfo(ability.GetPick(),ability.GetName(),abilityDamage,name);}
        player.totalAttackDamage = totalDamage;}


    private void CastDefenceAbilities(BattlerAbilitySet player, String name){
        int totalDefence = 0;
        int abilityDefence = 0;
        foreach(Ability ability in player.defenceAbilities){
            abilityDefence = ((DefenceAbility)ability).CastDefenceAbility(AbilityProbabilityIncrease(ability.GetId()));
            totalDefence += abilityDefence;
            PushDefenceAbilityInfo(ability.GetPick(),ability.GetName(),abilityDefence,name);}
        player.totalBlockedDamage = totalDefence;}

    private int AbilityCostDecrease(String abilityId){
        int lessCost = 0;
        foreach(Ability ability in playerAbilitiesInfo.costAbilities){
                lessCost += ((CostAbility)ability).CastAbility(abilityId,TURNNUMBER);}
        return lessCost;}


    private int AbilityProbabilityIncrease(String abilityId){
        int plusLuck = 0;
        foreach(Ability ability in playerAbilitiesInfo.luckAbilities){
                plusLuck += ((LuckAbility)ability).CastAbility(abilityId,TURNNUMBER);}
        return plusLuck;}


    private void CostAbilitiesCleaning(BattlerAbilitySet battlerAbilitySet){
       Ability abilityForDestroy;
       for(int i = 0; i < battlerAbilitySet.costAbilities.Count; i++){
            if(((CostAbility)battlerAbilitySet.costAbilities[i]).GetPlayingTurn() < TURNNUMBER){
                abilityForDestroy = battlerAbilitySet.costAbilities[i];
                battlerAbilitySet.costAbilities.RemoveAt(i);
                Destroy(abilityForDestroy.gameObject);}}}


    private void LuckAbilitiesCleaning(BattlerAbilitySet battlerAbilitySet){
       Ability abilityForDestroy;
       for(int i = 0; i < battlerAbilitySet.luckAbilities.Count; i++){
            if(((LuckAbility)battlerAbilitySet.luckAbilities[i]).GetPlayingTurn() < TURNNUMBER){
                abilityForDestroy = battlerAbilitySet.luckAbilities[i];
                battlerAbilitySet.luckAbilities.RemoveAt(i);
                Destroy(abilityForDestroy.gameObject);}}}


    public void PushCostAbilitiesInfo(BattlerAbilitySet battlerAbilitySet, String name){
        foreach(Ability ability in battlerAbilitySet.costAbilities){
            PushCostAbilityInfo(ability.GetPick(),ability.GetName(),((CostAbility)ability).GetPlayingTurn(),name);}}

    public void PushLuckAbilitiesInfo(BattlerAbilitySet battlerAbilitySet, String name){
        foreach(Ability ability in battlerAbilitySet.luckAbilities){
            PushLuckAbilityInfo(ability.GetPick(),ability.GetName(),((LuckAbility)ability).GetPlayingTurn(),name);}}


    private void GiveDamageToBattler(Battler receivingDamage, BattlerAbilitySet givingSet, BattlerAbilitySet receivingSet){
        int damage = givingSet.totalAttackDamage-receivingSet.totalBlockedDamage;
        if(damage < 0)
            damage = 0;
        receivingDamage.TakeHp(damage);}


    private void InstallEnemyAbilitiySet(){
        if(ENEMYSETNUMBER >= EnemySets.abilitySets.Count)
            ENEMYSETNUMBER = 0;
        opponenAbilitiesInfo.attackAbilities.Clear();
        opponenAbilitiesInfo.defenceAbilities.Clear();
        foreach(Ability ability in EnemySets.abilitySets[ENEMYSETNUMBER].attackAbilities){
            opponenAbilitiesInfo.attackAbilities.Add(Instantiate(ability));}
        foreach(Ability ability in EnemySets.abilitySets[ENEMYSETNUMBER].defenceAbilities){
            opponenAbilitiesInfo.defenceAbilities.Add(Instantiate(ability));}
        foreach(Ability ability in EnemySets.abilitySets[ENEMYSETNUMBER].costAbilities){
            opponenAbilitiesInfo.costAbilities.Add(Instantiate(ability));}
        foreach(Ability ability in EnemySets.abilitySets[ENEMYSETNUMBER].luckAbilities){
            opponenAbilitiesInfo.luckAbilities.Add(Instantiate(ability));}
        ENEMYSETNUMBER++;}


    private void PushAttackAbilityInfo(string imagePath,string abilityName, int abilityDamage, string battlerName){
        string battleInfoText = string.Empty;
         battleInfoText = string.Format("<color=yellow>{2}:</color>Способность <color=green>{0}</color> дает <color=red>{1}</color> урона ",
                                            abilityName, abilityDamage.ToString(),battlerName);
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}


    private void PushDefenceAbilityInfo(string imagePath,string abilityName, int abilityResist, string battlerName){
        string battleInfoText = string.Empty;
         battleInfoText = string.Format("<color=yellow>{2}:</color>Способность <color=green>{0}</color> дает <color=red>{1}</color> отраженного урона ",
                                            abilityName, abilityResist.ToString(),battlerName);
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}

    
    private void PushCostAbilityInfo(string imagePath, string abilityName, int turnNumber, string battlerName){
        string battleInfoText = string.Empty;
        if(turnNumber != TURNNUMBER)
            battleInfoText = string.Format("<color=yellow>{2}:</color>Способность <color=blue>{0}</color> сработает на <color=yellow>{1}</color> ход",
                                            abilityName, turnNumber.ToString(),battlerName);
        if(turnNumber == TURNNUMBER)
            battleInfoText = string.Format("<color=yellow>{2}:</color>Способность <color=blue>{0}</color> активна",
                                            abilityName, turnNumber.ToString(),battlerName);
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}


    private void PushLuckAbilityInfo(string imagePath, string abilityName, int turnNumber, string battlerName){
        string battleInfoText = string.Empty;
        if(turnNumber != TURNNUMBER)
            battleInfoText = string.Format("<color=yellow>{2}:</color>Способность <color=red>{0}</color> сработает на <color=yellow>{1}</color> ход",
                                            abilityName, turnNumber.ToString(),battlerName);
        if(turnNumber == TURNNUMBER)
            battleInfoText = string.Format("<color=yellow>{2}:</color>Способность <color=red>{0}</color> активна.",
                                            abilityName, turnNumber.ToString(),battlerName);
        battleInfoAdapter.AddItemToContent(battleInfoText,imagePath);}


    private void PushTurnNumberIfStart(){
        string battleInfoText = string.Empty;
            battleInfoText = string.Format("Ход <color=yellow>{0} начат</color>",TURNNUMBER);
        battleInfoAdapter.AddItemToContent(battleInfoText,EndTurnPick);}

    
    private void PushTurnNumberIfEnd(){
        string battleInfoText = string.Empty;
            battleInfoText = string.Format("Ход <color=yellow>{0} окончен</color>",PREVIOUSTURNNUMBER);
        battleInfoAdapter.AddItemToContent(battleInfoText,EndTurnPick);}


    private void PushStartPhrase(){
        string battleInfoText = string.Empty;
            battleInfoText = "Сражение началось";
        battleInfoAdapter.AddItemToContent(battleInfoText,StartBattlePick);}

    private void PushEndBattlePhrase(string endPhrase){
        string battleInfoText = string.Empty;
            battleInfoText = "Сражение закончилось. " + endPhrase;
        battleInfoAdapter.AddItemToContent(battleInfoText,StartBattlePick);}


    public void PushAllEndTurnInfo(){
        PushTurnNumberIfEnd();//написать намер хода
        PushCostAbilitiesInfo(playerAbilitiesInfo,"Игрок");//проинформировать о времени срабатывания
        PushLuckAbilitiesInfo(playerAbilitiesInfo,"Игрок");
        PushCostAbilitiesInfo(opponenAbilitiesInfo,EnemySets.enemyName);//проинформировать о времени срабатывания
        PushLuckAbilitiesInfo(opponenAbilitiesInfo,EnemySets.enemyName);}


    private void SetBattleResults(){

    }
}
[Serializable]
public class BattlerAbilitySet{
    public List<Ability> attackAbilities;
    public int totalAttackDamage;
    public List<Ability> defenceAbilities;
    public int totalBlockedDamage;
    public List<Ability> luckAbilities;
    public List<Ability> costAbilities;
    public List<Ability> ultimateAbilities;
    public BattlerAbilitySet(){
        attackAbilities = new List<Ability>();
        defenceAbilities = new List<Ability>();
        luckAbilities = new List<Ability>();
        costAbilities = new List<Ability>();
        ultimateAbilities = new List<Ability>();}}