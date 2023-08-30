using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControllers : MonoBehaviour
{
    

       
       
     private Rigidbody2D rb2D;
     bool a = false;
     // Start is called before the first frame update
     void Start()
     {
         rb2D = gameObject.GetComponent<Rigidbody2D>();
     }

     private void OnMouseDrag()
     {
         a = true;
         Vector3 mousePosition
         = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);//마우스 좌표를 스크린 투 월드로 바꾸고 이 객체의 위치로 설정해 준다.
         rb2D.MovePosition(Camera.main.ScreenToWorldPoint(mousePosition));
     }
     private void OnTriggerEnter(Collider other)
     {
         Debug.Log("ddd");
     }

     // Update is called once per frame
     void FixedUpdate()
     {

     }
    /*public float moveSpeed = 4;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir += Vector3.up;
            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir += Vector3.down;
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir += Vector3.left;
           
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir += Vector3.right;
           
        }

        transform.position += moveDir * Time.deltaTime * moveSpeed;
    }*/
}
