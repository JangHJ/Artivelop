using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcChat : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alarm;
    public string message;
    public int item_num;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");

        Alarm = gameObject.transform.GetChild(0).gameObject;

       if (DataManager.instance.item_temp[item_num] == true)
       {
            Alarm.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
       }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKey(KeyCode.E) && coll.gameObject.tag == "Player")
        {
            Fungus.Flowchart.BroadcastFungusMessage(message);
            Alarm.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}