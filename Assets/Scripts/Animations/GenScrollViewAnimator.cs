using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenScrollViewAnimator : MonoBehaviour
{
    [SerializeField] private Animator svAnimator;
    

    public void openScrollView(){
        if(!svAnimator.GetBool("openScroll"))
            svAnimator.SetBool("openScroll",true);}

    public void closeScrollView(){
        svAnimator.SetBool("openScroll",false);}
}
