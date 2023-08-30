using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingActive : MonoBehaviour,IPointerClickHandler
{
    public GameObject player;
    public GameObject building_Icon;
    public GameObject town_Icon;
    public GameObject building_map;
    public GameObject town_map;
    public GameObject PlayerPosition_b;//관리국에서 플레이어 위치
    public GameObject PlayerPosition_t;//마을에서의 플레이어 위치
    // Start is called before the first frame update
    void Start()
    {

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        building_Icon.SetActive(true);
        town_Icon.SetActive(false);
        building_map.SetActive(true);
        town_map.SetActive(false);
        if (player.transform.position.y > -33)
        {
            PlayerPosition_b.SetActive(true);
        }
        PlayerPosition_t.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
