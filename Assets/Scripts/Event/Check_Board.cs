using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.UI;

public class Check_Board : MonoBehaviour
{
    public GameObject Board;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.instance.item_temp[15] == true) //직업관리리스트를 얻었다면 인터랙션 종료.
        {
            GetComponent<Check_Board>().enabled = false;
            GetComponent<InteractionCtrl>().enabled = false;
        }
        isEnter = false;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            isEnter = true;
            Board.SetActive(true);
            Fungus.Flowchart.BroadcastFungusMessage("check_birthday");
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        Board.SetActive(false);
        isEnter = false;
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.E) && Board.activeSelf == true)
        {
            Board.SetActive(false);
        }*/
    }
}
