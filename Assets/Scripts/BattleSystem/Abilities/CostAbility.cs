using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostAbility : Ability
{
    [SerializeField] private int costDecrease;
    [SerializeField] private string abilityForAplyID;
    [SerializeField] private int turnsBeforeAply;
    private int playingTurn;

    public override void CalculateCastCost(){
        abilityCost = costDecrease * 5 / 2;}
    
    public int GetPlayingTurn(){
        return playingTurn;}
 
    public void SetPlayingTurn(int currentTurn){
        playingTurn = currentTurn + turnsBeforeAply;}
    
    public int CastAbility(string abilityId,int currentTurn){
       if(currentTurn == playingTurn && abilityForAplyID.Equals(abilityId))
            return costDecrease;
        return 0;}

     protected override void Awake(){
         base.Awake();}
}
