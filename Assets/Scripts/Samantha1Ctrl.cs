using Fungus;
using UnityEngine;
public class Samantha1Ctrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Alarm;
    public Flowchart fc;
    
    SpriteRenderer renderer_;

    int count = 0;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();

        Player = GameObject.Find("Pola");
        Alarm = gameObject.transform.GetChild(0).gameObject;
        renderer_ = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fc.GetIntegerVariable("day") != 1)
        {
            Alarm.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (fc.GetIntegerVariable("day") == 1)
        {
            Alarm.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }


        if (isEnter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Alarm.SetActive(false);
                Fungus.Flowchart.BroadcastFungusMessage("samantha_talk1");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Alarm.SetActive(true);
            isEnter = false;
        }
    }
}
