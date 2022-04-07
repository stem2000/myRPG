using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : Ability{
        [SerializeField]private int abilityDamage;

        public override void CalculateCastCost(){
                abilityCost = abilityDamage/2 + abilityActuationProbability/3;}

        public override int GetCastCost(){
                return abilityCost;}

        protected override void Start(){
                base.Start();}

}
