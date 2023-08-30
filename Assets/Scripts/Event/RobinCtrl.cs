using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RobinCtrl : MonoBehaviour
{
    public GameObject Player;
    public Flowchart fc_chat;
    private Animator polaAnim;

    // Start is called before the first frame update
    void Start()
    {
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        polaAnim = Player.gameObject.GetComponent<Animator>();

        if (fc_chat.GetBooleanVariable("robinChat") == true || fc_chat.GetIntegerVariable("day") >= 2)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fc_chat.GetIntegerVariable("samanthaChat") == 1 && DataManager.instance.item_temp[1] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (fc_chat.GetBooleanVariable("robinChat") == true || fc_chat.GetIntegerVariable("day") >= 2)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player" && fc_chat.GetBooleanVariable("robinChat") == false)
        {
            Fungus.Flowchart.BroadcastFungusMessage("Robin_talk");
            transform.GetChild(0).gameObject.SetActive(false);
            polaAnim.SetBool("isWalking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {

    }
}
