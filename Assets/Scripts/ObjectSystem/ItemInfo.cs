using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemInfo
{
     [SerializeField]public string name;
     [SerializeField]public string imagePath;
     [SerializeField]public string description;
     [SerializeField]public string filename;

     public ItemInfo(string name, string imagePath, string description, string filename){
          this.name = name;
          this.imagePath = imagePath;
          this.description = description;
          this.filename = filename;}

}

[System.Serializable]
public struct ItemsInfo
{ 
    [SerializeField]public List<ItemInfo> objectsList;

    public ItemsInfo(List<ItemInfo> objects){ 
        this.objectsList = objects;}
}

