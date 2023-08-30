using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapActive : MonoBehaviour,IPointerClickHandler
{
    public GameObject Bag;
    public GameObject Map;
    public GameObject Map_Icon;
    public GameObject Bag_Icon;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Bag.SetActive(false);
        Map.SetActive(true);
        Map_Icon.SetActive(true);
        Bag_Icon.SetActive(false);
    }
  

    // Update is called once per frame
    void Update()
    {

    }
}
