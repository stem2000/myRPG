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
        UIManager.scrollViewIsOpenened = false;
        scrollViewAdapter.LoadItems(this.gameObject.GetComponent<IItemBasicFunctional>().getIncludedItems(),this);
        UIManager.scrollViewIsOpenened = true;}

    public void OpenDialogueViewFromPerson(){
        dialogueViewAdapter.LoadDialogueElements(this.gameObject.GetComponent<Person>().thisPersonDialogue);
        dialogueViewAdapter.OpenDialogView();
        dialogueViewAdapter.StartDialogue();
        UIManager.dialogueViewIsOpen = true;}

    public void RefreshDialogFromAnswerButton(){
        Answer currentAnswer = this.gameObject.GetComponent<AnswerItem>().answer;
        dialogueViewAdapter.AddAnswerTextToDialoguePanel(currentAnswer.textAnswer);
        dialogueViewAdapter.dlfGoToNextNode(currentAnswer.nextNode, currentAnswer.dialend);
        dialogueViewAdapter.dlfAddQuestValueToPlayerPrefs(currentAnswer);}


}
