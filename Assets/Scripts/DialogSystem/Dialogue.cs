using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour{
    public DialogueNode[] nodes;
    public int currentNode;
}

[System.Serializable]
public class DialogueNode{
    public string npcText;
}

[System.Serializable]
public class Answer{
    public string textAnswer;
    public int nextNode;
    public bool speakEnd;
}
