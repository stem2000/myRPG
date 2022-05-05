using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : Ability{
        [SerializeField]private int abilityDamage;
        [SerializeField]private float damageReduction;

        public override void CalculateCastCost(){
                abilityCost = abilityDamage + (100-abilityActuationProbability)/3;}

        public int CastAttackAbility(int plusProbability){
                float probability = RandomGenerator.GenerateProbability();
                float proportion = probability/(abilityActuationProbability-plusProbability);
                if(proportion >= 1)
                        return abilityDamage;
                else{ 
                        float share = ((abilityActuationProbability-plusProbability-probability)/(damageReduction*100f));
                        return (int)(abilityDamage*share);}}

        protected override void Awake(){
                base.Awake();}

}
