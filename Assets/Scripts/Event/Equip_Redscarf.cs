using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Equip_Redscarf : MonoBehaviour
{
    public GameObject Player;
    public Flowchart fc_event;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
    }

    // Update is called once per frame
    void Update()
    {
        if (fc_event.GetBooleanVariable("RedScarf") == true)
            Destroy(gameObject);

        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Fungus.Flowchart.BroadcastFungusMessage("Equip_Redscarf");
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