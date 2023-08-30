using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Director3_2Ctrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alarm;
    public string message;
    public int day;
    public Flowchart fc_chat;
    public Flowchart fc_event;
    SpriteRenderer renderer_;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        Alarm = gameObject.transform.GetChild(0).gameObject;

        if (fc_chat.GetBooleanVariable("DirectorChat3_2") == true || DataManager.instance.game_temp[5] == true || DataManager.instance.game_temp[6] == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.instance.item_temp[19] == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            Alarm.SetActive(true);
        }

        if (fc_chat.GetBooleanVariable("DirectorChat3_2") == true || DataManager.instance.game_temp[5] == true || DataManager.instance.game_temp[6] == true)
        {
            Destroy(gameObject);
        }

        if (fc_chat.GetBooleanVariable("DirectorChat3_2") == true && fc_event.GetBooleanVariable("guard") == true)
        {
            Player.transform.position = new Vector2(-77f, -64.8f);
            Player.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(gameObject);
        }

        else if (fc_chat.GetBooleanVariable("DirectorChat3_2") == true && fc_event.GetBooleanVariable("guard") == false)
        {
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Player.GetComponent<Animator>().SetBool("isWalking", false);
        Fungus.Flowchart.BroadcastFungusMessage(message);
        Alarm.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        Alarm.SetActive(true);
    }
}
