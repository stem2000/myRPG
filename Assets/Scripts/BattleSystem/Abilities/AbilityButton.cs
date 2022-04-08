using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AbilityButton : MonoBehaviour
{
    [System.Serializable]
    public class CancelAbilityEvent:UnityEvent<AbilitiesContainer>{}
    [SerializeField]public CancelAbilityEvent cancelAbility;
    [SerializeField] private AbilityViewAdapter abilityView;
    private AbilitiesContainer abilitiesContainer;
    private AbilityButtonUI abilityButtonUI;


    public void Start(){
        abilitiesContainer = this.gameObject.GetComponent<AbilitiesContainer>();
        abilityButtonUI = this.gameObject.GetComponent<AbilityButtonUI>();
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClickFunction);}


    public void LoadAbilitesToAbilitesView(){
        abilityView.LoadAbilities(abilitiesContainer.abilities,this.gameObject.GetComponent<AbilitiesContainer>());}

    
    public void MakeAbilityCancellation(){
        cancelAbility.Invoke(abilitiesContainer);}
    
    private void OnClickFunction(){
        if(abilitiesContainer.activeAbility == null){
            LoadAbilitesToAbilitesView();}
        else{
           MakeAbilityCancellation();}}


}
