using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour
{
    [SerializeField] public List<TownPlace> townPlaces;
    [SerializeField] GameObject scrollView; 
    [SerializeField] private TownPlace townPlacePrefab;
    public string placesFileLocation = "";
    private List<ItemInfo> places_descriptions;
    private ScrollViewAdapter scrollViewAdapter;


    void Start(){
        townPlaces = new List<TownPlace>();}
    

    public string GetPlacesFileLocation(){ 
            return placesFileLocation;}


    private void OnMouseDown() {
        OpenScrollView();}


    private void OpenScrollView(){ 
        scrollView.gameObject.SetActive(true);
        scrollViewAdapter.LoadItems(GetItems());}


    public void SetPlaces(ItemsInfo places){ 
        TownPlace tPlace = null;
        foreach(ItemInfo itemInfo in places.objectsList){
            tPlace = GameObject.Instantiate(townPlacePrefab);
            tPlace.SetItemInfo(itemInfo);
            townPlaces.Add(tPlace);}}

        
    public ItemsInfo GetItems(){
        ItemsInfo items;
        items.objectsList = new List<ItemInfo>();
        foreach(TownPlace tPlace in townPlaces){
            items.objectsList.Add(tPlace.GetItemInfo());}
        return items;}
}


interface IItemBasicFunctional{
    public void SetItemInfo(ItemInfo itemInfo);
    public ItemInfo GetItemInfo();}



