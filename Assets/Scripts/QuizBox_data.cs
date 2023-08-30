using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBox_data : MonoBehaviour
{
    public GameObject[] boxLists;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 12; i++)
        {
            if (DataManager.instance.box_temp[i] == false)
            {
                boxLists[i].SetActive(true);
            }
            else
            {
                boxLists[i].SetActive(false);
            }
        }
    }
}
