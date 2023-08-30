using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextActive : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler, IDragHandler, IBeginDragHandler,IEndDragHandler
{
    public GameObject Text;
    Vector3 currentposition;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Text.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentposition = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        transform.position = currentposition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
}
