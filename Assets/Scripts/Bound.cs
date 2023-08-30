using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    private BoxCollider2D bound;
    public string boundName;
    private CameraManager theCamera;

    // Start is called before the first frame update
    void Start()
    {
        bound = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraManager>();
    }

    public void SetBound()
    {
        theCamera.SetBound(bound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
