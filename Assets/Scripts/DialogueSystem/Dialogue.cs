using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue{
    public DialogueNode[] nodes;
    public string npcName;
    public int currentNode;

    public string GetActualDescription(){
        return nodes[currentNode].textDesctiption;}

    public string GetActualNpcText(){
        return nodes[currentNode].npcText;}

    public Answer[] GetActualAnswers(){
        return nodes[currentNode].playerAnswers;}

}


[System.Serializable]
public class DialogueNode{
    public string textDesctiption;
    public string npcText;
    public Answer[] playerAnswers;
}


[System.Serializable]
public class Answer{
    public string textAnswer;
    public int nextNode;
    public bool speakEnd;
}
