using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEvent : MonoBehaviour
{
    public GameObject Player;
    public GameObject Linda;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");
        Linda = Player.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("bulletEvent_ON");
        Linda.transform.position = new Vector2(2, 0.2f);
        Linda.GetComponent<SpriteRenderer>().flipX = true;

        Destroy(gameObject);
    }
}
