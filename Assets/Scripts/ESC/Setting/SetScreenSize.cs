using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScreenSize : MonoBehaviour
{
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            Screen.SetResolution(1920, 1080,true);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }
}
