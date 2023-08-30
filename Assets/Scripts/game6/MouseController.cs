using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    Vector3 pos;

    private void OnMouseOver()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition);
        Vector3 p = new Vector3(objPosition.x, -3.8f, 10);
        if (p.x < -7)
        {
            player.transform.position = new Vector3(-7f, -3.8f, 10);
        }
        else if (p.x > 6.5f)
        {
            player.transform.position = new Vector3(6.5f, -3.8f, 10);
        }
        else
        {
            player.transform.position = p;
        }
    }
    private void OnMouseExit()
    {
       // player.transform.position = pos;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
