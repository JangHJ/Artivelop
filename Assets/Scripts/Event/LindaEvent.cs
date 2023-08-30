using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
public class LindaEvent : MonoBehaviour
{
    public GameObject Player;
    public GameObject Resistance;

    public Flowchart fc_chat;
    public Flowchart fc_event;

    // Start is called before the first frame update
    void Start()
    {
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");

        if (DataManager.instance.game_temp[5] == true && fc_event.GetIntegerVariable("minigame6") == 3)
        {
            Destroy(gameObject, 2f);
        }
        if (DataManager.instance.item_temp[21] == true)
        {
            Destroy(Resistance);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.GetChild(1).gameObject.activeSelf == true )
            GetComponent<BoxCollider2D>().enabled = true;
        if(DataManager.instance.game_temp[5] == true && DataManager.instance.item_temp[21] == false)
            GetComponent<BoxCollider2D>().enabled = true;

        if (fc_event.GetIntegerVariable("minigame6") == 1)
        {
            GetComponent<SpriteRenderer>().enabled = false; //�� �� ���� ���ֱ�
        }
        if (fc_event.GetIntegerVariable("minigame6") == 2 && DataManager.instance.game_temp[5] == false)
        {
            DataManager.instance.nowPlayer.pos = new Vector2(78, -64.8f);

            SceneManager.LoadScene("Minigame6");
        }
        if (fc_event.GetIntegerVariable("minigame6") == 3)
        {
            Destroy(Resistance);
            Destroy(gameObject);
        }

        if (fc_event.GetBooleanVariable("resistant_bullet") == true)
            Resistance.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (DataManager.instance.game_temp[5] == false)
            {
                Player.GetComponent<Animator>().SetBool("isWalking", false);
                Fungus.Flowchart.BroadcastFungusMessage("bulletEvent_ON"); //�����λ� �ϴ� ��ȭ
                Player.transform.GetChild(1).gameObject.SetActive(false); //������� ���� �����
                GetComponent<SpriteRenderer>().enabled = true; //�� �� ���� ��Ÿ���� �ϱ�
            }
            else
            {
                Player.GetComponent<SpriteRenderer>().flipX = false;
                Fungus.Flowchart.BroadcastFungusMessage("miniGame6_exit");
                //Destroy(gameObject,2f);
            }
        }
    }
}
