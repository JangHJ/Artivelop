using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class EndingCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(0);
            DataManager.instance.game_temp = new bool[7];
            DataManager.instance.item_temp = new bool[26];
            DataManager.instance.item_i_temp = new bool[24];
            DataManager.instance.box_temp = new bool[12];
            DataManager.instance.item_s_temp = new bool[12];
            DataManager.instance.DataClear();
        }
    }
}
