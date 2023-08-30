using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class DragController_x : MonoBehaviour
{

 
    public Text state;
    AudioSource audiosource;

    private void Start()
    {
        print(DataManager.instance.nowSlot);
        audiosource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)//실제 작동되는 함수
    {
        if (collision.gameObject.name == "targetItem")
        {
            //audiosource.Play();
            state.text = "SUCCESS";

            DataManager.instance.game_temp[1] = true;
            DataManager.instance.item_temp[10] = true;
            DataManager.instance.item_s_temp[4] = true;
            print(DataManager.instance.nowSlot);
            Fungus.Flowchart.BroadcastFungusMessage("isMove_true");
            Invoke("sceneChange", 2f);

        }
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "targetItem")
        {
            audiosource.Play();
            //DataManager.instance.game_temp[1] = true;
            state.text = "SUCCESS";

            DataManager.instance.game_temp[1] = true;
            DataManager.instance.item_temp[10] = true;
            DataManager.instance.item_s_temp[4] = true;

            Fungus.Flowchart.BroadcastFungusMessage("isMove_true");
            Invoke("sceneChange", 2f);
        }
        Debug.Log(collision.gameObject.name);
    }

    void sceneChange()
    {
        SceneManager.LoadScene("main");
    }

    void Update()
    {
  
    }
}
