using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Enter_MiniGame3 : MonoBehaviour
{
    public GameObject Player;
    public GameObject item;
    public int game_num;
    public int item_num;
    public string sceneName;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");

        if (DataManager.instance.game_temp[game_num] == true && DataManager.instance.item_temp[item_num] == true)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKey(KeyCode.E) && coll.gameObject.tag == "Player") 
        {
            if (DataManager.instance.item_temp[item_num] == false)
            {
                Fungus.Flowchart.BroadcastFungusMessage("Testwater_need");
            }
            else if (DataManager.instance.game_temp[game_num] == false)
            {
                DataManager.instance.nowPlayer.pos = Player.transform.position;
                //DataManager.instance.pos_temp = Player.transform.position;
               // Fungus.Flowchart.BroadcastFungusMessage("SaveGame");
                SceneManager.LoadScene(sceneName);
            }
        }
        if (DataManager.instance.game_temp[game_num] == true && coll.gameObject.tag == "Player")
        {
           // Fungus.Flowchart.BroadcastFungusMessage("LoadGame");
            item.SetActive(true);
            Fungus.Flowchart.BroadcastFungusMessage(message);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
