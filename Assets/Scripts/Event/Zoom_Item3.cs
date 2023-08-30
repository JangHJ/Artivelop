using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Zoom_Item3 : MonoBehaviour
{
    public GameObject Item;
    public GameObject Item_Zoom;
    public int item_num;
    public string message;
    public Flowchart fc_chat;
    public Flowchart fc_event;
    public int day;

    // Start is called before the first frame update
    void Start()
    {

        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Fungus.Flowchart.BroadcastFungusMessage(message);
            Item_Zoom.SetActive(true);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (fc_chat.GetIntegerVariable("day") != day && Item != null)
        {
            if (Item.GetComponent<SpriteRenderer>().isVisible)
                Item.GetComponent<SpriteRenderer>().enabled = false;
            Item.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (fc_chat.GetIntegerVariable("day") == day && Item != null)
        {
            Item.GetComponent<SpriteRenderer>().enabled = true;
            Item.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
