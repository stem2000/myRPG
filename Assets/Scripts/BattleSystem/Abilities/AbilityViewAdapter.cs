using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityViewAdapter : MonoBehaviour
{

    [SerializeField] private AbilityItem abilityItemPrefab;
    [SerializeField] private RectTransform content;
    private AbilityTargetLinker atLinker;

    public void LoadAbilities(List<Ability> abilitiesList, AbilityTargetLinker atLinker){
        this.atLinker = atLinker;
        DestroyAbilities();
        foreach(Ability ability in abilitiesList){
            AddAbilityToContent(ability);}}


    public void AddAbilityToContent(Ability ability){
        AbilityItem item = GameObject.Instantiate(abilityItemPrefab);
        item.gameObject.transform.SetParent(content,false);
        item.InitializeAbilityItem(ability,atLinker);}

    
    public void DestroyAbilities(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}
}
