using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class UIConnector : MonoBehaviour
{
    public ScrollViewAdapter scrollViewAdapter;
    public DialogueViewAdapter dialogueViewAdapter;

    public void LoadItemsAtScrollView(){
        scrollViewAdapter.LoadItems(this.gameObject.GetComponent<IItemBasicFunctional>().getIncludedItems(),this);}

    public void OpenDialogueViewFromPerson(){
        dialogueViewAdapter.LoadDialogueElements(this.gameObject.GetComponent<Person>().thisPersonDialogue);
        dialogueViewAdapter.OpenDialogView();
        dialogueViewAdapter.StartDialogue();}

    public void RefreshDialogFromAnswerButton(){
        Answer currentAnswer = this.gameObject.GetComponent<AnswerItem>().answer;
        dialogueViewAdapter.RefreshDialogueTextFromUserAnswer(currentAnswer.textAnswer);
        dialogueViewAdapter.GoToNextNode(currentAnswer.nextNode);
        dialogueViewAdapter.RefreshAnswerPanel();}

}
