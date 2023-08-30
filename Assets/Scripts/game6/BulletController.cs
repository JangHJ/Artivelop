using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.Find("Player").transform.position;
        myPos = transform.position;

        newPos = (targetPos - myPos) * 0.007f;
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + newPos;

        
         if(transform.position.x <-6.7 || transform.position.x > 6.5)
        {
            Destroy(gameObject);
        }
        if(transform.position.y<-4.5)
        {
            Destroy(gameObject);
        }
        
    }
}
