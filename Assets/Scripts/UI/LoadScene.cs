using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image loadBar;
    private static int sceneId = 1;
    
    void Start(){
        StartCoroutine(SceneLoader());}


    public static void GoToScene(int sceneNumber){
        sceneId = sceneNumber;
        SceneManager.LoadScene(0);}

    IEnumerator SceneLoader(){
         yield return new WaitForSeconds(0.5f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneId);
        asyncOperation.allowSceneActivation = false;
        while(asyncOperation.progress != 0.9f){
            loadBar.fillAmount = asyncOperation.progress;
            yield return new WaitForSeconds(0.01f);}
        loadBar.fillAmount = 1;
        asyncOperation.allowSceneActivation = true;}
}
