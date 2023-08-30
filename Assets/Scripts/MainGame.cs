using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class MainGame : MonoBehaviour
{
    public static MainGame instance;

    public GameObject panel_bg;
    public GameObject Savetab;
    public GameObject Player;
    public Flowchart fc;
    public Flowchart fc_event;
    public GameObject blackPanel;
    public GameObject Camera;
    public GameObject Panel_list;
    public GameObject Panel_file;
    public GameObject Panel_board;
    public GameObject Panel_conboard;
    public GameObject Panel_drugtest;
    public GameObject Panel_report;
    public GameObject Panel_monitor;
    public GameObject Panel_keypad;
    public GameObject Panel_keypad2;
    public GameObject Panel_ele_keypad;
    public GameObject Panel_cardslide;
    public GameObject Panel_photo18;
    public GameObject Panel_photo19;
    public GameObject Panel_chimeraReport;
    public GameObject next;
    public GameObject exit;

    public GameObject Panel_companyReport;
    public GameObject Panel_companyReport1;
    public GameObject Panel_fireReport;
    
    public GameObject Resistant1;
    public GameObject LindaEvent;

    public void Exit_Panel_fireReport()
    {
        Panel_fireReport.SetActive(false);
    }
    public void Exit_Panel_chimeraReport()
    {
        Panel_chimeraReport.SetActive(false);
    }
    public void Exit_Panel_companyReport()
    {
        Panel_companyReport.SetActive(false);
    }
    public void Exit_Panel_companyReport1()
    {
        Panel_companyReport1.SetActive(false);
        next.SetActive(false);
        exit.SetActive(true);
    }
    public void Exit_Panel_photo18()
    {
        Panel_photo18.SetActive(false);
    }
    public void Exit_Panel_photo19()
    {
        Panel_photo19.SetActive(false);
    }

    public void Exit_Panel_board()
    {
        Panel_board.SetActive(false);
    }

    public void Exit_Panel_conboard()
    {
        Panel_conboard.SetActive(false);
    }
    public void Exit_Panel_drugtest()
    {
        Panel_drugtest.SetActive(false);
    }
    public void Exit_Panel_monitor()
    {
        Panel_monitor.SetActive(false);
    }
    public void Exit_Panel_report()
    {
        Panel_report.SetActive(false);
    }
    public void Exit_Panel_file()
    {
        Panel_file.SetActive(false);
    }
    public void Exit_Panel_list()
    {
        Panel_list.SetActive(false);
    }
    public void Exit_ele_keypad()
    {
        Panel_ele_keypad.SetActive(false);
    }
    public void Exit_Panel_keypad()
    {
        Panel_keypad.SetActive(false);
    }
    public void Exit_Panel_keypad2()
    {
        Panel_keypad2.SetActive(false);
    }
    public void Exit_Panel_cardslide()
    {
        Panel_cardslide.SetActive(false);
    }

    /*
    //삭제금지
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        fc = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        print(DataManager.instance.nowSlot);
        Player = GameObject.Find("Pola");
        Camera = GameObject.Find("Main Camera");

        fc.SetBooleanVariable("isMove", true);

        if (DataManager.instance.nowSlot == 0)
        {
            fc.SetIntegerVariable("slot", 1);
            Fungus.Flowchart.BroadcastFungusMessage("LoadGame");
        }
        else if (DataManager.instance.nowSlot == 1)
        {
            fc.SetIntegerVariable("slot", 2);
            Fungus.Flowchart.BroadcastFungusMessage("LoadGame");
        }
        else if (DataManager.instance.nowSlot == 2)
        {
            fc.SetIntegerVariable("slot", 3);
            Fungus.Flowchart.BroadcastFungusMessage("LoadGame");
        }
        else
        {
            fc.SetIntegerVariable("slot", 0);
            Fungus.Flowchart.BroadcastFungusMessage("reset_value");
        }


        if (DataManager.instance.nowSlot >= 0)
        {
            DataManager.instance.item_temp = DataManager.instance.nowPlayer.item;
            DataManager.instance.game_temp = DataManager.instance.nowPlayer.game;
            DataManager.instance.item_i_temp = DataManager.instance.nowPlayer.item_i;
            DataManager.instance.box_temp = DataManager.instance.nowPlayer.box;
            DataManager.instance.item_s_temp = DataManager.instance.nowPlayer.item_s;
            fc.SetIntegerVariable("goal", DataManager.instance.nowPlayer.goal);
        }
       
        
        

        if (DataManager.instance.nowPlayer.pos != new Vector2(-13, 20f))
            Player.transform.position = DataManager.instance.nowPlayer.pos; 

        if(DataManager.instance.pos_temp == new Vector2(74.5f, 9.5f))
            Player.transform.position = DataManager.instance.pos_temp;

        Destroy(blackPanel, 0.4f);

        //Camera.GetComponent<CameraManager>().bound = DataManager.instance.nowPlayer.cameraBound;

        /*
        for (int i = 0; i < 7; i++)
        {
                print("게임"+ $"{i+1}" + " : " + $"{DataManager.instance.nowPlayer.game[i]} \n");
        }
        //print(DataManager.instance.pos_temp);

        for (int i = 0; i < 23; i++)
        {
                print("아이템" + $"{i + 1}" + " : " + $"{DataManager.instance.nowPlayer.item[i]} \n");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (fc.GetBooleanVariable("started") == true && fc.GetIntegerVariable("day") == 2)
        {
            Player.transform.position = new Vector2(-13f, 20f);
            Camera.transform.position = new Vector3(-13f, 20f, -3);
        }

        //if(fc.GetStringVariable("quarter1") == "A" && fc.GetBooleanVariable("bellaChat3_2") == true && fc.GetBooleanVariable("DirectorChat3_2") == false)

  
        if (DataManager.instance.game_temp[1] == true && DataManager.instance.item_temp[10] == false)
        {
            DataManager.instance.item_temp[10] = true;
            Fungus.Flowchart.BroadcastFungusMessage("Equip_LockerKey");
        }

        if (DataManager.instance.item_temp[1] == true && fc_event.GetBooleanVariable("doughnut") == false)
            fc_event.SetBooleanVariable("doughnut", true);

        if (fc_event.GetBooleanVariable("CardKey3F") == true && DataManager.instance.item_temp[2] == false)
            DataManager.instance.item_temp[2] = true;

        if (DataManager.instance.item_temp[2] == true && fc_event.GetBooleanVariable("CardKey3F") == false)
            fc_event.SetBooleanVariable("CardKey3F", true);

        if (DataManager.instance.item_temp[4] == true && fc_event.GetBooleanVariable("samanthaQuiz") == false)
            fc_event.SetBooleanVariable("samanthaQuiz", true);

        if (fc_event.GetBooleanVariable("ChimeraNametag") == true && DataManager.instance.item_temp[6] == false)
            DataManager.instance.item_temp[6] = true;

        if (DataManager.instance.item_temp[6] == true && fc_event.GetBooleanVariable("ChimeraNametag") == false)
            fc_event.SetBooleanVariable("ChimeraNametag", true);

        if (fc_event.GetBooleanVariable("DrugReport") == true && DataManager.instance.item_temp[7] == false)
            DataManager.instance.item_temp[7] = true;

        if (DataManager.instance.item_temp[7] == true && fc_event.GetBooleanVariable("DrugReport") == false)
            fc_event.SetBooleanVariable("DrugReport", true);
    
        if (fc_event.GetBooleanVariable("LockerKey") == true && DataManager.instance.item_temp[10] == false)
            DataManager.instance.item_temp[10] = true;

       // if (DataManager.instance.item_temp[10] == true && fc_event.GetBooleanVariable("LockerKey") == false)
        //{
          //  fc_event.SetBooleanVariable("LockerKey", true);
           // fc.SetBooleanVariable("DirectorChat3_1", true);
        //}

        if (DataManager.instance.item_temp[11] == true && fc_event.GetBooleanVariable("LabKey") == false)
        {
            fc_event.SetBooleanVariable("LabKey", true);
            fc.SetBooleanVariable("bellaChat3_1", true);
        }
        if (fc_event.GetBooleanVariable("LabKey") == true && DataManager.instance.item_temp[11] == false)
            DataManager.instance.item_temp[11] = true;

        if (fc_event.GetBooleanVariable("Gown") == true && DataManager.instance.item_temp[12] == false)
            DataManager.instance.item_temp[12] = true;

        if (DataManager.instance.item_temp[9] == true && fc_event.GetBooleanVariable("water") == false)
            fc_event.SetBooleanVariable("water", true);
     //   if (fc_event.GetBooleanVariable("water") == true && DataManager.instance.item_temp[9]    == false)
       //     DataManager.instance.item_temp[9] = true;

        if (DataManager.instance.item_temp[25] == true && fc_event.GetBooleanVariable("SecurityCard") == false)
            fc_event.SetBooleanVariable("SecurityCard", true);

        if (DataManager.instance.item_temp[1] == true)
        {
            fc_event.SetBooleanVariable("keypadON", true);
            fc_event.SetBooleanVariable("SRCard_USE", true);
        }

        if(DataManager.instance.item_temp[18] == true || DataManager.instance.item_temp[19] == true)
            fc_event.SetBooleanVariable("keypadON2", true);

        if (fc_event.GetBooleanVariable("RedScarf") == true && DataManager.instance.item_temp[20] ==false)
            DataManager.instance.item_temp[20] = true;
        if (DataManager.instance.item_temp[20] == true && fc_event.GetBooleanVariable("RedScarf") == false )
            fc_event.SetBooleanVariable("RedScarf", true);

        if (fc_event.GetBooleanVariable("SecretCardkey") == true && DataManager.instance.item_temp[21] == false)
            DataManager.instance.item_temp[21] = true;
        if (DataManager.instance.item_temp[21] == true && fc_event.GetBooleanVariable("SecretCardkey") == false)
            fc_event.SetBooleanVariable("SecretCardkey", true);

     

       /* if (fc_event.GetBooleanVariable("resistant_bullet") == true)
        {
            SceneManager.LoadScene("Minigame6");
            Fungus.Flowchart.BroadcastFungusMessage("SaveGame");
        }*/

        for (int i = 0; i < 26; i++)
        {
            if (DataManager.instance.item_temp[i] == true)
            {
                if (i > 16 && i < 26 && DataManager.instance.item_i_temp[i - 2] == false)
                    DataManager.instance.item_i_temp[i - 2] = true;
                else if (i == 16)
                    print("수석 연구원 선정 게시물 확대");
                else if (i > 8 && i < 16 && DataManager.instance.item_i_temp[i - 1] == false)
                    DataManager.instance.item_i_temp[i - 1] = true;
                else if (i == 8)
                    print("컴퓨터 화면 속 지시내용 확대");
                else if (i >=0 && i < 8 && DataManager.instance.item_i_temp[i] == false)
                    DataManager.instance.item_i_temp[i] = true;
               
                
            }
        }
        //벨라한테 죽는 엔딩
        if (fc.GetBooleanVariable("BellaDeadEnding") == true)
        {
            SceneManager.LoadScene("BellaDeadEnding");
        }
        //스카프 안해서 죽는엔딩
        if (fc.GetBooleanVariable("ScarfEnding") == true)
        {
            SceneManager.LoadScene("ScarfEnding");
        }
        //복수엔딩 벨라와 함께
        if (fc.GetBooleanVariable("RevengeEnding") == true)
        {
            SceneManager.LoadScene("RevengeEnding");
        }
        //복수엔딩 but 벨라 죽음
        if (fc.GetBooleanVariable("RevengeEnding2") == true)
        {
            SceneManager.LoadScene("RevengeEnding2");
        }
        //사만다 체포 엔딩
        if (fc.GetBooleanVariable("ResiDeadEnding") == true)
        {
            SceneManager.LoadScene("ResiDeadEnding");
        } 
     
        //증거 다 안모으고 레지스탕스 엔딩
        if (fc.GetBooleanVariable("ResistantEnding") == true)
        {
            SceneManager.LoadScene("ResistantEnding");
        }
        //억압엔딩
        if (fc.GetBooleanVariable("SuppresionEnding") == true)
        {
            SceneManager.LoadScene("SuppresionEnding");
        }
        //간신엔딩
        if (fc.GetBooleanVariable("barelyEnding") == true)
        {
            SceneManager.LoadScene("barelyEnding");
        }

        //증거 모으고 레지스탕스 합류
        if (fc_event.GetBooleanVariable("ResistantEnding2") == true)
        {
            SceneManager.LoadScene("ResistantEnding2");
        }
        //토사구팽엔딩
        if (fc_event.GetBooleanVariable("HuntingResistance") == true)
        {
            SceneManager.LoadScene("HuntingResistance");
        }


        if (fc_event.GetBooleanVariable("GotoGR") == true)
        {
            Player.GetComponent<SpriteRenderer>().flipX = true;
            Player.transform.position = new Vector2(-17, 20f);
            Camera.transform.position = new Vector3(-17, 20f, -3);
        }

        if (fc.GetBooleanVariable("Director_call") == true) //폐쇄연구실 확인하라고 국장이 호출
        {
            Player.GetComponent<SpriteRenderer>().flipX = true;
            Player.transform.position = new Vector2(-13f, 20f);
            Camera.transform.position = new Vector3(-13f, 20f, -3);
        }

        if (fc.GetBooleanVariable("Forbidden_call") == true)
        {
            Player.GetComponent<SpriteRenderer>().flipX = false;
            Player.transform.position = new Vector2(-50f, 20f);
            Camera.transform.position = new Vector3(-50f, 20f, -3);
        }
        if (fc_event.GetBooleanVariable("GuardEvent") == true && DataManager.instance.game_temp[5] == false)
        {
            Player.GetComponent<SpriteRenderer>().flipX = false;
            Player.transform.position = new Vector2(-77f, -64.8f);
            Camera.transform.position = new Vector3(-77f, -59.8f, -3);
            Player.transform.GetChild(1).gameObject.SetActive(true);
        }
        
            // 0 6 7 9 10 13 15 17 18 19 22 23 24

            if (DataManager.instance.item_temp[0] == true&& DataManager.instance.item_temp[6] == true && DataManager.instance.item_temp[7] == true && DataManager.instance.item_temp[9] == true && DataManager.instance.item_temp[10] == true && DataManager.instance.item_temp[13] == true && DataManager.instance.item_temp[15] == true && DataManager.instance.item_temp[17] == true && DataManager.instance.item_temp[18] == true && DataManager.instance.item_temp[19] == true && DataManager.instance.item_temp[22] == true && DataManager.instance.item_temp[23] == true && DataManager.instance.item_temp[24] == true)
            fc.SetBooleanVariable("itemMaster", true);

            /*
            //린다이벤트, 레지스탕스 이벤트 관리
        if (DataManager.instance.item_temp[19] == true && DataManager.instance.game_temp[4] == false)
        {
            Resistant1.SetActive(true);
        }
        else if (DataManager.instance.game_temp[4] == true && Resistant1 != null)
            Destroy(Resistant1, 2f);

        if (Player.transform.GetChild(1).gameObject.activeSelf == true)
        {
            LindaEvent.SetActive(true);
        }
        else if (DataManager.instance.game_temp[5] == true && LindaEvent != null)
            Destroy(LindaEvent);
            */
    }
    
    public void CheckGame()
    {
        for (int i = 0; i < 7; i++)
        {
            print("게임" + $"{i}" + " : " + $"{DataManager.instance.nowPlayer.game[i]} \n");
        }
    }

    public void CheckItem()
    {
        for (int i = 0; i < 26; i++)
        {
            print("아이템" + $"{i}" + " : " + $"{DataManager.instance.item_temp[i]} \n");
        }

    }

    public void SaveTab()
    {
        Savetab.SetActive(true);
        panel_bg.SetActive(true);
    }

    public void ExitTab()
    {
        Savetab.SetActive(false);
        panel_bg.SetActive(false);
    }

    public void GoTitle()
    {
        SceneManager.LoadScene(0);
        DataManager.instance.game_temp = new bool[7];
        DataManager.instance.item_temp = new bool[26];
        DataManager.instance.item_i_temp = new bool[24];
        DataManager.instance.box_temp = new bool[12];
        DataManager.instance.item_s_temp = new bool[12];
        DataManager.instance.DataClear();

        Fungus.Flowchart.BroadcastFungusMessage("ResetGame");
    }
}
