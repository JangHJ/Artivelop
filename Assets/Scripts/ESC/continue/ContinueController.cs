using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContinueController : MonoBehaviour, IPointerClickHandler
{
    public GameObject setting;
    public GameObject panel_bg;
    public Sprite sprite;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        setting.SetActive(false);
        panel_bg.SetActive(false);
        image.sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
