using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Fungus;

public class SlotManager2 : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    public Text[] timeText;
    public Flowchart fc;

    public GameObject Player;
    public GameObject Camera;
    public GameObject Savetab;
    public GameObject Panel_bg;
    bool[] savefile = new bool[3];

    public void Rewrite()
    {
        // 슬롯별로 저장된 데이터가 있는지 판단
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = "저장 파일" + $"{i + 1}";
                timeText[i].text = DataManager.instance.nowPlayer.saveTime;
            }
            else
            {
                slotText[i].text = "";
                timeText[i].text = "";
            }
        }
        DataManager.instance.DataClear();
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");
        Camera = GameObject.Find("Main Camera");
        Rewrite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainItem()
    {

    }

    public void Slot(int number)
    {
        fc.SetIntegerVariable("slot", number+1);
        DataManager.instance.nowSlot = number;
        DataManager.instance.nowPlayer.pos = Player.transform.position;
        DataManager.instance.nowPlayer.saveTime = DateTime.Now.ToString("yyyy-MM-dd \n hh : mm");

        for (int i = 0; i < 7; i++)
        {
            if (DataManager.instance.game_temp[i] == true)
            {
                DataManager.instance.nowPlayer.game[i] = DataManager.instance.game_temp[i];
            }
        }

        for (int i = 0; i < 26; i++)
        {
            if (DataManager.instance.item_temp[i] == true)
            {
                DataManager.instance.nowPlayer.item[i] = DataManager.instance.item_temp[i];
            }
        }

        for (int i = 0; i < 12; i++)
        {
            if (DataManager.instance.box_temp[i] == true)
            {
                DataManager.instance.nowPlayer.box[i] = DataManager.instance.box_temp[i];
            }
        }

        for (int i = 0; i < 24; i++)
        {
            if (DataManager.instance.item_i_temp[i] == true)
            {
                DataManager.instance.nowPlayer.item_i[i] = DataManager.instance.item_i_temp[i];
            }
        }
        for (int i = 0; i < 12; i++)
        {
            if (DataManager.instance.item_s_temp[i] == true)
            {
                DataManager.instance.nowPlayer.item_s[i] = DataManager.instance.item_s_temp[i];
            }
        }

        DataManager.instance.nowPlayer.goal = fc.GetIntegerVariable("goal");
        DataManager.instance.pos_temp = new Vector2(0, -1.5f);
        Fungus.Flowchart.BroadcastFungusMessage("SaveGame");
        DataManager.instance.SaveData();
        Panel_bg.SetActive(false);
        Savetab.SetActive(false);
        print("저장되었습니다.");

        Rewrite();
    }

    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
}
