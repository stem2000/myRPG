using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour
{
    [SerializeField] public List<TownPlace> townPlaces;
    [SerializeField] private ObjectManager objectManager;
    public string fileName = "";
    private List<ItemInfo> places_descriptions;

    [SerializeField] GameObject scrollView; 
    private ScrollViewAdapter scrollViewAdapter;
    [SerializeField] GameObject contentPanel;


    void Start(){
        scrollViewAdapter = scrollView.GetComponent<ScrollViewAdapter>();
        townPlaces = new List<TownPlace>();}
    
    public string GetFileName(){ 
            return fileName;}


    private void OnMouseDown() {
        OpenScrollView();}


    private void OpenScrollView(){ 
        scrollView.gameObject.SetActive(true);
        scrollViewAdapter.LoadItems(GetItems());}


    public void SetPlaces(ItemsInfo places){ 
        foreach(ItemInfo tPlace in places.objectsList){
            townPlaces.Add(new TownPlace(tPlace));}}

        
    public ItemsInfo GetItems(){
        ItemsInfo items;
        items.objectsList = new List<ItemInfo>();
        foreach(TownPlace item in townPlaces){
            items.objectsList.Add(item.GetItemInfo());}
        return items;}

}



