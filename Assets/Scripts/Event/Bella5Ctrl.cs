using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Bella5Ctrl : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D range;
    public Flowchart flowchart;
    public Flowchart fc_event;
    private Animator bellaAnim;
    private Animator polaAnim;

    SpriteRenderer renderer_;
    public float moveSpeed; // 벨라 속도

    private Vector3 targetPos; // 도착 장소
    private Vector3 startPos1; // 시작 장소1

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        polaAnim = Player.gameObject.GetComponent<Animator>();
        bellaAnim = gameObject.GetComponent<Animator>();
        renderer_ = gameObject.GetComponent<SpriteRenderer>();
        range = gameObject.GetComponent<BoxCollider2D>();
        startPos1 = new Vector3(-8.8f, 20f, 0);
        targetPos = new Vector3(-19f, 20, 0);

        gameObject.transform.position = startPos1;
    }

    // Update is called once per frame
    void Update()
    {

        if (fc_event.GetBooleanVariable("GotoGR") == true)
        {
            renderer_.enabled = true;
            range.enabled = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            polaAnim.SetBool("isWalking", false);
            Fungus.Flowchart.BroadcastFungusMessage("bella_talk5");
    
        }
    }
}
