using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class select_mouseover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
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
    
    void Update()
    {
        
    }
    
}
