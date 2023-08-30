using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcChat2 : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Alarm;
    public string message;
    public int item_num;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");

        //Alarm = gameObject.transform.GetChild(0).gameObject;

       if (DataManager.instance.item_temp[item_num] == true)
       {
            //Alarm.SetActive(false);
            Destroy(gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Fungus.Flowchart.BroadcastFungusMessage(message);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}