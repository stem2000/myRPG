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

    public void LoadItems(List<Tuple<ItemInfo,UIConnector>> items, UIConnector realObject){
        svAnimator.SetBool("openScroll",true);
        var abc = svAnimator.GetBool("openScroll");
        DestroyItems();
        foreach(Tuple<ItemInfo,UIConnector> item in items){
            ItemView itemView = GameObject.Instantiate(prefab);
            itemView.gameObject.transform.SetParent(content,false);
            itemView.InitializeItemView(item.Item1,item.Item2);}}

    public void DestroyItems(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}


}

