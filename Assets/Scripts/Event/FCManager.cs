using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FCManager : MonoBehaviour
{
    public GameObject Player;
    public Flowchart start_fc;
    
    // Start is called before the first frame update
    void Start()
    {
        start_fc = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();

        if (DataManager.instance.nowPlayer.pos == new Vector2(-13, 20))
        {
            Fungus.Flowchart.BroadcastFungusMessage("DirectorChat1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start_fc.GetBooleanVariable("isMove") == true)
        {
            Player.GetComponent<PlayerCtrl>().enabled = true;
        }
        else
        {
            Player.GetComponent<PlayerCtrl>().enabled = false;
            Player.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
