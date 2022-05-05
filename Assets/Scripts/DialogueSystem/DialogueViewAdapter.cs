using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class DialogueViewAdapter : MonoBehaviour
{
    public RectTransform answersTextContent;
    public RectTransform dialogTextContent;
    [SerializeField] private AnswerItem prefabAnwerItem;
    [SerializeField] private DialogueTextItem prefabDialogTextItem;
    private Dialogue dialogue;
    [SerializeField] UnityEvent dvClose; 


    public void RebuildAnswerLayout(){
        LayoutRebuilder.ForceRebuildLayoutImmediate(answersTextContent);}
    public void OpenDialogView(){
        this.gameObject.GetComponent<DialogueViewAnimator>().openDialogueView();}

    public void LoadDialogueElements(Dialogue dialogue){
        this.dialogue = dialogue;}

    public void StartDialogue(){
        RefreshDialoguePanelFromNPC();
        RefreshAnswerPanel();}

    private void RefreshDialoguePanelFromNPC(){
        if(dialogue.GetActualDescription() != null){
           AddDescription();}
        AddNpcText();}  


    public void AddAnswerTextToDialoguePanel(string answerText){
        string textForDTI = string.Empty;
        DialogueTextItem dialogueTI = GameObject.Instantiate(prefabDialogTextItem);
        dialogueTI.gameObject.transform.SetParent(dialogTextContent,false);
        dialogueTI.InitializeDialogueTextItem("\t" + "Я: " + answerText );}


    public void dlfGoToNextNode(int nextNode,bool dialend){
        dialogue.currentNode = nextNode;
        if(dialend == true){
            EndDialogue();
            return;}
        RefreshDialoguePanelFromNPC();
        RefreshAnswerPanel();}

    
    public void dlfAddQuestValueToPlayerPrefs(Answer answer){
        if(answer.needquestvalue == PlayerPrefs.GetInt(answer.questname)){//если questname пустая строка вернеся defaultvalue
            PlayerPrefs.SetInt(answer.questname,answer.questvalue);}
            Debug.Log("Questname - " + answer.questname + " Playerprefs - " +  PlayerPrefs.GetInt(answer.questname));}


    public void RefreshAnswerPanel(){
        DestroyAnswers();
        Answer[] actualAnswers = dialogue.GetActualAnswers();
        foreach(Answer answer in actualAnswers){
            if(answer.questname == null || answer.needquestvalue == PlayerPrefs.GetInt(answer.questname)){
                AddAnswer(answer);}}
        RebuildAnswerLayout();}


    public void DestroyAnswers(){
        foreach(Transform child in answersTextContent){
            Destroy(child.gameObject);}}


    public void DestroyDialogText(){
        foreach(Transform child in dialogTextContent){
            Destroy(child.gameObject);}}


    public void ClearDialogView(){
        DestroyDialogText();
        DestroyAnswers();}


    public void RefreshDialogView(){
        RefreshDialoguePanelFromNPC();
        RefreshAnswerPanel();}   


    public void EndDialogue(){
        ClearDialogView();
        dvClose.Invoke();}


    public void AddDescription(){
            DialogueTextItem description = GameObject.Instantiate(prefabDialogTextItem);
            description.gameObject.transform.SetParent(dialogTextContent,false);
            string textForDescription = string.Empty;
            textForDescription += "\t<color=grey>" + dialogue.GetActualDescription() + "</color>";
            description.InitializeDialogueTextItem(textForDescription);}


    public void AddNpcText(){
        string textForNpc = string.Empty;
        DialogueTextItem dialogueTI = GameObject.Instantiate(prefabDialogTextItem);
        dialogueTI.gameObject.transform.SetParent(dialogTextContent,false);
        textForNpc += "\t" + dialogue.npcName + ": " + dialogue.GetActualNpcText();
        dialogueTI.InitializeDialogueTextItem(textForNpc);}


    public void AddAnswer(Answer answer){
        AnswerItem answerItem = GameObject.Instantiate(prefabAnwerItem);
        answerItem.gameObject.transform.SetParent(answersTextContent,false);
        answerItem.InitializeAnwerItem(answer);}
}

