using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Equip_Doughnut : MonoBehaviour
{
    public GameObject NightDutyRoom;
    public GameObject Doughnut;
    public int item_num;
    bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        item_num = 1; //»ç¸¸´Ù µµ³Ó
        NightDutyRoom = GameObject.Find("1F_Hallway").gameObject.transform.GetChild(1).gameObject;
        Doughnut = NightDutyRoom.transform.GetChild(2).gameObject;

    }
    // Update is called once per frame
    void Update()
    {
        if (DataManager.instance.nowPlayer.item[item_num] == true)
        {
            Destroy(Doughnut);
        }

        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E) && DataManager.instance.item_temp[item_num] == false)
            {
                Destroy(Doughnut);
                DataManager.instance.item_temp[item_num] = true;
                Fungus.Flowchart.BroadcastFungusMessage("Equip_Doughnut");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter = false;
        }
    }

}
