using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability: MonoBehaviour{
    [SerializeField]protected int abilityActuationProbability;
    [SerializeField]protected string abilityPickPath;
    [SerializeField]protected string abilityName;
    protected int abilityCost;

    public string GetName(){
        return abilityName;}


    public string GetPick(){
        return abilityPickPath;}


    public virtual int GetCastCost(){
        return 0;}

    public virtual void CalculateCastCost(){}

    protected virtual void Start(){
        CalculateCastCost();}

}
