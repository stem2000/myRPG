using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityButtonUI : MonoBehaviour
{
    private Image itemImage;
    private Text itemText;

    [SerializeField] private string defautPicture;


    public void Start(){
        itemImage = this.gameObject.GetComponent<Image>();
        itemText = this.gameObject.GetComponentInChildren<Text>();}

}
