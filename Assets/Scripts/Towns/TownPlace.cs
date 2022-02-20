using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPlace
{
    private ItemInfo placeInfo;

    public TownPlace(ItemInfo placeInfo){
        this.placeInfo = placeInfo;}

    public void SetItemInfo(ItemInfo placeInfo){
        this.placeInfo = placeInfo;}

    public ItemInfo GetItemInfo(){
        return placeInfo;}

    
}
