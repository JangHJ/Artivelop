using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeZero : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPressButton()
    {
        slider.value = 0.0001f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
