using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class arrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject setting;
    public GameObject Menu;
    public GameObject Arrow;
    //public GameObject background;
    //public GameObject noTitle;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = Arrow.GetComponent<Image>().color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        color.a = 1f;
        Arrow.GetComponent<Image>().color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        color.a = 0f;
        Arrow.GetComponent<Image>().color = color;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        setting.SetActive(false);
        Menu.SetActive(true);
        //background.SetActive(false);
        //noTitle.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
