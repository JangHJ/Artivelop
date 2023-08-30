using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Zoom_Item2 : MonoBehaviour
{
    public GameObject Item;
    public GameObject Item_Zoom;
    public int item_num;
    public string message;
    public Flowchart fc_chat;
    public Flowchart fc_event;
    public int day;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (this.gameObject.activeSelf == true)
        {
            if (coll.gameObject.tag == "Player")
            {
                isEnter = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (this.gameObject.activeSelf == true)
        {
            if (coll.gameObject.tag == "Player")
            {
                isEnter = false;

                Item_Zoom.SetActive(false);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (fc_chat.GetIntegerVariable("day") == day)
        {
            Item.GetComponent<SpriteRenderer>().enabled = true;
            Item.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (DataManager.instance.item_temp[item_num] == false)
                    Fungus.Flowchart.BroadcastFungusMessage(message);

                DataManager.instance.item_temp[item_num] = true;
                Item_Zoom.SetActive(true);
            }
        }
    }
}
