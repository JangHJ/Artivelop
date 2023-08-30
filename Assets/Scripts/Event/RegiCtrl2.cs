using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class RegiCtrl2 : MonoBehaviour
{
    public Flowchart fc_chat;
    public Flowchart fc_event;
    public GameObject Player;
    //public GameObject item;
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
      

    }
}
