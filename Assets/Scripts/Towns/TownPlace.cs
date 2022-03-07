using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPlace: MonoBehaviour, IItemBasicFunctional
{
    private ItemInfo itemInfo;
    [HideInInspector] public List<QuestGiver> questGivers;
    public QuestGiver QuestGiverPrefab;

    void Start(){
        questGivers = new List<QuestGiver>();}

    public TownPlace(ItemInfo itemInfo){
        this.itemInfo = itemInfo;}


    public void SetItemInfo(ItemInfo itemInfo){
        this.itemInfo = itemInfo;}


    public ItemInfo GetItemInfo(){
        return itemInfo;}


    public void SetQuestGivers(ItemsInfo places){ 
        QuestGiver qGiver = null;
        foreach(ItemInfo itemInfo in places.objectsList){
            qGiver = GameObject.Instantiate(QuestGiverPrefab);
            qGiver.SetItemInfo(itemInfo);
            questGivers.Add(qGiver);}}
}
