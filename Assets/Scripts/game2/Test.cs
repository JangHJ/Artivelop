using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int number = 0;
    Rigidbody2D o_rigidbody;
    public int size = 10;
    Vector3 mousePosition;
    Vector3 tempPosition;
    AudioSource AudioObject;

    // Start is called before the first frame update
    void Start()
    {
        o_rigidbody = GetComponent<Rigidbody2D>();
        AudioObject = GameObject.Find("Audio").GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        tempPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        o_rigidbody.mass = 1f;
        AudioObject.Play();
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 tempPosition2 = Camera.main.ScreenToWorldPoint(mousePosition2);
        if (number == 0)
        {
            float s = tempPosition.x - tempPosition2.x;
            if (s >= 0)
            {
                //Vector3 length_w = Vector3.left; 
                o_rigidbody.AddForce(Vector3.left* s* (0.7f),ForceMode2D.Impulse);
            }
            else
            {
                //Vector3 length_w = new Vector3(s, 0, 0); 
                o_rigidbody.AddForce(Vector3.right * (-0.7f) * s,ForceMode2D.Impulse);
            }
           
        }
        else
        {
            float s = tempPosition.y - tempPosition2.y;
            if (s >= 0)
            {
                //Vector3 length_w = Vector3.left; 
                o_rigidbody.AddForce(Vector3.down* s * (0.7f), ForceMode2D.Impulse);
            }
            else
            {
                //Vector3 length_w = new Vector3(s, 0, 0); 
                o_rigidbody.AddForce(Vector3.up * (-0.7f) * s, ForceMode2D.Impulse);
            }
            //Vector3 length_w = new Vector3(0,tempPosition2.y - tempPosition.y, 0);
            //o_rigidbody.AddForce(length_h);
        }
        
    }
    private void OnMouseUp()
    {
        o_rigidbody.velocity = Vector3.zero;
        o_rigidbody.angularVelocity = 0f;
        o_rigidbody.AddForce(Vector3.zero);
        o_rigidbody.mass = 100;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        o_rigidbody.velocity = Vector3.zero;
        o_rigidbody.angularVelocity = 0f;
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        o_rigidbody.velocity = Vector3.zero;
        o_rigidbody.angularVelocity = 0f;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        o_rigidbody.velocity = Vector3.zero;
        o_rigidbody.angularVelocity = 0f;
    }
}
