using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battler : MonoBehaviour{
  public int hp;
  public int castPoints;
  private Text textHP;
  private Text textCastPoints;

    public void Awake(){
        textHP = gameObject.transform.Find("HpText").GetComponent<Text>();
        textCastPoints = gameObject.transform.Find("CpText").GetComponent<Text>();}


    private void SetHpText(string text){
        textHP.text = text;}


    private void SetCpText(string text){
        textCastPoints.text = text;}

    public void AddHp(int hp){
        this.hp += hp;
        SetHpText(this.hp.ToString());}

    public void SetCp(int cp){
        castPoints = cp;
        SetCpText(castPoints.ToString());}

    
}
