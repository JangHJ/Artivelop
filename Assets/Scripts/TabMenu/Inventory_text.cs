using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory_text : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{ 
    public GameObject text;
    public GameObject image;
    public GameObject TabMenu;
    public GameObject DefaultImage;
    public GameObject DefaultText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        DefaultImage.SetActive(false);
        DefaultText.SetActive(false);
        text.SetActive(true);
        image.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.SetActive(false);
        image.SetActive(false);
        DefaultImage.SetActive(true);
        DefaultText.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (TabMenu.activeSelf == false)
        {
            text.SetActive(false);
            image.SetActive(false);
            DefaultImage.SetActive(true);
            DefaultText.SetActive(true);
        }
    }
}
