using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Bella1Ctrl : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D range;
    public Flowchart flowchart;
    private Animator bellaAnim;
    private Animator polaAnim;

    SpriteRenderer renderer_;
    public float moveSpeed; // ���� �ӵ�

    private Vector3 targetPos; // ���� ���
    private Vector3 startPos1; // ���� ���1
    private Vector3 startPos2; // ���� ���2

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

        targetPos = new Vector3(10.3f, -1.5f, 0);
        startPos1 = new Vector3(-2.5f, -1.5f, 0); //����
        startPos2 = new Vector3(2.5f, -1.5f, 0); //������

        if (flowchart.GetIntegerVariable("bellaChat") != 0 || DataManager.instance.item_temp[1] == true)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX == false && flowchart.GetIntegerVariable("isAnimation") != 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.position = startPos1;
        }
        else if (Player.GetComponent<SpriteRenderer>().flipX == true && flowchart.GetIntegerVariable("isAnimation") != 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.position = startPos2;
        }

        if (flowchart.GetBooleanVariable("bellaChat3_2") == true)
            Destroy(gameObject, 0.2f);
        if (flowchart.GetIntegerVariable("day") != 1)
        {
            renderer_.enabled = false;
            range.enabled = false;
        }

        if (flowchart.GetIntegerVariable("isAnimation") == 1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
            bellaAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;

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
        if (coll.gameObject.tag == "Player")
        {
            //Player.GetComponent<SpriteRenderer>().flipX = false;
            polaAnim.SetBool("isWalking", false);
            Fungus.Flowchart.BroadcastFungusMessage("bella_talk1");
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {

    }
}
