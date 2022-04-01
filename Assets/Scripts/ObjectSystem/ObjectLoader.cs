using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{
    private ObjectDescriptor objectDescriptor;
    private string fileName;
    void Start(){
        objectDescriptor = this.gameObject.GetComponent<ObjectDescriptor>();
        fileName = objectDescriptor.objectDescription.filename;
        loadObject();}

    public void loadObject(){
        string jsonDesc = FileManager.LoadFromFile(fileName);
        if(jsonDesc != string.Empty){
            objectDescriptor.objectDescription = FileManager.ConvertJsonToItemInfo(jsonDesc);}
        else{
            FileManager.SaveToFile(objectDescriptor.objectDescription,fileName);}}

}
