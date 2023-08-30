using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class NickCtrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alarm;
    public Flowchart fc_event;
    public Flowchart fc_chat;

    SpriteRenderer renderer_;

    int count = 0;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        Alarm = gameObject.transform.GetChild(0).gameObject;
        renderer_ = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fc_chat.GetIntegerVariable("day") == 2 && GetComponent<SpriteRenderer>().enabled == false)
        {
            Alarm.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }

        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Alarm.SetActive(false);
                Fungus.Flowchart.BroadcastFungusMessage("nick_talk1");
                DataManager.instance.item_s_temp[1] = true;
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

            Alarm.SetActive(true);
        }
    }
}
