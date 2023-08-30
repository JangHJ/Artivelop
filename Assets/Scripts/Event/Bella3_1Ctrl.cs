using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Bella3_1Ctrl : MonoBehaviour
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
        startPos1 = new Vector3(15f, -12.5f, 0); 
        targetPos = new Vector3(27.8f, -12.5f, 0);

        gameObject.transform.position = startPos1;

        if (DataManager.instance.item_temp[11] == true)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.instance.item_temp[10] == true)
        {
            renderer_.enabled = true;
            range.enabled = true;
        }
        if (DataManager.instance.item_temp[11] == true)
            Destroy(gameObject);

        if (flowchart.GetIntegerVariable("isAnimation") == 3)
        {
            renderer_.flipX = true;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
            bellaAnim.SetBool("isWalking", true);
            if (this.transform.position == targetPos)
            {
                gameObject.SetActive(false);
                bellaAnim.SetBool("isWalking", false);
                Destroy(gameObject);
            }
        }

        if (flowchart.GetBooleanVariable("bellaChat3_1") == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            polaAnim.SetBool("isWalking", false);
            Fungus.Flowchart.BroadcastFungusMessage("bella_talk3-1");
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {

    }
}
