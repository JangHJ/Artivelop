using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Fungus;

public class GotoTitle : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);
        DataManager.instance.game_temp = new bool[7];
        DataManager.instance.item_temp = new bool[26];
        DataManager.instance.item_i_temp = new bool[24];
        DataManager.instance.item_s_temp = new bool[12];
        DataManager.instance.box_temp = new bool[12];
        Fungus.Flowchart.BroadcastFungusMessage("reset_key");
        DataManager.instance.DataClear();
    }
}
