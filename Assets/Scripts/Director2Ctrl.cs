using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Director2Ctrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alarm;
    public string message;
    public int day;
    public Flowchart fc_chat;
    SpriteRenderer renderer_;
    private Animator polaAnim;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        Alarm = gameObject.transform.GetChild(0).gameObject;
        polaAnim = Player.gameObject.GetComponent<Animator>();

        if (DataManager.instance.item_temp[10] == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fc_chat.GetIntegerVariable("day") == 2 && DataManager.instance.item_temp[7] == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            Alarm.SetActive(true);
        }

        if (fc_chat.GetBooleanVariable("DirectorChat3_1") == true || DataManager.instance.item_temp[19] == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //polaAnim.SetBool("isWalking", false);
            fc_chat.SetBooleanVariable("isMove", false);
            Fungus.Flowchart.BroadcastFungusMessage(message);
            Alarm.SetActive(false);
        }
    }
}
