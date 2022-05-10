using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ToStartNew(){ 
        PlayerPrefs.DeleteAll();
        LoadScene.GoToScene(2);}


    public void ToLoad(){ 
        LoadScene.GoToScene(2);}

    public void ToExit(){ 
        Application.Quit();}
}
