using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class info_spriteChange5 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Image group;
    public Sprite[] images;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = images[1];
        // this.gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = images[0];
    }
    // Update is called once per frame

    public void OnPointerDown(PointerEventData eventData)
    {
        group.enabled = false;
        image.enabled = false;
        InputFieldController.info_ = true;
    }

    void Update()
    {

    }

}
