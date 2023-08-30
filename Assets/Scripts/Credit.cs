using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Credit : MonoBehaviour
{
    public GameObject creditImage;
    public GameObject Xbutton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopCredit()
    {
        creditImage.SetActive(true);
        Xbutton.SetActive(true);
    }

    public void DeleteCredit()
    {
        creditImage.SetActive(false);
        Xbutton.SetActive(false);
    }
}
