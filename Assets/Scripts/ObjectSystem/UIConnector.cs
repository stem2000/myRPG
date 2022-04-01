using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class UIConnector : MonoBehaviour
{
    public ScrollViewAdapter scrollViewAdapter;

    public void LoadItemsAtScrollView(){
        scrollViewAdapter.LoadItems(this.gameObject.GetComponent<IItemBasicFunctional>().getIncludedItems(),this);}

}
