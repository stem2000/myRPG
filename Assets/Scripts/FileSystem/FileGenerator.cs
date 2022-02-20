using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileGenerator : MonoBehaviour
{
    public string fileName = "Doradur.json";
    public ItemsInfo placesToCreate;
    public bool flagCreation = true;
    public void Start()
    {   
        if(!flagCreation)
            return;

        string savePath = Path.Combine(Application.dataPath, fileName);
        string json = JsonUtility.ToJson(placesToCreate, true);
        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (Exception e)
        {
            Debug.Log("<color=red>FileSaveError: </color>ObjectFileManager => SavePlacesToFile():" + e.Message);
        }
    }
}
