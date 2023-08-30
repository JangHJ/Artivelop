using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;

public class cardPadCtrl : MonoBehaviour
{
    public Flowchart fc_event;
    public GameObject CardPad;
    public GameObject CardPad_spr;
    public GameObject CardPad_unlock;
    public Sprite spr_unlock;
    bool isEnter = false;

    // Update is called once per frame
    void Update()
    {
        if (fc_event.GetBooleanVariable("SRCard_USE") == true && CardPad != null)
        {
            CardPad_unlock.SetActive(true);
            CardPad_spr.GetComponent<Image>().sprite = spr_unlock;

            Destroy(CardPad, 3.0f);
        }

        if (isEnter == true)
        {
            if(Input.GetKey(KeyCode.E) && DataManager.instance.item_temp[25] == true && CardPad != null)
                CardPad.SetActive(true);
        }
        //if(startPosition.y == )
    }


    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        fc_event = GameObject.Find("Flowchart_event").GetComponent<Flowchart>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (CardPad != null && CardPad.activeSelf == true)
            CardPad.SetActive(false);

        isEnter = false;
    }
}
