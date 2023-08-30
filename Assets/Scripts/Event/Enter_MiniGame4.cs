using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Enter_MiniGame4 : MonoBehaviour
{
    public GameObject Player;
    public GameObject portal;
    public int game_num;
    //public int item_num;
    public string sceneName;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKey(KeyCode.E) && coll.gameObject.tag == "Player") 
        {
            if (DataManager.instance.game_temp[game_num] == false)
            {
                DataManager.instance.nowPlayer.pos = Player.transform.position;
                //DataManager.instance.pos_temp = Player.transform.position;
               // Fungus.Flowchart.BroadcastFungusMessage("SaveGame");
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (DataManager.instance.game_temp[game_num] == true && coll.gameObject.tag == "Player")
        {
            portal.SetActive(true);
           // Fungus.Flowchart.BroadcastFungusMessage("LoadGame");
            Fungus.Flowchart.BroadcastFungusMessage(message);
            Destroy(gameObject, 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
