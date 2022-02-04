using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ToPlay(){ 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);}

    public void ToExit(){ 
        Application.Quit();}
}
