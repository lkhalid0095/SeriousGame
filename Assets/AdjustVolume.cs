using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    public Slider volumeSlider;
    AudioSource audioSource;
   

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = AudioListener.volume;
        if (!audioSource.playOnAwake)
        {
            
            audioSource.Play();
        }
    }
// Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void OnEnable()
    {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
        AudioListener.volume = sliderValue;
        PlayerPrefs.SetFloat("volume", sliderValue);
    }

}
