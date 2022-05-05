using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;
    [SerializeField] private Animator svAnimator;
    [SerializeField] private DialogueViewAnimator dvAnimator;
    public static bool scrollViewIsOpenened = false;
    public bool scrollViewIsClosed = true;
    public static bool dialogueViewIsOpen = false;
    public bool dialogueViewIsClosed = true;
    public void OpenCloseMenu(){
        if(menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(false);
        else
            menuPanel.gameObject.SetActive(true);}


    public void FixedUpdate(){
        if(scrollViewIsOpenened == false && scrollViewIsClosed == false){
            closeScrollView();
            scrollViewIsClosed = true;}
        if(scrollViewIsOpenened && scrollViewIsClosed){
            openScrollView();
            scrollViewIsClosed = false;}
        if(dialogueViewIsOpen && dialogueViewIsClosed){
            openDialogueView();
            dialogueViewIsClosed = false;}
        if(dialogueViewIsOpen == false && dialogueViewIsClosed == false){
            closeScrollView();
            dialogueViewIsClosed = true;}}
            

    public void ToExit(){ 
        Application.Quit();}


    public void closeScrollView(){ 
        svAnimator.SetBool("openScroll",false);
        scrollViewIsOpenened = false;}


    public void openScrollView(){ 
        svAnimator.SetBool("openScroll",true);
        scrollViewIsOpenened = true;}


    public void openDialogueView(){ 
        dvAnimator.openDialogueView();
        if(scrollViewIsOpenened)
            closeScrollView();}


    public void closeDialogueView(){ 
        dvAnimator.closeDialogueView();
        dialogueViewIsOpen = false;}
}
