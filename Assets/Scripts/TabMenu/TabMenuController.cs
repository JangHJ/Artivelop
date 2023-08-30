using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenuController : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Camera.transform.position.x + this.transform.position.x, Camera.transform.position.y + this.transform.position.y, Camera.transform.position.z + this.transform.position.z);
    }
}
