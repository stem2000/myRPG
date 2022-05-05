using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceAbility : Ability{
    [SerializeField]private int abilityResistance;
    [SerializeField]private float defenceReduction;

    public override void CalculateCastCost(){
            abilityCost = abilityResistance*2/3 + (100-abilityActuationProbability)/3;}

    public override int GetCastCost(){
            return abilityCost;}

    public int CastDefenceAbility(int plusProbability){
            float probability = RandomGenerator.GenerateProbability();
            float proportion = probability/(abilityActuationProbability-plusProbability);
            if(proportion >= 1)
                return abilityResistance;
            else{ 
                float share = ((abilityActuationProbability-plusProbability-probability)/(defenceReduction*100f));
                return (int)(abilityResistance*share);}}

    protected override void Awake(){
         base.Awake();}
}
