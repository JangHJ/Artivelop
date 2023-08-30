using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Bella2Ctrl : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D range;
    public Flowchart flowchart;
    private Animator bellaAnim;
    private Animator polaAnim;

    SpriteRenderer renderer_;
    public float moveSpeed; // 벨라 속도

    private Vector3 targetPos; // 도착 장소
    private Vector3 startPos1; // 시작 장소1
    private Vector3 startPos2; // 시작 장소2

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        polaAnim = Player.gameObject.GetComponent<Animator>();
        bellaAnim = gameObject.GetComponent<Animator>();
        renderer_ = gameObject.GetComponent<SpriteRenderer>();
        range = gameObject.GetComponent<BoxCollider2D>();
        startPos1 = new Vector3(-2.5f, -1.5f, 0); //왼쪽
        startPos2 = new Vector3(2.5f, -1.5f, 0); //오른쪽
        targetPos = new Vector3(-10f, -1.5f, 0);


        if (flowchart.GetIntegerVariable("bellaChat") >= 2)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX == false && flowchart.GetIntegerVariable("isAnimation") != 2)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.position = startPos1;
        }
        else if (Player.GetComponent<SpriteRenderer>().flipX == true && flowchart.GetIntegerVariable("isAnimation") != 2)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.position = startPos2;
        }

        if (flowchart.GetIntegerVariable("day") == 2)
        {
            renderer_.enabled = true;
            range.enabled = true;
        }

        if (flowchart.GetIntegerVariable("isAnimation") == 2)
        {
            if (flowchart.GetIntegerVariable("bellaChat") >= 2)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            polaAnim.SetBool("isWalking", false);
            flowchart.SetBooleanVariable("isMove", false);
            Fungus.Flowchart.BroadcastFungusMessage("bella_talk2");
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {

    }
}
