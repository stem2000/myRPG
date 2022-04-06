using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability: MonoBehaviour{
    [SerializeField]private int abilityRandom;
    [SerializeField]private string abilityPickPath;
    [SerializeField]private string abilityName;

    public string GetName(){
        return abilityName;}


    public string GetPick(){
    return abilityPickPath;}

}



public class SpecialEffect{

}


public class AttackEffect:SpecialEffect{

}