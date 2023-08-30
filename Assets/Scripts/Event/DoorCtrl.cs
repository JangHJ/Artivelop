using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class DoorCtrl : MonoBehaviour
{
    //SpriteRenderer renderer_;
    //public GameObject ElevatorTab;
    public GameObject Player;
    public GameObject Camera;
    public string RoomName;
    public Flowchart fc_chat;
    public Flowchart fc_event;
    //
    public Animator PlayerAnim;

    //�� ���� �ݶ��̴�
    public BoxCollider2D bound_1F;
    public BoxCollider2D bound_2F;
    public BoxCollider2D bound_3F;
    public BoxCollider2D bound_B1F;
    public BoxCollider2D Dormitory;
    public BoxCollider2D bound_DO;

    //���� �ݶ��̴�
    public BoxCollider2D bound_TownB1F;
    public BoxCollider2D bound_Town1F;
    public BoxCollider2D bound_Town2F;

    //���� 1�� �ǹ���
    public BoxCollider2D AngelaClinic;
    public BoxCollider2D RileyKitchen;
    public BoxCollider2D DubiumDining;
    public BoxCollider2D House3;

    //���� B1�� �ǹ���
    public BoxCollider2D StanceBar;
    public BoxCollider2D Casino;

    //���������
    public BoxCollider2D Forbidden_Lab;
    public BoxCollider2D Forbidden_Office;
    public BoxCollider2D DirectorOffice;
    //������ 3�� ��
    public BoxCollider2D ConferenceRoom;
    public BoxCollider2D LockerRoom;
    public BoxCollider2D Lab1;
    public BoxCollider2D Lab2;
    public BoxCollider2D DataStorage;
    public BoxCollider2D SecretRoom;

    //������ 2�� ��
    public BoxCollider2D BreakRoom;
    public BoxCollider2D TrainingRoom;
    public BoxCollider2D Infirmary;
    public BoxCollider2D PhysicalRoom;
    //������ 2�� �����
    public BoxCollider2D BellaRoom;
    public BoxCollider2D PolaRoom;

    //������ 1�� ��
    public GameObject keyPad;
    public BoxCollider2D NightDutyRoom;
    public BoxCollider2D SecurityRoom;

    //������ B1�� ��
    public BoxCollider2D ChimeraLab;
    public BoxCollider2D ChimeraIncubation;
    public BoxCollider2D AnimalBreeding;

    public float TestTime = 1f;

    Animator SecurityAnim;

    bool isEnter = false;

    void Update()
    {
        if (isEnter == true)
        {
            switch (RoomName)
            {
                case "ForbiddenOffice_Portal": // �������_��Ż����
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    GoToForbiddenPortal();
                    break;
            }
           
            if (Input.GetKey(KeyCode.E))
            {
                PlayerAnim.SetBool("isWalking", false);

                switch (RoomName)
                {
                    //��⿬���� + �����
                    case "ForbiddenOffice": // �������_����
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToForbiddenOffice();
                        break;

                    case "ForbiddenOffice_Out": // �������_������
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToForbiddenOffice();
                        break;


                    //������
                    case "AngelaClinic": // ����1��_������Ŭ����
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToAngelaClinic();
                        break;

                    case "AngelaClinic_Out": // ����1��_������Ŭ���� ������
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToAngelaClinic();
                        break;

                    case "RileyKitchen": // ����1��_
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToRileyKitchen();
                        break;

                    case "RileyKitchen_Out": // ����1��_
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToRileyKitchen();
                        break;

                    case "DubiumDining":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToDubiumDining();
                        break;

                    case "DubiumDining_Out":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToDubiumDining();
                        break;

                    case "House3":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToHouse3();
                        break;

                    case "House3_Out":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToHouse3();
                        break;

                    case "StanceBar":
                        if (DataManager.instance.game_temp[4] == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToStanceBar();
                        }
                        else
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked_stanceBar");
                        break;

                    case "StanceBar_Out":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToStanceBar();
                        break;

                    case "Casino":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToCasino();
                        break;

                    case "Casino_Out":
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToCasino();
                        break;


                    case "Building_In": // ������ 1��_����
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToBuilding();
                        break;


                    case "Elevator_B1F": // ����ǹ� ���������� ž��
                        if (fc_event.GetBooleanVariable("keypadON3") == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("ElevatorMove");
                            GoToB1F();
                        }
                        break;

                    case "ConferenceRoom": // 3��_����ȸ�ǽ�
                        if (DataManager.instance.item_temp[2] == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToConferenceRoom();
                        }
                        else
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked");
                        break;

                    case "LockerRoom": // 3��_��Ŀ��
                        if (DataManager.instance.item_temp[10] == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToLockerRoom();
                        }
                        else
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked");
                        break;

                    case "Lab1": // 3��_��1������
                        if (DataManager.instance.item_temp[11] == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToLab1();
                        }
                        else
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked");
                        break;

                    case "Lab2": // 3��_��2������
                        if (DataManager.instance.item_temp[11] == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToLab2();
                        }
                        else
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked");
                        break;

                    case "DataStorage": // 3��_�ڷẸ����
                        if (fc_event.GetBooleanVariable("keypadON2") == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToDataStorage();
                        }
                        break;

                    case "SecretRoom": // 3��_�ڷẸ���� ����ǹ�
                        if (DataManager.instance.item_temp[21] == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove_Secret");
                            GoToSecretRoom();
                        }
                        else
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked");
                        break;


                    case "PolaRoom": // 2��_�����_�����
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToPolaRoom();
                        break;
                    case "BellaRoom": // 2��_�����_�����
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToBellaRoom();
                        break;

                    case "BreakRoom": // 2��_�ްԽ�
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToBreakRoom();
                        break;
                    case "TrainingRoom": // 2��_ü�´ܷý�
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToTrainingRoom();
                        break;
                    case "Infirmary": //2��_�ǹ���
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToInfirmary();
                        break;
                    case "PhysicalRoom": // 2��_��ü�˻��
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        GoToPhysicalRoom();
                        break;

                    case "NightDutyRoom": // 1��_������
                        if (fc_event.GetBooleanVariable("keypadON") == true && fc_chat.GetBooleanVariable("robinChat") == false)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToNightDutyRoom();
                        }
                        else if (fc_chat.GetBooleanVariable("robinChat") == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked_1FNightDutyRoom");
                        }
                        break;

                    case "SecurityRoom": // 1��_���Ƚ�
                        if (fc_event.GetBooleanVariable("SRCard_USE") == true)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                            GoToSecurityRoom();
                        }
                        else if (DataManager.instance.item_temp[25] == false)
                        {
                            Fungus.Flowchart.BroadcastFungusMessage("RoomLocked_Security");
                        }
                        break;

                    default:
                        print("���� �������� �ʾҽ��ϴ�.");
                        Fungus.Flowchart.BroadcastFungusMessage("RoomLocked");
                        break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        //���� ��
        bound_TownB1F = GameObject.Find("Town_B1F").gameObject.GetComponent<BoxCollider2D>();
        bound_Town1F = GameObject.Find("Town_1F").gameObject.GetComponent<BoxCollider2D>();
        bound_Town2F = GameObject.Find("Town_2F").gameObject.GetComponent<BoxCollider2D>();

        //���� 
        bound_1F = GameObject.Find("1F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_2F = GameObject.Find("2F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_3F = GameObject.Find("3F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        bound_B1F = GameObject.Find("B1F_Hallway").gameObject.GetComponent<BoxCollider2D>();
        Dormitory = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        bound_DO = GameObject.Find("DO_Hallway").gameObject.GetComponent<BoxCollider2D>();

        DirectorOffice = GameObject.Find("DO_Hallway").transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        Forbidden_Lab = GameObject.Find("DO_Hallway").transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        Forbidden_Office = GameObject.Find("DO_Hallway").transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //���� �ǹ�
        AngelaClinic = GameObject.Find("Town_1F").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        RileyKitchen = GameObject.Find("Town_1F").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        DubiumDining = GameObject.Find("Town_1F").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();
        House3 = GameObject.Find("Town_1F").gameObject.transform.GetChild(3).gameObject.GetComponent<BoxCollider2D>();

        StanceBar = GameObject.Find("Town_B1F").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        Casino = GameObject.Find("Town_B1F").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();


        //3�� ��
        ConferenceRoom = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        LockerRoom = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();
        Lab1 = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(3).gameObject.GetComponent<BoxCollider2D>();
        Lab2 = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(4).gameObject.GetComponent<BoxCollider2D>();
        DataStorage = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(5).gameObject.GetComponent<BoxCollider2D>();
        SecretRoom = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();

        //2�� �����
        PolaRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        BellaRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //2�� ��
        BreakRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(3).gameObject.GetComponent<BoxCollider2D>();
        TrainingRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(4).gameObject.GetComponent<BoxCollider2D>();
        Infirmary = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(5).gameObject.GetComponent<BoxCollider2D>();
        PhysicalRoom = GameObject.Find("2F_Hallway").gameObject.transform.GetChild(6).gameObject.GetComponent<BoxCollider2D>();

        //1�� ��
        NightDutyRoom = GameObject.Find("1F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        SecurityRoom = GameObject.Find("1F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //B1�� ��
        ChimeraLab = GameObject.Find("B1F_Hallway").gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        ChimeraIncubation = GameObject.Find("B1F_Hallway").gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        AnimalBreeding = GameObject.Find("B1F_Hallway").gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();

        //keyPad = GameObject.Find("Canvas").gameObject.transform.GetChild(12).gameObject;
        Player = GameObject.Find("Pola");
        Camera = GameObject.Find("Main Camera");

        PlayerAnim = Player.GetComponent<Animator>();
        SecurityAnim = GetComponent<Animator>();
    }

    //�濡�� ������
    private void OnCollisionEnter2D(UnityEngine.Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            switch (RoomName)
            {
                case "DirectorOffice_Out": // 15��_���������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToDirectorOffice();
                    break;

                case "DirectorOffice": // 3��_��������� ����
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    GoToDirectorOffice();
                    break;

                case "ChimeraLab_Out": // B1��_Ű�޶󿬱���
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToChimeraLab();
                    break;
                case "ChimeraIncubation_Out": // B1��_Ű�޶����
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToChimeraIncubation();
                    break;
                case "AnimalBreeding_Out": // B1��_������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToAnimalBreeding();
                    break;

                case "ChimeraLab": // B1��_Ű�޶󿬱���
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    GoToChimeraLab();
                    break;
                case "ChimeraIncubation": // B1��_Ű�޶����
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    GoToChimeraIncubation();
                    break;
                case "AnimalBreeding": // B1��_������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    GoToAnimalBreeding();
                    break;
                    

                case "NightDutyRoom_Out": // 1��_������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToNightDutyRoom();
                    break;
                case "SecurityRoom_Out": // 1��_���Ƚ�
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToSecurityRoom();
                    break;
                    
                case "Dormitory": // 2��_����纹��
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    GoToDormitory();
                    break;

                case "Dormitory_Out": // 2��_����纹��
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToDormitory();
                    break;

                case "BellaRoom_Out": // 2��_�����_�����
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToBellaRoom();
                    break;

                case "PolaRoom_Out": // 2��_�����_�����
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToPolaRoom();
                    break;


                case "BreakRoom_Out": // 2��_�ްԽ�
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToBreakRoom();

                    break;
                case "TrainingRoom_Out": // 2��_ü�´ܷý�
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToTrainingRoom();
                    break;

                case "Infirmary_Out": // 2��_�ǹ���
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToInfirmary();
                    break;

                case "PhysicalRoom_Out": // 2��_��ü�˻��
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToPhysicalRoom();
                    break;

                case "ConferenceRoom_Out": // 3��_����ȸ�ǽ� ������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToConferenceRoom();
                    break;
                case "LockerRoom_Out": // 3��_��Ŀ�� ������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToLockerRoom();
                    break;
                case "Lab1_Out": // 3��_��1������ ������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToLab1();
                    break;
                case "Lab2_Out": // 3��_��2������ ������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToLab2();
                    break;
                case "DataStorage_Out": // 3��_�ڷẸ���� ������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToDataStorage();
                    break;

                case "SecretRoom_Out": // 3��_�ڷẸ���� ����ǹ� ������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                    OutToDataStorage();
                    break;

                case "ForbiddenLab_Out": // ��⿬����_������
                    Fungus.Flowchart.BroadcastFungusMessage("RoomMove_ForbiddenLab");
                    break;

              
                //�߿� ������
                case "Building_Out": // ������ 1��_�ⱸ�� ������
                    if (DataManager.instance.item_temp[6] == true && DataManager.instance.item_temp[7] == true)
                    {
                        Fungus.Flowchart.BroadcastFungusMessage("RoomMove");
                        OutToBuilding();
                    }
                    else
                        Fungus.Flowchart.BroadcastFungusMessage("CantExit_Building");
                    break;

                    
                default:
                    print("���� �������� �ʾҽ��ϴ�.");
                    break;
            }
        }
    }

    //������ ����
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter =false;

        }
    }

    //��� ������ �����
    public void GoToForbiddenOffice()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Forbidden_Office);
        Player.transform.position = new Vector2(-130f, 20f);
        Camera.transform.position = new Vector3(-130f, 20f, -3);
    }
    public void OutToForbiddenOffice()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Forbidden_Lab);
        Player.transform.position = new Vector2(-68.5f, 20f);
        Camera.transform.position = new Vector3(-68.5f, 20f, -3);
    }
    public void GoToForbiddenPortal()
    {
        Fungus.Flowchart.BroadcastFungusMessage("GROffice_Enter");
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(DirectorOffice);
        Player.transform.position = new Vector2(-16, 20);
        Camera.transform.position = new Vector3(-16, 20, -3);
    }
    // ���� �� ���� & ������
    public void GoToBuilding()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_1F);
        Player.transform.position = new Vector2(29f, -12.5f);
        Camera.transform.position = new Vector3(29f, -12.5f, -3);
    }
    public void OutToBuilding()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_Town2F);
        Player.transform.position = new Vector2(-77f, -64.8f);
        Camera.transform.position = new Vector3(-77f, -64.8f, -3);
    }


    //������
    public void GoToAngelaClinic()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(AngelaClinic);
        Player.transform.position = new Vector2(-81f, -46.2f);
        Camera.transform.position = new Vector3(-81f, -51.2f, -3);
    }
    public void OutToAngelaClinic()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_Town1F);
        Player.transform.position = new Vector2(-89f, -84.8f);
        Camera.transform.position = new Vector3(-89f, -89.8f, -3);
    }
    public void GoToRileyKitchen()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(RileyKitchen);
        Player.transform.position = new Vector2(-59f, -46.2f);
        Camera.transform.position = new Vector3(-59f, -51.2f, -3);
    }
    public void OutToRileyKitchen()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_Town1F);
        Player.transform.position = new Vector2(-72.5f, -84.8f);
        Camera.transform.position = new Vector3(-72.5f, -89.8f, -3);
    }
    public void GoToDubiumDining()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(DubiumDining);
        Player.transform.position = new Vector2(-38.8f, -46.2f);
        Camera.transform.position = new Vector3(-38.8f, -51.2f, -3);
    }
    public void OutToDubiumDining()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_Town1F);
        Player.transform.position = new Vector2(-38f, -84.8f);
        Camera.transform.position = new Vector3(-38f, -89.8f, -3);
    }
    public void GoToHouse3()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(House3);
        Player.transform.position = new Vector2(-10.2f, -46.2f);
        Camera.transform.position = new Vector3(-10.2f, -51.2f, -3);
    }
    public void OutToHouse3()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_Town1F);
        Player.transform.position = new Vector2(85.5f, -84.8f);
        Camera.transform.position = new Vector3(85.5f, -89.8f, -3);
    }
    public void GoToStanceBar()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(StanceBar);
        Player.transform.position = new Vector2(7.5f, -46.2f);
        Camera.transform.position = new Vector3(7.5f, -51.2f, -3);
    }
    public void OutToStanceBar()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_TownB1F);
        Player.transform.position = new Vector2(-21.5f, -104.8f);
        Camera.transform.position = new Vector3(-21.5f, -109.8f, -3);
    }
    public void GoToCasino()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Casino);
        Player.transform.position = new Vector2(50.5f, -46.2f);
        Camera.transform.position = new Vector3(50.5f, -51.2f, -3);
    }
    public void OutToCasino()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_TownB1F);
        Player.transform.position = new Vector2(-10.2f, -104.8f);
        Camera.transform.position = new Vector3(-10.2f, -109.8f, -3);
    }

    //������ ��
    public void GoToDirectorOffice()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(DirectorOffice);
        Player.transform.position = new Vector2(-17, 20);
        Camera.transform.position = new Vector3(-17, 20, -3);
    }
    public void OutToDirectorOffice()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_DO);
        Player.transform.position = new Vector2(-23, 20);
        Camera.transform.position = new Vector3(-23, 20, -3);
    }
    //3��
    public void GoToConferenceRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(ConferenceRoom);
        Player.transform.position = new Vector2(37f, 9.5f);
        Camera.transform.position = new Vector3(37f, 11, -3);
    }
    public void OutToConferenceRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_3F);
        Player.transform.position = new Vector2(-25.8f, 9.5f);
        Camera.transform.position = new Vector3(-25.8f, 11, -3);
    }

    public void GoToB1F()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_B1F);
        Player.transform.position = new Vector2(0, -23.5f);
        Camera.transform.position = new Vector3(0, -22, -3);
    }

    public void GoToLockerRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(LockerRoom);
        Player.transform.position = new Vector2(64, 9.5f);
        Camera.transform.position = new Vector3(64, 11, -3);
    }
    public void OutToLockerRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_3F);
        Player.transform.position = new Vector2(-17.8f, 9.5f);
        Camera.transform.position = new Vector3(-17.8f, 11, -3);
    }
    public void GoToLab1()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Lab1);
        Player.transform.position = new Vector2(92f, 9.5f);
        Camera.transform.position = new Vector3(92f, 11, -3);
    }
    public void OutToLab1()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_3F);
        Player.transform.position = new Vector2(-8.1f, 9.5f);
        Camera.transform.position = new Vector3(-8.1f, 11, -3);
    }
    public void GoToLab2()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Lab2);
        Player.transform.position = new Vector2(129, 9.5f);
        Camera.transform.position = new Vector3(129, 11, -3);
    }
    public void OutToLab2()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_3F);
        Player.transform.position = new Vector2(12, 9.5f);
        Camera.transform.position = new Vector3(12, 11, -3);
    }
    public void GoToDataStorage()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(DataStorage);
        Player.transform.position = new Vector2(164, 9.5f);
        Camera.transform.position = new Vector3(164, 11, -3);
    }
    public void OutToDataStorage()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_3F);
        Player.transform.position = new Vector2(24.1f, 9.5f);
        Camera.transform.position = new Vector3(24.1f, 11, -3);
    }
    //�ڷẸ���� ����� ��
    public void GoToSecretRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(SecretRoom);
        Player.transform.position = new Vector2(212, 9.5f);
        Camera.transform.position = new Vector3(212, 11, -3);
    }
    public void OutToSecretRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_3F);
        Player.transform.position = new Vector2(194f, 9.5f);
        Camera.transform.position = new Vector3(194f, 11, -3);
    }

    // 2�� �����
    public void GoToDormitory()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Dormitory);
        Player.transform.position = new Vector2(-34.5f, -1.5f);
        Camera.transform.position = new Vector3(-34.5f, -1.5f, -3);
    }
    public void OutToDormitory()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_2F);
        Player.transform.position = new Vector2(-29.5f, -1.5f);
        Camera.transform.position = new Vector3(-29.5f, -1.5f, -3);
    }
    public void GoToPolaRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(PolaRoom);
        Player.transform.position = new Vector2(-133.5f, -1.5f);
        Camera.transform.position = new Vector3(-133.5f, -1.5f, -3);
    }
    public void OutToPolaRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Dormitory);
        Player.transform.position = new Vector2(-61.5f, -1.5f);
        Camera.transform.position = new Vector3(-61.5f, -1.5f, -3);
    }
    public void GoToBellaRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(BellaRoom);
        Player.transform.position = new Vector2(-108.5f, -1.5f);
        Camera.transform.position = new Vector3(-108.5f, -1.5f, -3);
    }
    public void OutToBellaRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Dormitory);
        Player.transform.position = new Vector2(-47.8f,-1.5f);
        Camera.transform.position = new Vector3(-47.8f, -1.5f, -3);
    }

    // 2��
    public void GoToBreakRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(BreakRoom);
        Player.transform.position = new Vector2(34.5f, -1.5f);
        Camera.transform.position = new Vector3(34.5f, -1.5f, -3);
    }
    public void OutToBreakRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_2F);
        Player.transform.position = new Vector2(-24f, -1.5f);
        Camera.transform.position = new Vector3(-24f, -1.5f, -3);
    }
    public void GoToTrainingRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(TrainingRoom);
        Player.transform.position = new Vector2(68f, -1.5f);
        Camera.transform.position = new Vector3(68f, -1.5f, -3);
    }
    public void OutToTrainingRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_2F);
        Player.transform.position = new Vector2(-10.5f, -1.5f);
        Camera.transform.position = new Vector3(-10.5f, -1.5f, -3);
    }
    public void GoToInfirmary()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(Infirmary);
        Player.transform.position = new Vector2(112f, -1.5f);
        Camera.transform.position = new Vector3(112f, -1.5f, -3);
    }
    public void OutToInfirmary()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_2F);
        Player.transform.position = new Vector2(11f, -1.5f);
        Camera.transform.position = new Vector3(11f, -1.5f, -3);
    }
    public void GoToPhysicalRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(PhysicalRoom);
        Player.transform.position = new Vector2(148f, -1.5f);
        Camera.transform.position = new Vector3(148f, -1.5f, -3);
    }
    public void OutToPhysicalRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_2F);
        Player.transform.position = new Vector2(23.5f, -1.5f);
        Camera.transform.position = new Vector3(23.5f, -1.5f, -3);
    }



    public void GoToNightDutyRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(NightDutyRoom);
        Player.transform.position = new Vector2(34.5f, -12.5f);
        Camera.transform.position = new Vector3(34.5f, -12.5f, -3);
    }
    public void OutToNightDutyRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_1F);
        Player.transform.position = new Vector2(-28f, -12.5f);
        Camera.transform.position = new Vector3(-28f, -12.5f, -3);
    }
    public void GoToSecurityRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(SecurityRoom);
        Player.transform.position = new Vector2(62.8f, -12.5f);
        Camera.transform.position = new Vector3(62.8f, -12.5f, -3);
    }
    public void OutToSecurityRoom()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_1F);
        Player.transform.position = new Vector2(-22.3f, -12.5f);
        Camera.transform.position = new Vector3(-22.3f, -12.5f, -3);
    }

    //B1��
    public void GoToChimeraLab()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(ChimeraLab);
        Player.transform.position = new Vector2(-47.5f, -23.5f);
        Camera.transform.position = new Vector3(-47.5f, -23.5f, -3);
    }
    public void OutToChimeraLab()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(ChimeraIncubation);
        Player.transform.position = new Vector2(-42.5f, -23.5f);
        Camera.transform.position = new Vector3(-42.5f, -23.5f, -3);
    }
    public void GoToChimeraIncubation()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(ChimeraIncubation);
        Player.transform.position = new Vector2(-12f, -23.5f);
        Camera.transform.position = new Vector3(-12f, -23.5f, -3);
    }
    public void OutToChimeraIncubation()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_B1F);
        Player.transform.position = new Vector2(-7f, -23.5f);
        Camera.transform.position = new Vector3(-7f, -23.5f, -3);
    }
    public void GoToAnimalBreeding()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(AnimalBreeding);
        Player.transform.position = new Vector2(12f, -23.5f);
        Camera.transform.position = new Vector3(12f, -23.5f, -3);
    }
    public void OutToAnimalBreeding()
    {
        PlayerAnim.SetBool("isWalking", false);
        Camera.GetComponent<CameraManager>().SetBound(bound_B1F);
        Player.transform.position = new Vector2(7f, -23.5f);
        Camera.transform.position = new Vector3(7f, -23.5f, -3);
    }
    

}
