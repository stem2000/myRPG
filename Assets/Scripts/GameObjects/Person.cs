using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
        [SerializeField] public Dialogue thisPersonDialogue;
        public TextAsset xmlDialog;

        public void Start(){
                thisPersonDialogue = FileManager.Load(xmlDialog);
                foreach(Node node in thisPersonDialogue.nodes){
                        foreach(Answer answer in node.Answers){
                                Debug.Log(answer.questname);
                                Debug.Log(answer.needquestvalue);
                                Debug.Log(answer.questvalue);}}}

}
