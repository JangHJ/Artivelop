using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC_Active : MonoBehaviour
{
    public GameObject panel_bg;
    public GameObject escMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escMenu.activeSelf == false)
        {
            panel_bg.SetActive(true);
            escMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escMenu.activeSelf == true)
        {
            panel_bg.SetActive(false);
            escMenu.SetActive(false);
        }


        /*if (Input.GetKey(KeyCode.Tab))
        {
            if (active == false)
            {
                tabMenu.SetActive(true);
                active = true;
            }
            else
            {
                tabMenu.SetActive(false);
                active = false;
            }
        }*/
    }

}
