using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMouseDown()
    {
        a.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
