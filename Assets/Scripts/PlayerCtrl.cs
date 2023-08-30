using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    //public GameManager manager;
    public GameObject gown;
    public float moveForce = 5f;
    private Animator polaAnim;
    AudioSource audioSrc;
    SpriteRenderer renderer_;
    GameObject Camera;
    GameObject Linda;
    public GameObject Linda2;
    public Image playerposition_b;
    public Image playerposition_t;
    Rigidbody2D rb;
    bool idle_bool;
    public Flowchart fc_event;

    public BoxCollider2D bound_1F;
    public BoxCollider2D bound_2F;
    public BoxCollider2D bound_3F;
    public BoxCollider2D bound_B1F;
    public BoxCollider2D bound_DO;

    public BoxCollider2D bound_TownB1F;
    public BoxCollider2D bound_Town1F;
    public BoxCollider2D bound_Town2F;

    //¸¶À» °Ç¹°
    public BoxCollider2D AngelaClinic;
    public BoxCollider2D RileyKitchen;
    public BoxCollider2D DubiumDining;
    public BoxCollider2D House3;
    public BoxCollider2D Stancebar;
    public BoxCollider2D Casino;

    public BoxCollider2D dormitory;
    public BoxCollider2D DirectorOffice;
    public BoxCollider2D Forbidden_Lab;
    public BoxCollider2D Forbidden_Office;

    //°ü¸®±¹ 3Ãþ ¹æ
    public BoxCollider2D ConferenceRoom;
    public BoxCollider2D LockerRoom;
    public BoxCollider2D Lab1;
    public BoxCollider2D Lab2;
    public BoxCollider2D DataStorage;

    //°ü¸®±¹ 2Ãþ ¹æ
    public BoxCollider2D BreakRoom;
    public BoxCollider2D TrainingRoom;
    public BoxCollider2D Infirmary;
    public BoxCollider2D PhysicalRoom;
    
    //°ü¸®±¹ 2Ãþ ±â¼÷»ç
    public BoxCollider2D BellaRoom;
    public BoxCollider2D PolaRoom;

    //°ü¸®±¹ 1Ãþ ¹æ
    public BoxCollider2D NightDutyRoom;
    public BoxCollider2D SecurityRoom;

    //°ü¸®±¹ B1Ãþ ¹æ
    public BoxCollider2D ChimeraLab;
    public BoxCollider2D ChimeraIncubation;
    public BoxCollider2D AnimalBreeding;

    public Sprite spr1;
    public Sprite spr2;

    // Start is called before the first frame update
    void Start()
    {
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        idle_bool = true;
        polaAnim = gameObject.GetComponent<Animator>();
        renderer_ = gameObject.GetComponent<SpriteRenderer>();
        audioSrc = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        Camera = GameObject.Find("Main Camera");
        Linda = gameObject.transform.GetChild(1).gameObject;
        renderer_.flipX = false;

        //°ü¸®±¹ ¸Ê
        bound_1F = GameObject.Find("1F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_2F = GameObject.Find("2F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_3F = GameObject.Find("3F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_B1F = GameObject.Find("B1F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_DO = GameObject.Find("DO_Hallway").gameObject.GetComponent<BoxCollider2D>();
        dormitory = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        DirectorOffice = GameObject.Find("DO_Hallway").transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();

        Forbidden_Lab = GameObject.Find("DO_Hallway").transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        Forbidden_Office = GameObject.Find("DO_Hallway").transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //¸¶À» ¸Ê
        bound_TownB1F = GameObject.Find("Town_B1F").gameObject.GetComponent<BoxCollider2D>();
        bound_Town1F = GameObject.Find("Town_1F").gameObject.GetComponent<BoxCollider2D>();
        bound_Town2F = GameObject.Find("Town_2F").gameObject.GetComponent<BoxCollider2D>();
        
        //¸¶À» °Ç¹°
        AngelaClinic = GameObject.Find("Town_1F").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        RileyKitchen = GameObject.Find("Town_1F").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        DubiumDining = GameObject.Find("Town_1F").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();
        House3 = GameObject.Find("Town_1F").gameObject.transform.GetChild(3).gameObject.GetComponent<BoxCollider2D>();

        Stancebar = GameObject.Find("Town_B1F").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        Casino = GameObject.Find("Town_B1F").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();

        //3Ãþ ¹æ
        ConferenceRoom = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        LockerRoom = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();
        Lab1 = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(3).gameObject.GetComponent<BoxCollider2D>();
        Lab2 = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(4).gameObject.GetComponent<BoxCollider2D>();
        DataStorage = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(5).gameObject.GetComponent<BoxCollider2D>();
        
        //2Ãþ ±â¼÷»ç
        PolaRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        BellaRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //2Ãþ ¹æ
        BreakRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(3).gameObject.GetComponent<BoxCollider2D>();
        TrainingRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(4).gameObject.GetComponent<BoxCollider2D>();
        Infirmary = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(5).gameObject.GetComponent<BoxCollider2D>();
        PhysicalRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(6).gameObject.GetComponent<BoxCollider2D>();

        //1Ãþ ¹æ
        NightDutyRoom = GameObject.Find("1F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        SecurityRoom = GameObject.Find("1F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //B1Ãþ º¹µµ
        ChimeraLab = GameObject.Find("B1F_Hallway").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        ChimeraIncubation = GameObject.Find("B1F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        AnimalBreeding = GameObject.Find("B1F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        Move();
        if (polaAnim.GetBool("isWalking") == true)
        {
            if(!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else if (polaAnim.GetBool("isWalking") == false)
        {
            audioSrc.Stop();
        }
        if (this.transform.position.y > 9 && this.transform.position.y < 15 && DataManager.instance.item_temp[12] == true)//gown setactive
        {
            gown.SetActive(true);
        }
        else
        {
            gown.SetActive(false);
        }
        /*
        if (Linda.activeSelf == true && gameObject.transform.position == new Vector3(124, -84.8f, 0))
        {
            Fungus.Flowchart.BroadcastFungusMessage("bulletEvent_ON");
            Linda.SetActive(false);
            Linda2.SetActive(true);
        }*/


        if (DataManager.instance.game_temp[5] == true)
        {
            Linda.SetActive(false);
        }
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            moveVelocity = Vector3.left;
            polaAnim.SetBool("isWalking", true);
            renderer_.flipX = false;
            idle_bool = false;

            if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
            {
                Linda.GetComponent<Animator>().SetBool("isWalking", true);
                Linda.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            moveVelocity = Vector3.right;
            polaAnim.SetBool("isWalking", true);
            renderer_.flipX = true;
            idle_bool = true;

            if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
            {
                Linda.GetComponent<Animator>().SetBool("isWalking", true);
                Linda.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            if (Linda.activeSelf == true)
            {
                Linda.GetComponent<Animator>().SetBool("isWalking", false);
                Linda.GetComponent<SpriteRenderer>().flipX = false;
            }

            polaAnim.SetBool("isWalking", false);
            
            if (idle_bool == true)
            {
                renderer_.flipX = true;
                Linda.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                renderer_.flipX = false;
                Linda.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        transform.position += moveVelocity * moveForce * Time.deltaTime;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        rb.velocity = Vector3.zero;
        polaAnim.SetBool("isWalking", false);
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Hall1")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_1F);
            float position = (this.transform.position.x - (-29)) / 60 * 700;
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-183 + position, -268, 0);
            playerposition_t.rectTransform.anchoredPosition = new Vector3(1000, 1000, 0);
        }
        else if (coll.gameObject.tag == "Hall2")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_2F);
            float position = (this.transform.position.x - (-29)) / 60 * 700;
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-183 + position, -114, 0);
        }
        else if (coll.gameObject.tag == "Hall3")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_3F);
            float position = (this.transform.position.x - (-29)) / 60 * 700;
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-183 + position, 43, 0);
        }
        else if (coll.gameObject.tag == "HallB1")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_B1F);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-1000, 1000, 0);
        }
        else if (coll.gameObject.tag == "Dorm")
        {
            Camera.GetComponent<CameraManager>().SetBound(dormitory);
            float position = (this.transform.position.x - (-83)) / 50 * 350;
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-600 + position, -114, 0);

        }
        else if (coll.gameObject.tag == "DirectorHall")
        {
            
            Camera.GetComponent<CameraManager>().SetBound(bound_DO);
            float position = (this.transform.position.x - (-45)) / 23 * 170;
            playerposition_b.rectTransform.anchoredPosition = new Vector3(156+position, 200, 0);

        }
        else if (coll.gameObject.tag == "DirectorRoom")
        {
            Camera.GetComponent<CameraManager>().SetBound(DirectorOffice);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(444, 221, 0);
        }
        
        //3Ãþ ¹æ
        else if (coll.gameObject.tag == "Conference")
        {
            Camera.GetComponent<CameraManager>().SetBound(ConferenceRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-155, 84, 0);
        }
        else if (coll.gameObject.tag == "Locker")
        {
            Camera.GetComponent<CameraManager>().SetBound(LockerRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-66, 84, 0);

        }
        else if (coll.gameObject.tag == "Lab1")
        {
            Camera.GetComponent<CameraManager>().SetBound(Lab1);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(47, 84, 0);
        }
        else if (coll.gameObject.tag == "Lab2")
        {
            Camera.GetComponent<CameraManager>().SetBound(Lab2);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(344, 84, 0);
        }
        else if (coll.gameObject.tag == "Data")
        {
            Camera.GetComponent<CameraManager>().SetBound(DataStorage);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(474, 84, 0);
        }
        //2Ãþ ¹æ
        else if (coll.gameObject.tag == "Break")
        {
            Camera.GetComponent<CameraManager>().SetBound(BreakRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-137, -71, 0);
        }
        else if (coll.gameObject.tag == "Training")
        {
            Camera.GetComponent<CameraManager>().SetBound(TrainingRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(34, -71, 0);
        }
        else if (coll.gameObject.tag == "Infirm")
        {
            Camera.GetComponent<CameraManager>().SetBound(Infirmary);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(309, -71, 0);
        }
        else if (coll.gameObject.tag == "Physical")
        {
            Camera.GetComponent<CameraManager>().SetBound(PhysicalRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(461, -71, 0);
        }
        //2Ãþ ±â¼÷»ç ¹æ
        else if (coll.gameObject.tag == "PolaR")
        {
            Camera.GetComponent<CameraManager>().SetBound(PolaRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-417, -71, 0);
        }
        else if (coll.gameObject.tag == "BellaR")
        {
            Camera.GetComponent<CameraManager>().SetBound(BellaRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-330, -71, 0);
            
        }
        //1Ãþ ¹æ
        else if (coll.gameObject.tag == "NightDuty")
        {
            Camera.GetComponent<CameraManager>().SetBound(NightDutyRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-167, -225, 0);
        }
        else if (coll.gameObject.tag == "Security")
        {
            Camera.GetComponent<CameraManager>().SetBound(SecurityRoom);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(-90, -225, 0);
        }
        //B1Ãþ ¹æ
        else if (coll.gameObject.tag == "ChimeraLab")
        {
            Camera.GetComponent<CameraManager>().SetBound(ChimeraLab);
        }
        else if (coll.gameObject.tag == "ChimeraIncubation")
        {
            Camera.GetComponent<CameraManager>().SetBound(ChimeraIncubation);
        }
        else if (coll.gameObject.tag == "AnimalBreeding")
        {
            Camera.GetComponent<CameraManager>().SetBound(AnimalBreeding);
        }
        //¸¶À» ¸Ê
        else if (coll.gameObject.tag == "Town_B1F")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_TownB1F);
            
            float position = (this.transform.position.x - (-99)) / 200 *860 ;
            playerposition_t.rectTransform.anchoredPosition = new Vector3(-490 + position, -219, 0);
        }
        else if (coll.gameObject.tag == "Town_1F")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_Town1F);
            float position = (this.transform.position.x - (-132)) / 270 * 1110;
            playerposition_t.rectTransform.anchoredPosition = new Vector3(-594 + position, -62, 0);
        }
        else if (coll.gameObject.tag == "Town_2F")
        {
            Camera.GetComponent<CameraManager>().SetBound(bound_Town2F);
            float position = (this.transform.position.x - (-88)) / 190 * 815;
            playerposition_t.rectTransform.anchoredPosition = new Vector3(-294 + position, 88, 0);
            playerposition_b.rectTransform.anchoredPosition = new Vector3(1000, 1000, 0);
        }
        //¸¶À» °Ç¹°
        else if (coll.gameObject.tag == "AngelaClinic")
        {
            Camera.GetComponent<CameraManager>().SetBound(AngelaClinic);
            playerposition_t.rectTransform.anchoredPosition = new Vector3(-424, -23.8f, 0);
        }
        else if (coll.gameObject.tag == "RileyKitchen")
        {
            Camera.GetComponent<CameraManager>().SetBound(RileyKitchen);
            playerposition_t.rectTransform.anchoredPosition = new Vector3(-361.5f, -23.8f, 0);
        }
        else if (coll.gameObject.tag == "DubiumDining")
        {
            Camera.GetComponent<CameraManager>().SetBound(DubiumDining);
            playerposition_t.rectTransform.anchoredPosition = new Vector3(-223.6f, -23.8f, 0);
        }
        else if (coll.gameObject.tag == "House3")
        {
            Camera.GetComponent<CameraManager>().SetBound(House3);
            playerposition_t.rectTransform.anchoredPosition = new Vector3(356.7f, -11.6f, 0);
        }
        else if (coll.gameObject.tag == "Stancebar")
        {
            Camera.GetComponent<CameraManager>().SetBound(Stancebar);
            //playerposition_t.rectTransform.anchoredPosition = new Vector3(356.7f, -11.6f, 0);
        }
        else if (coll.gameObject.tag == "Casino")
        {
            Camera.GetComponent<CameraManager>().SetBound(Casino);
            //playerposition_t.rectTransform.anchoredPosition = new Vector3(356.7f, -11.6f, 0);
        }
        else if (coll.gameObject.tag == "Forbidden_Office")
        {
            Camera.GetComponent<CameraManager>().SetBound(Forbidden_Office);
            //playerposition_t.rectTransform.anchoredPosition = new Vector3(356.7f, -11.6f, 0);
        }
        else if (coll.gameObject.tag == "Forbidden_Lab")
        {
            Camera.GetComponent<CameraManager>().SetBound(Forbidden_Lab);
            //playerposition_t.rectTransform.anchoredPosition = new Vector3(356.7f, -11.6f, 0);
        }

    }
}
