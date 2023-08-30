using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagActive : MonoBehaviour,IPointerClickHandler
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
        Bag.SetActive(true);
        Map.SetActive(false);
        Map_Icon.SetActive(false);
        Bag_Icon.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
