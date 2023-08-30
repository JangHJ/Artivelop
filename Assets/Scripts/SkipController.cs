using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class SkipController : MonoBehaviour
{
    public GameObject Bella2;
    public GameObject player;
    public GameObject Bella_3_2;
    public GameObject Bella5;
    //public GameObject Governer;
    public GameObject Bella4;
    public Flowchart fc_event;
    public Flowchart fc_chat;
    public Button Dougnut;
    public Button meetsamantha;
    public Button todorm;
    public Button minigame;
    public Button Bella32;
    public Button Bella44;
    public Button ending_sup;
    public Button revenge2;
    public Text gaslighting;

    // Start is called before the first frame update
    void Start()
    {
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        fc_chat = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
       /* meetsamantha.GetComponent<Button>().interactable = false;
        todorm.GetComponent<Button>().interactable = false;
        minigame.GetComponent<Button>().interactable = false;
        Bella32.GetComponent<Button>().interactable = false;
        Bella44.GetComponent<Button>().interactable = false;
        ending_sup.GetComponent<Button>().interactable = false;
        revenge2.GetComponent<Button>().interactable = false;*/

    }

    // Update is called once per frame
    void Update()
    {
        gaslighting.text = "가스라이팅 답변 횟수 : " + fc_chat.GetIntegerVariable("gasLighting");
    }
    public void pressSkipDougnut()
    {
        fc_event.SetBooleanVariable("SecurityCard", true);
        fc_event.SetBooleanVariable("SRCard_USE", true);
        fc_chat.SetIntegerVariable("goal", 2);
        fc_chat.SetIntegerVariable("normal", 1);
        fc_chat.SetIntegerVariable("bellaChat", 1);
        fc_chat.SetBooleanVariable("isMove", true);
        DataManager.instance.item_temp[0] = true;
        DataManager.instance.item_temp[17] = true;
        DataManager.instance.item_temp[25] = true;
        DataManager.instance.item_i_temp[0] = true;
        DataManager.instance.item_i_temp[15] = true;
        DataManager.instance.item_i_temp[23] = true;
        DataManager.instance.item_s_temp[0] = true;
        DataManager.instance.item_s_temp[7] = true;
        player.transform.position = new Vector3(-25, -12.5f, 0);
        meetsamantha.GetComponent<Button>().interactable = true;
    }

    public void MeetSaMantha()
    {
        player.transform.position = new Vector3(-127.4612f, -1.5f, 0);
        todorm.GetComponent<Button>().interactable = true;
    }
    public void ToDorm()
    {
        fc_chat.SetIntegerVariable("bellaChat", 2);
        fc_chat.SetIntegerVariable("day", 2);
        fc_chat.SetIntegerVariable("goal", 3);
        fc_chat.SetIntegerVariable("gasLighting", 1);
        fc_chat.SetIntegerVariable("normal", 1);
        fc_chat.SetIntegerVariable("samanthaChat", 2);
        fc_chat.SetBooleanVariable("robinChat", true);
        fc_event.SetBooleanVariable("cardKey3F", true);
        fc_event.SetBooleanVariable("keypadON", true);
        fc_event.SetBooleanVariable("doughnut", true);
        DataManager.instance.item_temp[1] = true;
        DataManager.instance.item_temp[2] = true;
        DataManager.instance.item_i_temp[1] = true;
        DataManager.instance.item_i_temp[2] = true;
        player.transform.position = new Vector3(-121.5437f, -1.5f, 0);
        Bella2.SetActive(false);
        minigame.GetComponent<Button>().interactable = true;
    }
    public void ToMinigame()
    { 
        player.transform.position = new Vector3(-41.1f, -46.2f, 0);
        fc_chat.SetIntegerVariable("goal", 5);
        fc_chat.SetIntegerVariable("gasLighting", 2);
        fc_chat.SetBooleanVariable("DirectorChat3_1", true);
        fc_event.SetBooleanVariable("samanthaQuiz", true);
        fc_event.SetBooleanVariable("ChimeraNametag", true);
        fc_event.SetBooleanVariable("DrugReport", true);
        DataManager.instance.item_temp[4] = true;
        DataManager.instance.item_temp[6] = true;
        DataManager.instance.item_temp[7] = true;
        DataManager.instance.item_temp[8] = true;
        DataManager.instance.item_i_temp[4] = true;
        DataManager.instance.item_i_temp[6] = true;
        DataManager.instance.item_i_temp[7] = true;
        DataManager.instance.box_temp[0] = true;
        DataManager.instance.box_temp[1] = true;
        DataManager.instance.box_temp[2] = true;
        DataManager.instance.item_s_temp[0] = false;
        DataManager.instance.item_s_temp[7] = false;
        QuizController.box = 3;
        Bella32.GetComponent<Button>().interactable = true;
    }
    public void Bella3_2()
    {
        player.transform.position = new Vector3(-3.6f, 9.5f, 0);
        fc_chat.SetIntegerVariable("goal", 14);
        fc_chat.SetIntegerVariable("gasLighting", 3);
        fc_chat.SetBooleanVariable("bellaChat3_1", true);
        fc_chat.SetStringVariable("quater1", "A");
        fc_event.SetBooleanVariable("keypadON2", true);
        fc_event.SetBooleanVariable("LockerKey", true);
        fc_event.SetBooleanVariable("Gown", true);
        fc_event.SetBooleanVariable("water", true);
        fc_event.SetBooleanVariable("LabKey", true);
        QuizController.box = 10;
        for(int i = 6; i < 20; i++)
        {
            DataManager.instance.item_temp[i] = true;
        }
        DataManager.instance.game_temp[1] = true;
        DataManager.instance.game_temp[2] = true;
        DataManager.instance.game_temp[3] = true;
        for(int i = 0; i < 10; i++)
        {
            DataManager.instance.box_temp[i] = true;
        }
        
         for (int i = 6; i < 18; i++)
        {
            DataManager.instance.item_i_temp[i] = true;
        }
        for (int i = 0; i < 12; i++)
        {
            DataManager.instance.item_s_temp[i] = false;
        }
        Bella44.GetComponent<Button>().interactable = true;

    }
    public void Bella_4()
    {
        player.transform.position = new Vector3(4.322f, -12.5f, 0);
        fc_chat.SetIntegerVariable("goal", 16);
        fc_chat.SetIntegerVariable("gasLighting", 3);
        fc_chat.SetIntegerVariable("normal", 2);
        fc_chat.SetBooleanVariable("DirectorChat3_2", true);
        fc_chat.SetBooleanVariable("bellaChat3_2", true);
        fc_event.SetIntegerVariable("minigame5", 2);
        fc_event.SetBooleanVariable("RedScarf", true);
        fc_event.SetBooleanVariable("SecretCardkey", true);
        DataManager.instance.item_temp[20] = true;
        DataManager.instance.item_temp[21] = true;
        DataManager.instance.game_temp[4] = true;
        DataManager.instance.item_i_temp[18] = true;
        DataManager.instance.item_i_temp[19] = true;

    }
    public void Ending_Sup()
    {
        player.transform.position = new Vector3(-13, 20, 0);
        fc_event.SetBooleanVariable("keypadON3", true);
        fc_chat.SetBooleanVariable("itemMaster", true);
        fc_chat.SetBooleanVariable("bellaChat4", true);
        for(int i = 0; i < 26; i++)
        {
            DataManager.instance.item_temp[i] = true;
        }
        DataManager.instance.game_temp[6] = true;
        DataManager.instance.box_temp[10] = true;
        DataManager.instance.box_temp[11] = true;
        for (int i = 0; i < 24; i++)
        {
            DataManager.instance.item_i_temp[i] = true;
        }
        for (int i = 0; i < 12; i++)
        {
            DataManager.instance.item_s_temp[i] = false;
        }
        Bella5.GetComponent<SpriteRenderer>().enabled = true;
        Bella5.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void Ending_Revenge()
    {
        player.transform.position = new Vector3(-13, 20, 0);
        fc_chat.SetIntegerVariable("day", 2);
        fc_chat.SetIntegerVariable("goal", 16);
        fc_chat.SetIntegerVariable("gasLighting", 3);
        fc_chat.SetIntegerVariable("normal", 3);
        fc_chat.SetIntegerVariable("bellaChat", 2);
        fc_chat.SetIntegerVariable("samanthaChat", 2);
        fc_chat.SetBooleanVariable("robinChat", true);
        fc_chat.SetBooleanVariable("DirectorChat3_2", true);
        fc_chat.SetBooleanVariable("DirectorChat3_1", true);
        fc_chat.SetBooleanVariable("bellaChat3_2", true);
        fc_chat.SetBooleanVariable("bellaChat3_1", true);
        fc_chat.SetBooleanVariable("bellaChat4", true);
        fc_chat.SetStringVariable("quater1", "A");
        fc_chat.SetBooleanVariable("itemMaster", true);
        fc_event.SetBooleanVariable("keypadON", true);
        fc_event.SetBooleanVariable("keypadON2", true);
        fc_event.SetBooleanVariable("keypadON3", true);
        fc_event.SetBooleanVariable("doughnut", true);
        fc_event.SetBooleanVariable("cardKey3F", true);
        fc_event.SetBooleanVariable("samanthaQuiz", true);
        fc_event.SetBooleanVariable("ChimeraNametag", true);
        fc_event.SetBooleanVariable("DrugReport", true);
        fc_event.SetBooleanVariable("LockerKey", true);
        fc_event.SetBooleanVariable("Gown", true);
        fc_event.SetBooleanVariable("water", true);
        fc_event.SetBooleanVariable("SecurityCard", true);
        fc_event.SetBooleanVariable("SRCard_USE", true);
        fc_event.SetBooleanVariable("LabKey", true);
        fc_event.SetIntegerVariable("minigame5", 2);
        fc_event.SetBooleanVariable("RedScarf", true);
        fc_event.SetBooleanVariable("SecretCardkey", true);
        fc_chat.SetBooleanVariable("MasterChoice", true);
        for (int i = 0; i < 26; i++)
        {
            DataManager.instance.item_temp[i] = true;
        }
        DataManager.instance.game_temp[6] = true;
        DataManager.instance.box_temp[10] = true;
        DataManager.instance.box_temp[11] = true;
        for (int i = 0; i < 24; i++)
        {
            DataManager.instance.item_i_temp[i] = true;
        }
        for (int i = 0; i < 12; i++)
        {
            DataManager.instance.item_s_temp[i] = false;
        }
        Bella5.GetComponent<SpriteRenderer>().enabled = true;
        Bella5.GetComponent<BoxCollider2D>().enabled = true;





    }

    public void Ending_BellaDeath()
    {
        player.transform.position = new Vector3(-13, 20, 0);
        fc_chat.SetIntegerVariable("day", 2);
        fc_chat.SetIntegerVariable("goal", 16);
        fc_chat.SetIntegerVariable("gasLighting", 2);
        fc_chat.SetIntegerVariable("normal", 3);
        fc_chat.SetIntegerVariable("bellaChat", 2);
        fc_chat.SetIntegerVariable("samanthaChat", 2);
        fc_chat.SetBooleanVariable("robinChat", true);
        fc_chat.SetBooleanVariable("DirectorChat3_2", true);
        fc_chat.SetBooleanVariable("DirectorChat3_1", true);
        fc_chat.SetBooleanVariable("bellaChat3_2", true);
        fc_chat.SetBooleanVariable("bellaChat3_1", true);
        fc_chat.SetBooleanVariable("bellaChat4", true);
        fc_chat.SetStringVariable("quater1", "A");
        fc_chat.SetBooleanVariable("itemMaster", true);
        fc_event.SetBooleanVariable("keypadON", true);
        fc_event.SetBooleanVariable("keypadON2", true);
        fc_event.SetBooleanVariable("keypadON3", true);
        fc_event.SetBooleanVariable("doughnut", true);
        fc_event.SetBooleanVariable("cardKey3F", true);
        fc_event.SetBooleanVariable("samanthaQuiz", true);
        fc_event.SetBooleanVariable("ChimeraNametag", true);
        fc_event.SetBooleanVariable("DrugReport", true);
        fc_event.SetBooleanVariable("LockerKey", true);
        fc_event.SetBooleanVariable("Gown", true);
        fc_event.SetBooleanVariable("water", true);
        fc_event.SetBooleanVariable("SecurityCard", true);
        fc_event.SetBooleanVariable("SRCard_USE", true);
        fc_event.SetBooleanVariable("LabKey", true);
        fc_event.SetIntegerVariable("minigame5", 2);
        fc_event.SetBooleanVariable("RedScarf", true);
        fc_event.SetBooleanVariable("SecretCardkey", true);
        fc_chat.SetBooleanVariable("MasterChoice", false);
        for (int i = 0; i < 26; i++)
        {
            DataManager.instance.item_temp[i] = true;
        }
        DataManager.instance.game_temp[6] = true;
        DataManager.instance.box_temp[10] = true;
        DataManager.instance.box_temp[11] = true;
        for (int i = 0; i < 24; i++)
        {
            DataManager.instance.item_i_temp[i] = true;
        }
        for (int i = 0; i < 12; i++)
        {
            DataManager.instance.item_s_temp[i] = false;
        }
        Bella5.GetComponent<SpriteRenderer>().enabled = true;
        Bella5.GetComponent<BoxCollider2D>().enabled = true;





    }
}
