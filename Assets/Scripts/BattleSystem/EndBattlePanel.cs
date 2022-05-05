using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBattlePanel : MonoBehaviour
{
    public void OpenCloseEndBattlePanel(){
        if(this.gameObject.activeSelf)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);}


    public void RestartBattle(){
        LoadScene.GoToScene(3);}

    public void ExitFromBatle(){
        LoadScene.GoToScene(2);}
        
}
