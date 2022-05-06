using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public Animator svAnimator;
    public DialogueViewAnimator dvAnimator;
    public static bool scrollViewIsOpenened = false;
    public bool scrollViewIsClosed = true;
    public static bool dialogueViewIsOpen = false;
    public bool dialogueViewIsClosed = true;


    public void OpenCloseMenu(){
        if(menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(false);
        else
            menuPanel.gameObject.SetActive(true);}


    public void OpenSettingsMenu(){
            settingsPanel.gameObject.SetActive(true);}

    public void CloseSettingsMenu(){
        settingsPanel.gameObject.SetActive(false);}


    public void FixedUpdate(){
        if(scrollViewIsOpenened == false && scrollViewIsClosed == false){
            CloseScrollView();
            scrollViewIsClosed = true;}
        if(scrollViewIsOpenened && scrollViewIsClosed){
            OpenScrollView();
            scrollViewIsClosed = false;}
        if(dialogueViewIsOpen && dialogueViewIsClosed){
            OpenDialogueView();
            dialogueViewIsClosed = false;}
        if(dialogueViewIsOpen == false && dialogueViewIsClosed == false){
            CloseScrollView();
            dialogueViewIsClosed = true;}}
            

    public void ToExit(){ 
        Application.Quit();}


    public void CloseScrollView(){ 
        svAnimator.SetBool("openScroll",false);
        scrollViewIsOpenened = false;}


    public void OpenScrollView(){ 
        svAnimator.SetBool("openScroll",true);
        scrollViewIsOpenened = true;}


    public void OpenDialogueView(){ 
        dvAnimator.openDialogueView();
        if(scrollViewIsOpenened)
            CloseScrollView();}


    public void closeDialogueView(){ 
        dvAnimator.closeDialogueView();
        dialogueViewIsOpen = false;}

    public void ExitToMainMenu(){
        LoadScene.GoToScene(1);}
}
