using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_data : MonoBehaviour
{
    public GameObject[] itemLists;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 24; i++)
        {
            if (DataManager.instance.item_i_temp[i] == true)
            {
                itemLists[i].SetActive(true);
            }
            
        }

    }
}
