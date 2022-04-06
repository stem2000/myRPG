using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityViewAdapter : MonoBehaviour
{

    [SerializeField] private AbilityItem abilityItemPrefab;
    [SerializeField] private RectTransform content;


    public void LoadAbilities(List<Ability> abilitiesList){
        DestroyAbilities();
        foreach(Ability ability in abilitiesList){
            AddAbilityToContent(ability);}}


    public void AddAbilityToContent(Ability ability){
        AbilityItem item = GameObject.Instantiate(abilityItemPrefab);
        item.gameObject.transform.SetParent(content,false);
        item.InitializeAbilityItem(ability);}

    
    public void DestroyAbilities(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}
}
