using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IItemBasicFunctional
{
    private ItemInfo itemInfo;
    
    public void SetItemInfo(ItemInfo itemInfo){
        this.itemInfo = itemInfo;}

    public ItemInfo GetItemInfo(){
        return itemInfo;}

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
