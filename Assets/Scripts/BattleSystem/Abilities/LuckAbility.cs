using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckAbility : Ability
{
    [SerializeField] private int luckIncrease;
    [SerializeField] private string abilityForAplyId;
    [SerializeField] private int turnsBeforeAply;
    private int playingTurn;

    public void SetPlayingTurn(int currentTurn){
        playingTurn = currentTurn + turnsBeforeAply;}
    
    public int CastAbility(string abilityId,int currentTurn){
       if(currentTurn == playingTurn && this.abilityForAplyId == abilityId)
            return luckIncrease;
        return 0;}


    protected override void Awake(){
         base.Awake();}

}
