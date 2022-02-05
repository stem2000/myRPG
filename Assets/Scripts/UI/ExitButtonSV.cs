using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonSV : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;

    public void closeScrollView(){ 
        scrollView.gameObject.SetActive(false);}
}
