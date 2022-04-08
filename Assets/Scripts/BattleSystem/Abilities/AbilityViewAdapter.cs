using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityViewAdapter : MonoBehaviour
{

    [SerializeField] private AbilityItem abilityItemPrefab;
    [SerializeField] private RectTransform content;

    private AbilitiesContainer currentAbilitiesContainer;

    public void LoadAbilities(List<Ability> abilitiesList, AbilitiesContainer abilitiesContainer){
        currentAbilitiesContainer = abilitiesContainer;
        DestroyAbilities();
        foreach(Ability ability in abilitiesList){
            AddAbilityToContent(ability,currentAbilitiesContainer);}}


    public void AddAbilityToContent(Ability ability, AbilitiesContainer battleInformer){
        AbilityItem item = GameObject.Instantiate(abilityItemPrefab);
        item.gameObject.transform.SetParent(content,false);
        item.InitializeAbilityItem(ability,battleInformer);}

    
    public void DestroyAbilities(){
        foreach(Transform child in content){
            Destroy(child.gameObject);}}
}
