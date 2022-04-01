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
     [SerializeField]public string id; 
     [SerializeField]public string type; 

     public ItemInfo(string name, string imagePath, string description, string filename, string id, string type){
          this.name = name;
          this.imagePath = imagePath;
          this.description = description;
          this.filename = filename;
          this.id = id;
          this.type = type;}

}

