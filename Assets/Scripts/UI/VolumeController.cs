using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    private static string volumeKey = "volume";

    public void Awake(){
        if(PlayerPrefs.HasKey(volumeKey)){
            audioSource.volume = PlayerPrefs.GetFloat(volumeKey);
            volumeSlider.value = audioSource.volume;}
        else{
            audioSource.volume = 0.5f;
            volumeSlider.value = audioSource.volume;}}


    public void VolumeChange(){
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat(volumeKey,audioSource.volume);}

    
}
