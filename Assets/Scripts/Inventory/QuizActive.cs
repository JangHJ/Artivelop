using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizActive : MonoBehaviour
{
    public GameObject panel_bg;
    public GameObject quizTab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && DataManager.instance.item_temp[4] == true && quizTab.activeSelf == false)
        {
                panel_bg.SetActive(true);
                quizTab.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && DataManager.instance.item_temp[4] == true && quizTab.activeSelf == true)
        {
                panel_bg.SetActive(false);
                quizTab.SetActive(false);
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
