using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private AbilityViewAdapter abilityView;
    private AbilitiesContainer abilitiesContainer;


    public void Start(){
        abilitiesContainer = this.gameObject.GetComponent<AbilitiesContainer>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(LoadAbilitesToAbilitesView);}


    public void LoadAbilitesToAbilitesView(){
        abilityView.LoadAbilities(abilitiesContainer.abilities,this.gameObject.GetComponent<AbilityTargetLinker>());}
    

}
