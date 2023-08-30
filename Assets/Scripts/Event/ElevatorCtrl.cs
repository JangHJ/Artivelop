using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ElevatorCtrl : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime = 10f;

    SpriteRenderer renderer_;
    public GameObject ElevatorTab;
    public GameObject Player;
    public GameObject Camera;

    public BoxCollider2D bound_B1F;
    public BoxCollider2D bound_1F;
    public BoxCollider2D bound_2F;
    public BoxCollider2D bound_3F;

    public BoxCollider2D bound_TownB1F;
    public BoxCollider2D bound_Town1F;
    public BoxCollider2D bound_Town2F;

    public Flowchart fc_chat;

    public float TestTime = 1f;

    Animator EleveatorAnim;
    bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        renderer_ = gameObject.GetComponent<SpriteRenderer>();

        bound_B1F = GameObject.Find("B1F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_1F = GameObject.Find("1F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_2F = GameObject.Find("2F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_3F = GameObject.Find("3F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        
        //¸¶À» ¸Ê
        bound_TownB1F = GameObject.Find("Town_B1F").gameObject.GetComponent<BoxCollider2D>();
        bound_Town1F = GameObject.Find("Town_1F").gameObject.GetComponent<BoxCollider2D>();
        bound_Town2F = GameObject.Find("Town_2F").gameObject.GetComponent<BoxCollider2D>();
        
        Player = GameObject.Find("Pola");
        Camera = GameObject.Find("Main Camera");

        EleveatorAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                ElevatorTab.SetActive(true);
                fc_chat.SetBooleanVariable("isMove", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter = true;
            EleveatorAnim.SetBool("isEnter", true);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        EleveatorAnim.SetBool("isEnter", false);
        ElevatorTab.SetActive(false);
        if (coll.gameObject.tag == "Player")
            isEnter = false;
    }

    public void GoToFloorB1()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
        Camera.GetComponent<CameraManager>().SetBound(bound_B1F);
        Player.transform.position = new Vector2(0, -23.5f);
        Camera.transform.position = new Vector3(0, -22, -3);
        if (ElevatorTab.activeSelf == true)
        {
            ElevatorTab.SetActive(false);
        }
    }

    public void GoToFloor1()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
        Camera.GetComponent<CameraManager>().SetBound(bound_1F);
        Player.transform.position = new Vector2(0, -12.5f);
        Camera.transform.position = new Vector3(0, -11, -3);
        if (ElevatorTab.activeSelf == true)
        {
            ElevatorTab.SetActive(false);
        }
    }

    public void GoToFloor2()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
        Camera.GetComponent<CameraManager>().SetBound(bound_2F);
        Player.transform.position = new Vector2(0, -1.5f);
        Camera.transform.position = new Vector3(0, 0, -3);
        if (ElevatorTab.activeSelf == true)
        {
            ElevatorTab.SetActive(false);
        }
    }

    public  void GoToFloor3()
    {
        if (DataManager.instance.item_temp[2] == true)
        {
            Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove_3F");
            Camera.GetComponent<CameraManager>().SetBound(bound_3F);
            Player.transform.position = new Vector2(0, 9.5f);
            Camera.transform.position = new Vector3(0, 11, -3);
            if (ElevatorTab.activeSelf == true)
            {
                ElevatorTab.SetActive(false);
            }
        }
        else
        {
            Fungus.Flowchart.BroadcastFungusMessage("3F_CantMove");
        }
    }


    public void GoToVillage2F()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
        Camera.GetComponent<CameraManager>().SetBound(bound_Town2F);
        Player.transform.position = new Vector2(-43.5f, -64.8f);
        Camera.transform.position = new Vector3(-43.5f, -69.8f, -3);
        if (ElevatorTab.activeSelf == true)
        {
            ElevatorTab.SetActive(false);
        }
    }

    public void GoToVillage1F()
    {
        Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
        Camera.GetComponent<CameraManager>().SetBound(bound_Town1F);
        Player.transform.position = new Vector2(-3.6f, -84.8f);
        Camera.transform.position = new Vector3(-3.6f, -89.8f, -3);
        if (ElevatorTab.activeSelf == true)
        {
            ElevatorTab.SetActive(false);
        }
    }

    public void GoToVillageB1F()
    {
        if (DataManager.instance.item_temp[2] == true)
        {
            Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
            Camera.GetComponent<CameraManager>().SetBound(bound_TownB1F);
            Player.transform.position = new Vector2(-1.7f, -104.8f);
            Camera.transform.position = new Vector3(-1.7f, -109.8f, -3);
            if (ElevatorTab.activeSelf == true)
            {
                ElevatorTab.SetActive(false);
            }
        }
    }
   
}
