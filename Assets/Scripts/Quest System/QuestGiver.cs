using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] GameObject scrollView; // townPlacesPanel
    

    public void OnMouseDown() {
        openScrollView();}


    public void openScrollView(){ 
        scrollView.gameObject.SetActive(true);}
}
