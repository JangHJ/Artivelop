using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class info_spriteChange4 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Image group;
    public Sprite[] images;
    public Image startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
       startButton.sprite = images[1];
        // this.gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startButton.sprite = images[0];
    }
    // Update is called once per frame

    public void OnPointerDown(PointerEventData eventData)
    {
        group.enabled = false;
        startButton.enabled = false;
        TimeController.info_ = true;
    }

    private void OnMouseDown()
    {
        group.enabled = false;
        startButton.enabled = false;
        TimeController.info_ = true;
    }

    void Update()
    {

    }
}
