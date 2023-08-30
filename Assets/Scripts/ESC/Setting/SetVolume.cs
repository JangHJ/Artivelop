using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    public Toggle toggle;
    public static float SliderValue;
    // Start is called before the first frame update


    public void Start()
    {
        slider.value = SliderValue;
        mixer.SetFloat("MusicVol", Mathf.Log10(slider.value) * 20);
    }
    
        
    
    public void SetLevel(float sliderValue)
    {
        
        if (toggle.isOn)
        {
            slider.value = 0.0001f;
        }
        mixer.SetFloat("MusicVol", Mathf.Log10(slider.value) * 20);
        Debug.Log("Volume Ω««‡¡ﬂ");
        SliderValue = slider.value;
    }
    
    // Update is called once per frame

}
