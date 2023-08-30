using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Equip_Item : MonoBehaviour
{
    public GameObject Item;
    public int item_num;
    public string message;
    public Flowchart fc_chat;
    public Flowchart fc_event;
    public int day;
    public string item_name;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        day = 2;
        if (DataManager.instance.nowPlayer.item[item_num] == true || DataManager.instance.item_temp[item_num] == true)
        {
            Destroy(Item);
        }
        /*
        if (fc_event.GetBooleanVariable(item_name) == true)
        {
            Destroy(Item);
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                DataManager.instance.item_temp[item_num] = true;

                if (item_num == 0)
                {
                    DataManager.instance.item_s_temp[0] = true;
                }
                else if (item_num == 6)
                {
                    DataManager.instance.item_s_temp[1] = true;
                    Debug.Log("dkdkd");
                }
                else if (item_num == 7)
                {
                    DataManager.instance.item_s_temp[2] = true;
                }
                else if (item_num == 9)
                {
                    DataManager.instance.item_s_temp[3] = true;
                }
                else if (item_num == 10)
                {
                    DataManager.instance.item_s_temp[4] = true;
                }
                else if (item_num == 13)
                {
                    DataManager.instance.item_s_temp[5] = true;
                }
                else if (item_num == 15)
                {
                    DataManager.instance.item_s_temp[6] = true;
                }
                else if (item_num == 17)
                {
                    DataManager.instance.item_s_temp[7] = true;
                }
                else if (item_num == 18)
                {
                    DataManager.instance.item_s_temp[8] = true;
                }
                else if (item_num == 19)
                {
                    DataManager.instance.item_s_temp[9] = true;
                }
                else if (item_num == 22)
                {
                    DataManager.instance.item_s_temp[10] = true;
                }
                else if (item_num == 23)
                {
                    DataManager.instance.item_s_temp[11] = true;
                }

                Fungus.Flowchart.BroadcastFungusMessage(message);

                Destroy(Item, 1f);
            }
        }
        if (item_name == "SecurityCard")
        {
            if (fc_chat.GetIntegerVariable("samanthaChat") == 1)
            {
                Item.GetComponent<SpriteRenderer>().enabled = true;
                Item.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (fc_chat.GetIntegerVariable("day") == day)
        {
            Item.GetComponent<SpriteRenderer>().enabled = true;
            if (Item.transform.GetChild(0).gameObject != null)
                Item.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (DataManager.instance.nowPlayer.item[item_num] == true || DataManager.instance.item_temp[item_num] == true)
        {
            Destroy(Item);
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
