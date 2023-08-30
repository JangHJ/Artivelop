using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class setting_active : MonoBehaviour, IPointerClickHandler
{
    public GameObject setting;
    public GameObject Menu;
    public Sprite sprite;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        image.sprite = sprite;
        setting.SetActive(true);
        Menu.SetActive(false);
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
