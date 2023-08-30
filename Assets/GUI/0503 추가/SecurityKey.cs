using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            DataManager.instance.item_temp[23] = true;
            Destroy(gameObject);
        }
    }
}
