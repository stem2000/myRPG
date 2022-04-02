using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueViewAdapter : MonoBehaviour
{
    public RectTransform answersTextContent;
    public RectTransform dialogTextContent;
    private Dialogue dialogue;
    [SerializeField] private AnswerItem prefabAnwerItem;
    [SerializeField] private DialogueTextItem prefabDialogTextItem;

    public void OpenDialogView(){
        this.gameObject.GetComponent<DialogueViewAnimator>().openDialogueView();}

    public void LoadDialogueElements(Dialogue dialogue){
        this.dialogue = dialogue;}

    public void StartDialogue(){
        RefreshDialoguePanelFromNPC();
        RefreshAnswerPanel();}

    private void RefreshDialoguePanelFromNPC(){
        string textForNpc = string.Empty;

        if(dialogue.GetActualDescription() != string.Empty){
            DialogueTextItem decription = GameObject.Instantiate(prefabDialogTextItem);
            decription.gameObject.transform.SetParent(dialogTextContent,false);
            string textForDescription = string.Empty;

            textForDescription += "\t" + dialogue.GetActualDescription();
            decription.InitializeDialogueTextItem(textForDescription);}

        DialogueTextItem dialogueTI = GameObject.Instantiate(prefabDialogTextItem);
        dialogueTI.gameObject.transform.SetParent(dialogTextContent,false);
        textForNpc += "\t" + dialogue.npcName + ": " + dialogue.GetActualNpcText();
        dialogueTI.InitializeDialogueTextItem(textForNpc);}  


    public void RefreshDialogueTextFromUserAnswer(string answerText){
        string textForDTI = string.Empty;
        DialogueTextItem dialogueTI = GameObject.Instantiate(prefabDialogTextItem);
        dialogueTI.gameObject.transform.SetParent(dialogTextContent,false);
        dialogueTI.InitializeDialogueTextItem("\t" + "Я: " + answerText );}


    public void GoToNextNode(int nextNode){
        dialogue.currentNode = nextNode;
        RefreshDialoguePanelFromNPC();
         RefreshAnswerPanel();}


    public void RefreshAnswerPanel(){
        DestroysAnswers();
        Answer[] actualAnswers = dialogue.GetActualAnswers();

        foreach(Answer answer in actualAnswers){
            AnswerItem anwerItem = GameObject.Instantiate(prefabAnwerItem);
            anwerItem.gameObject.transform.SetParent(answersTextContent,false);
            anwerItem.InitializeAnwerItem(answer);}}


    public void DestroysAnswers(){
        foreach(Transform child in answersTextContent){
            Destroy(child.gameObject);}}


    public void DestroyDialogText(){
        foreach(Transform child in dialogTextContent){
            Destroy(child.gameObject);}}


    public void ClearDialogView(){
        DestroyDialogText();
        DestroysAnswers();}


    public void RefreshDialogView(){
        RefreshDialoguePanelFromNPC();
        RefreshAnswerPanel();}   

}
