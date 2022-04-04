using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue{
    [XmlElement("node")]
    public Node[] nodes;
    [XmlElement("npcname")]
    public string npcName;
    [XmlElement("curnode")]
    public int currentNode;

    public static Dialogue Load(TextAsset _xml){
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue dialogue = serializer.Deserialize(reader) as Dialogue;
        return dialogue;}


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
}
