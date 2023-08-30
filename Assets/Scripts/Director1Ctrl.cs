using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Director1Ctrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alarm;
    public string message;
    public int day;
    bool isEnter;
    SpriteRenderer renderer_;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");
        Alarm = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage(message);
                Alarm.SetActive(false);
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
        Alarm.SetActive(true);
        isEnter = false;
    }
}
