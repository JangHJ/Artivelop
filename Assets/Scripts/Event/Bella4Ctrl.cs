using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Bella4Ctrl : MonoBehaviour
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
        startPos1 = new Vector3(-3f, 9.5f, 0);
        startPos2 = new Vector3(3f, 9.5f, 0);
        targetPos = new Vector3(-17f, 9.5f, 0);

        gameObject.transform.position = startPos1;

        if (flowchart.GetBooleanVariable("bellaChat4") == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("bellaChat4") == true)
        {
            Destroy(gameObject);
        }

        if (Player.GetComponent<SpriteRenderer>().flipX == false && flowchart.GetIntegerVariable("isAnimation") != 5)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.position = startPos1;
        }
        else if (Player.GetComponent<SpriteRenderer>().flipX == true && flowchart.GetIntegerVariable("isAnimation") != 5)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.position = startPos2;
        }

        if (DataManager.instance.item_temp[21] == true)
        {
            renderer_.enabled = true;
            range.enabled = true;
        }
        else
        {
            renderer_.enabled = false;
            range.enabled = false;
        }

        if (flowchart.GetIntegerVariable("isAnimation") == 5)
        {
            renderer_.flipX = false;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
            bellaAnim.SetBool("isWalking", true);
            if (this.transform.position == targetPos)
            {
                gameObject.SetActive(false);
                bellaAnim.SetBool("isWalking", false);
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            polaAnim.SetBool("isWalking", false);
            Fungus.Flowchart.BroadcastFungusMessage("bella_talk4");
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            polaAnim.SetBool("isWalking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {

    }
}
