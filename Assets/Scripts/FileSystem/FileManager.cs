using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml.Serialization;

public class FileManager
{
    public static void SaveToFile(System.Object dataForSave, string fileName){ 

        string savePath = Path.Combine(Application.dataPath,fileName);
        string json = JsonUtility.ToJson(dataForSave,true);
        
        try{
            File.WriteAllText(savePath,json);}
        catch(Exception e){ 
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => SavePlacesToFile():" + e.Message);}}

   
    public static String LoadFromFile(string fileName){ 

        string savePath = Path.Combine(Application.dataPath,fileName);

        if(!File.Exists(savePath)){ 
            Debug.Log("<color=red>FileNotFound:</color>ObjectFileManager => LoadPlacesFromFile():" + fileName);
                return String.Empty;}

        try{
            string json = File.ReadAllText(savePath);
                return json;}
        catch(Exception e){ 
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => LoadPlacesFromFile():" + e.Message);
            return String.Empty;}}


    public static ItemInfo ConvertJsonToItemInfo(string json){
        if(json != String.Empty){
            ItemInfo objectDescription = JsonUtility.FromJson<ItemInfo>(json);
                return objectDescription;}
        return new ItemInfo();}


    public static Dialogue Load(TextAsset _xml){
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue dialogue = serializer.Deserialize(reader) as Dialogue;
        return dialogue;}



}
