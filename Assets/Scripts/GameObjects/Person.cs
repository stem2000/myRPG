using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
        [SerializeField] public Dialogue thisPersonDialogue;
        public TextAsset xmlDialog;

        public void Start(){
                thisPersonDialogue = Dialogue.Load(xmlDialog);
                foreach(Node node in thisPersonDialogue.nodes){
                        Debug.Log("description - " + node.textDesctiption);
                        Debug.Log("npctext - " + node.npcText);}}

}
