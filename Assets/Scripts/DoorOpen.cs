using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    public Sprite spr1;
    public Sprite spr2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spr2;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spr1;
    }
}
