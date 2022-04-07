using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesContainer : MonoBehaviour
{
    [SerializeField]public List<Ability> abilitiyPrefabs;
    public List<Ability> abilities;
    public void Start(){
        abilities.Clear();
        foreach(Ability ability in abilitiyPrefabs){
            abilities.Add(Instantiate(ability));}}
}
