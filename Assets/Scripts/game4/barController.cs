using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.Space) && this.transform.position.y < 1.5)
            {
            
                transform.Translate(Vector3.up * 0.08f);
            
            }
            else if(this.transform.position.y>-3.4)
            {
                transform.Translate(Vector3.down * 0.08f);
            }
            
    }
}
