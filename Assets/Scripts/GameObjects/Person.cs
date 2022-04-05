using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
        [SerializeField] public Dialogue thisPersonDialogue;
        public TextAsset xmlDialog;

        public void Start(){
                thisPersonDialogue = FileManager.LoadXML(xmlDialog);}

}
