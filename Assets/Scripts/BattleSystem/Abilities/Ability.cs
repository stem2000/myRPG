using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability: MonoBehaviour{
    [SerializeField]protected int abilityActuationProbability;
    [SerializeField]protected string abilityPickPath;
    [SerializeField]protected string abilityName;
    [SerializeField]protected string id;
    protected int abilityCost;

    public string GetName(){
        return abilityName;}


    public string GetId(){
        return id;}


    public string GetPick(){
        return abilityPickPath;}


    public virtual int GetCastCost(){
        return abilityCost;}

    public void SetCastCost(int newCost){
        abilityCost = newCost;}

    public virtual void CalculateCastCost(){}

    protected virtual void Awake(){
        CalculateCastCost();}

}
