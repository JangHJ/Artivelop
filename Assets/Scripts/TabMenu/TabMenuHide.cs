using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabMenuHide : MonoBehaviour,IPointerClickHandler
{
    public GameObject TabMenu;
    public GameObject panel_bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel_bg.SetActive(false);
        TabMenu.SetActive(false);
     
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
}
