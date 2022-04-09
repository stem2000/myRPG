using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private AbilityViewAdapter abilityView;
    private AbilitiesContainer abilitiesContainer;
    private AbilityButtonUI abilityButtonUI;


    public void Start(){
        abilitiesContainer = this.gameObject.GetComponent<AbilitiesContainer>();
        abilityButtonUI = this.gameObject.GetComponent<AbilityButtonUI>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClickFunction);}


    public void LoadAbilitesToAbilitesView(){
        abilityView.LoadAbilities(abilitiesContainer.abilitiesForAbilityItem,this.gameObject.GetComponent<AbilitiesContainer>());}
    
    private void OnClickFunction(){
        LoadAbilitesToAbilitesView();}


}
