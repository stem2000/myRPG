using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInfoAdapter : MonoBehaviour
{
    [SerializeField] private BattleInfoItem battleInfoItemPrefab;
    [SerializeField] private RectTransform content;


    public void AddItemToContent(string text, string imagePath){
        BattleInfoItem item = GameObject.Instantiate(battleInfoItemPrefab);
        item.gameObject.transform.SetParent(content,false);
        item.InitializeBattleInfoItem(text,imagePath);
        StartCoroutine(WaitAFrame());}

    public void normalizeContent(){
        this.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;}
    
    private IEnumerator WaitAFrame(){
        yield return new WaitForEndOfFrame();
        normalizeContent();}
        
    public void DestroyItems(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}
}
