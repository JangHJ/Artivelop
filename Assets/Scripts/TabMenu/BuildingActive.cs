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
    public GameObject PlayerPosition_b;//���������� �÷��̾� ��ġ
    public GameObject PlayerPosition_t;//���������� �÷��̾� ��ġ
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
