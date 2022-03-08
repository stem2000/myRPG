using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
public class ScrollViewAdapter : MonoBehaviour
{

    public ItemView prefab;
    public RectTransform content;

    [SerializeField] private Animator svAnimator;

    public void LoadItems(ItemsInfo items){
        svAnimator.SetBool("openScroll",true);
        var abc = svAnimator.GetBool("openScroll");
        Debug.Log("LoadItems");
        DestroyItems();
        foreach(ItemInfo item in items.objectsList){
            ItemView itemView = GameObject.Instantiate(prefab);
            itemView.gameObject.transform.SetParent(content,false);
            itemView.InitializeItemView(item);}
            Debug.Log("ItemInitialization");}//GetComponent???

    private void DestroyItems(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}


}

