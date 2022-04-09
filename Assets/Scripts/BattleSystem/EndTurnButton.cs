using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public BattleController battleController;

    public void Start(){
        this.gameObject.GetComponent<Button>().onClick.AddListener(EndTurn);}

    public void EndTurn(){
        battleController.EndTurn();}
}
