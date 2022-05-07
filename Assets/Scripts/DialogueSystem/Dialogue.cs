using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot("dialogue")]
public class Dialogue{
    [XmlElement("node")]
    public Node[] nodes;
    [XmlElement("npcname")]
    public string npcName;
    [XmlElement("curnode")]
    public int currentNode;

    public string GetActualDescription(){
        return nodes[currentNode].textDesctiption;}

    public string GetActualNpcText(){
        return nodes[currentNode].npcText;}

    public Answer[] GetActualAnswers(){
        return nodes[currentNode].Answers;}

}


[System.Serializable]
public class Node{
    [XmlElement("description")]
    public string textDesctiption;
    [XmlElement("npctext")]
    public string npcText;
    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] Answers;
}


[System.Serializable]
public class Answer{
    [XmlElement("text")]
    public string textAnswer;
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("dialend")]
    public bool dialend;
    [XmlAttribute("questvalue")]
    public int questvalue;
    [XmlElement("needquestvalue")]
    public int needquestvalue;
     [XmlElement("questname")]
    public string questname;
    [XmlElement("enemyname")]
    public string enemyname;
    [XmlElement("altnodeifwin")]
    public int altnodeifwin;
    [XmlElement("altnodeiflose")]
    public int altnodeiflose;
}
