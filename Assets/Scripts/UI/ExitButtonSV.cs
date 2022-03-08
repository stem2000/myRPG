using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonSV : MonoBehaviour
{
    [SerializeField] private Animator svAnimator;

    public void closeScrollView(){ 
        svAnimator.SetBool("openScroll",false);}
}
