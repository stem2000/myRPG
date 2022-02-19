using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour
{
    [SerializeField] public TownPlaces town_places;
    private List<ItemViewDescription> places_descriptions;
    [SerializeField] GameObject scrollView; 
    [SerializeField] GameObject contentPanel;
    
    public const string FILENAME = "Doradur.json";

    public string GetFileName(){ 
            return FILENAME;}


    private void OnMouseDown() {
        OpenScrollView();}


    private void OpenScrollView(){ 
        scrollView.gameObject.SetActive(true);
        scrollView.GetComponent<ScrollViewAdapter>().LoadItems(places_descriptions);}


    public void SetPlaces(TownPlaces tPlaces){ 
        town_places = tPlaces;
        places_descriptions = GenerateItemViewList(town_places);}


    private List<ItemViewDescription> GenerateItemViewList(TownPlaces places){
        List<ItemViewDescription> itemViews = new List<ItemViewDescription>();

        if(places.placesList == null || places.placesList.Count == 0)
            return itemViews;

        foreach(TownPlace place in places.placesList){
            itemViews.Add(new ItemViewDescription(place.placeName,place.placeImage,place.placeDescription,place.placeID));
        }
        return itemViews;
    }
}


[System.Serializable]
public struct TownPlace
{
     [SerializeField]public string placeName;
     [SerializeField]public string placeImage;
     [SerializeField]public string placeDescription;
     [SerializeField]public string placeID;
}


[System.Serializable]
public struct TownPlaces
{ 
    [SerializeField]public List<TownPlace> placesList;

    public TownPlaces(List<TownPlace> places){ 
        this.placesList = places;}
}

