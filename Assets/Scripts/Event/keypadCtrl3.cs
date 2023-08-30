using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class keypadCtrl3 : MonoBehaviour
{
    public Text KeypadTxt;
    public Flowchart fc_event;
    public GameObject KeyPad;
    public GameObject KeyPad_unlock;
    public Sprite spr_unlock;
    // Start is called before the first frame update
    void Start()
    {
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Input_Key0()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "0";
    }
    public void Input_Key1()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "1";
    }
    public void Input_Key2()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "2";
    }
    public void Input_Key3()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "3";
    }
    public void Input_Key4()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "4";
    }
    public void Input_Key5()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "5";
    }
    public void Input_Key6()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "6";
    }
    public void Input_Key7()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "7";
    }
    public void Input_Key8()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "8";
    }
    public void Input_Key9()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        if (KeypadTxt.text == "비밀번호를 입력하세요")
            KeypadTxt.text = "";
        KeypadTxt.text = KeypadTxt.text + "9";
    }
    public void Input_KeyEnter()
    {
        if (KeypadTxt.text == "0607")
        {
            KeyPad.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //KeyPad.transform.GetChild(0).gameObject.transform.GetComponent<Image>().sprite = spr_unlock;
            KeypadTxt.text = "비밀번호 입력완료";
            Fungus.Flowchart.BroadcastFungusMessage("Keypad_ON3");
            //KeyPad_unlock.SetActive(true);
            Destroy(KeyPad, 1.5f);
        }
        else
        {
            print(KeypadTxt.text);
            Fungus.Flowchart.BroadcastFungusMessage("Keypad_fail");
            KeypadTxt.text = "";
        }
    }
    public void Input_KeyBack()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Keypad_Click");
        int textLength = KeypadTxt.text.Length;

        if (textLength > 0)
        {
            KeypadTxt.text = KeypadTxt.text.Substring(0, textLength - 1);
        }
        else
        {
            KeypadTxt.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.E) && fc_event.GetBooleanVariable("keypadON3") == false)
        {
            KeyPad.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(KeyPad != null && KeyPad.activeSelf == true)
            KeyPad.SetActive(false);
    }
}
