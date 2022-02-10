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
        scrollView.GetComponent<ScrollViewFunctional>().LoadItems(places_descriptions);}


    public void SetPlaces(TownPlaces tPlaces){ 
        town_places = tPlaces;
        places_descriptions = GenerateItemViewList(town_places);}


    private List<ItemViewDescription> GenerateItemViewList(TownPlaces places){
        if(places.places == null || places.places.Count == 0)
            return null;

        List<ItemViewDescription> itemViews = new List<ItemViewDescription>();
        foreach(TownPlace place in places.places){
            itemViews.Add(new ItemViewDescription(place.placeName,place.placeImage));
        }
        return itemViews;
    }
}


[System.Serializable]
public struct TownPlace
{
     [SerializeField]public string placeName;
     [SerializeField]public string placeImage;
}


[System.Serializable]
public struct TownPlaces
{ 
    [SerializeField]public List<TownPlace> places;

    public TownPlaces(List<TownPlace> places){ 
        this.places = places;}
}

