using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class RegiCtrl : MonoBehaviour
{
    public Flowchart fc_chat;
    public Flowchart fc_event;
    public GameObject Player;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.instance.item_temp[19] == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        else if (fc_chat.GetBooleanVariable("guard") == true || DataManager.instance.item_temp[20] == true)
            Destroy(gameObject);

        if (fc_event.GetIntegerVariable("minigame5") == 1 && DataManager.instance.game_temp[4] == false)
        {
            SceneManager.LoadScene("Minigame5");
        }
        else if (fc_event.GetIntegerVariable("minigame5") == 2 && DataManager.instance.game_temp[4] == true)
        {
            item.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && DataManager.instance.game_temp[4] == false)
        {
            //Player.GetComponent<Animator>().SetBool("isWalking", false);
            DataManager.instance.nowPlayer.pos = new Vector2(46, -84.8f);
            DataManager.instance.pos_temp = new Vector2(46, -84.8f);
            Fungus.Flowchart.BroadcastFungusMessage("miniGame5_enter");
        }
        else if (coll.gameObject.tag == "Player" && DataManager.instance.game_temp[4] == true)
        {
            Fungus.Flowchart.BroadcastFungusMessage("miniGame5_exit");
        }
    }
}
