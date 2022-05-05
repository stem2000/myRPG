using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ToPlay(){ 
       LoadScene.GoToScene(2);}

    public void ToExit(){ 
        Application.Quit();}
}
