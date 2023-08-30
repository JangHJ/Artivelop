using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Enter_MiniGame2 : MonoBehaviour
{
    public GameObject Player;
    GameObject item;
    public int game_num;
    public int item_num;
    public string sceneName;
    public string message;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        Player = GameObject.Find("Pola");

        if (DataManager.instance.game_temp[game_num] == true && DataManager.instance.item_temp[item_num] == true)
        {
            Destroy(gameObject, 1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (DataManager.instance.game_temp[game_num] == false)
                {
                    DataManager.instance.nowPlayer.pos = Player.transform.position;
                    DataManager.instance.pos_temp = Player.transform.position;
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            isEnter = true;
        if (DataManager.instance.game_temp[game_num] == true)
        {
            Fungus.Flowchart.BroadcastFungusMessage(message);

            isEnter = false;
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            isEnter = false;
    }


}
