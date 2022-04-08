using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battler : MonoBehaviour{
  private int hp = 100;
  private int cp = 100;
  private Text textHP;
  private Text textCastPoints;

    public void Awake(){
        textHP = gameObject.transform.Find("HpText").GetComponent<Text>();
        textCastPoints = gameObject.transform.Find("CpText").GetComponent<Text>();
        SetCpText(hp.ToString());
        SetHpText(cp.ToString());}


    private void SetHpText(string text){
        textHP.text = text;}


    private void SetCpText(string text){
        textCastPoints.text = text;}

    public void AddHp(int hp){
        this.hp += hp;
        SetHpText(this.hp.ToString());}

    public void TakeHp(int hp){
        this.hp -= hp;
        SetHpText(this.hp.ToString());}

    public void AddCp(int cp){
        this.cp += cp;
        SetCpText(this.cp.ToString());}

    public bool TakeCp(int cp){
        if(this.cp - cp < 0){
            return false;}
        this.cp -= cp;
        SetCpText(this.cp.ToString());
        return true;}

    
}
