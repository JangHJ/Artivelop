using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer s_render;
    SpriteRenderer s_render2;

    GameObject map;
    

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("3F_Hallway").gameObject.transform.GetChild(2).gameObject;
        s_render = map.GetComponent<SpriteRenderer>();
        //s_render2 = GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
        if (DataManager.instance.game_temp[2] == true)
        {
            s_render.sprite = sprites[1];
            //s_render2.enabled = false;
        }
    }
}
