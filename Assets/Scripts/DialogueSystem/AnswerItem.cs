using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerItem : MonoBehaviour
{
    public Text answerTextUI;
    public Answer answer;

    public void Start(){

        var a = GameObject.Find("GeneralScrollView");
        this.gameObject.GetComponent<UIConnector>().scrollViewAdapter = 
            GameObject.Find("GeneralScrollView").GetComponent<ScrollViewAdapter>();

        this.gameObject.GetComponent<UIConnector>().dialogueViewAdapter = 
            GameObject.Find("DialogueView").GetComponent<DialogueViewAdapter>();

        this.gameObject.GetComponent<Button>().onClick.AddListener(() => 
            this.gameObject.GetComponent<UIConnector>().RefreshDialogFromAnswerButton());}

    public void InitializeAnwerItem(Answer answer){
        this.answer = answer;
        answerTextUI.text = answer.textAnswer;}
}
