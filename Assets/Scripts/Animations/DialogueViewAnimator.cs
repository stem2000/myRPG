using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueViewAnimator : MonoBehaviour
{
    [SerializeField] private Animator svAnimator;
    

    public void openDialogueView(){
        if(!svAnimator.GetBool("isOpen"))
            svAnimator.SetBool("isOpen",true);}

    public void closeDialogueView(){
        svAnimator.SetBool("isOpen",false);}
}
