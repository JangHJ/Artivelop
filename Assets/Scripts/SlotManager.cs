using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SlotManager : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    public Text[] timeText;

    bool[] savefile = new bool[3];


    // Start is called before the first frame update
    void Start()
    {
        // ���Ժ��� ����� �����Ͱ� �ִ��� �Ǵ�
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = "���� ����" + $"{i + 1}";
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        //����� �����Ͱ� ���� ��
        if (savefile[number])
        {
            DataManager.instance.LoadData();
            GoGame();
        }
        else
            print("����� �����Ͱ� �����ϴ�.");
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
