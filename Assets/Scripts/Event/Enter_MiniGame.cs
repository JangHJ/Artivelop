using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Enter_MiniGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject item;
    public int game_num;
    public int item_num;
    public string sceneName;
    public string message;
    public Sprite[] sprites;
    public GameObject Room;
    public Flowchart fc_event;
    bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
        Player = GameObject.Find("Pola");
        item = gameObject.transform.GetChild(0).gameObject;
        Room = GameObject.Find("3F_Hallway").transform.GetChild(2).gameObject;
        if (DataManager.instance.game_temp[game_num] == true && DataManager.instance.item_temp[item_num]== true)
        {
            Room.GetComponent<SpriteRenderer>().sprite = sprites[0];
            Destroy(gameObject);
        }
        else if (DataManager.instance.game_temp[game_num] == true && DataManager.instance.item_temp[item_num] == false)
        {
            Room.GetComponent<SpriteRenderer>().sprite = sprites[1];
            item.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (DataManager.instance.item_temp[item_num] == true)
        {
            Destroy(item);
            Destroy(gameObject);
        }
        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E) && DataManager.instance.game_temp[game_num] == false)
            {
                DataManager.instance.nowPlayer.pos = Player.transform.position;
                SceneManager.LoadScene(sceneName);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter = true;
            if (DataManager.instance.game_temp[game_num] == true)
            {
                item.SetActive(false);
                Fungus.Flowchart.BroadcastFungusMessage(message);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isEnter = false;
            Room.GetComponent<SpriteRenderer>().sprite = sprites[0];
            item.SetActive(false);
        }
    }
  
}
