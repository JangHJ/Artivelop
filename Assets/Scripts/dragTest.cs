using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragTest : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public GameObject CardPad;
    public GameObject CardPadPanel;
    public Sprite spr_unlock;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;

        print("DefaultPos.y : " + DefaultPos.y);
        print("eventData.position.y : " + eventData.position.y);

        this.transform.position = currentPos;

       

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if ((DefaultPos.y + eventData.position.y) < 1000f)
        {
            CardPad.GetComponent<Image>().sprite = spr_unlock;
            Fungus.Flowchart.BroadcastFungusMessage("SRKey_Use");
            Destroy(CardPadPanel, 1.5f);
        }
        else
        {
            Fungus.Flowchart.BroadcastFungusMessage("SRKey_fail");
        }

        this.transform.position = DefaultPos;
    }
}
