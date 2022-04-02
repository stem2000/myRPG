using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTextItem : MonoBehaviour
{
  public void InitializeDialogueTextItem(string text){
      this.gameObject.GetComponent<Text>().text = text;}
}
