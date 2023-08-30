using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenuActive : MonoBehaviour
{
    public GameObject panel_bg;
    public GameObject tabMenu;
    public GameObject player;
    public GameObject building_Icon;
    public GameObject town_Icon;
    public GameObject building_map;
    public GameObject town_map;
    public GameObject PlayerPosition_b;//관리국에서 플레이어 위치
    public GameObject PlayerPosition_t;//마을에서의 플레이어 위치
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && tabMenu.activeSelf == false)
        {
                panel_bg.SetActive(true);
                tabMenu.SetActive(true);
            if (player.transform.position.y > -33)
            {
                building_Icon.SetActive(true);
                town_Icon.SetActive(false);
                building_map.SetActive(true);
                town_map.SetActive(false);
                PlayerPosition_b.SetActive(true);
                PlayerPosition_t.SetActive(false);
            }
            else {
                building_Icon.SetActive(false);
                town_Icon.SetActive(true);
                building_map.SetActive(false);
                town_map.SetActive(true);
                PlayerPosition_b.SetActive(false);
                PlayerPosition_t.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && tabMenu.activeSelf == true)
        {
            panel_bg.SetActive(false);
            tabMenu.SetActive(false);
        }



        /*if (Input.GetKey(KeyCode.Tab))
        {
            if (active == false)
            {
                tabMenu.SetActive(true);
                active = true;
            }
            else
            {
                tabMenu.SetActive(false);
                active = false;
            }
        }*/
    }

}
