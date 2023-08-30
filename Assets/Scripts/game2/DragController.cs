using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    // Start is called before the first frame update
    public int number = 1;
    private float distance = 10.0f;
    Vector3 ObjectPosition = Vector3.zero;
    public float X = 3.0f;
    public float Y = 3.0f;
    Vector3 fixedPosition;
    bool crash = false;
    private void Start()
    {
        
    }
    private void OnMouseDown()
    {
        X = transform.position.x;
        Y = transform.position.y;
        //mouse = true;
    }
    
    private void OnMouseDrag()
    {

        if (crash == false)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 tempPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (number == 1)
            {
                tempPosition.y = Y;
            }
            else
            {
                tempPosition.x = X;
            }

            tempPosition.z = 0;
            transform.position = tempPosition;
        }

    }
    private void OnMouseUp()
    {
        crash = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       fixedPosition = this.gameObject.transform.position;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        fixedPosition = this.gameObject.transform.position;
        crash = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
       // Debug.Log(gameObject.name + "collision ¹ß»ý");
         //  this.gameObject.transform.position = fixedPosition;
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        crash = false;
    }


}
