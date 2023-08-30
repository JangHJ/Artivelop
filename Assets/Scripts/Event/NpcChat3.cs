using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcChat3 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ballon;
    public string NPCname;
    public string message;
    public Flowchart fc_chat;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        Player = GameObject.Find("Pola");
        Ballon = gameObject.transform.GetChild(0).gameObject;
        //Alarm = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                fc_chat.SetStringVariable("name", NPCname);
                Fungus.Flowchart.BroadcastFungusMessage(message);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                Ballon.SetActive(false);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            isEnter = false;
    }
}