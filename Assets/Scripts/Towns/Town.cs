using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour
{
    [SerializeField] public TownPlaces town_places;
    [SerializeField] GameObject scrollView; 
    [SerializeField] GameObject contentPanel;
    
    public const string FILENAME = "Doradur.json";

    public string GetFileName(){ 
            return FILENAME;}


    public void OnMouseDown() {
        openScrollView();}


    public void openScrollView(){ 
        scrollView.gameObject.SetActive(true);}


    public void SetPlaces(TownPlaces tPlaces){ 
        town_places = tPlaces;}
}


[System.Serializable]
public struct TownPlace
{
     [SerializeField]public string placeName;
     [SerializeField]public string placePict;
}


[System.Serializable]
public struct TownPlaces
{ 
    [SerializeField]public List<TownPlace> places;

    public TownPlaces(List<TownPlace> places){ 
        this.places = places;}
}

