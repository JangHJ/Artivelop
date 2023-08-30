using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieceController : MonoBehaviour
{
    AudioSource audioSource;
    public int shape = 0;
    public static float number = 0f;
    int n = 0;
    int answer;
    private void OnMouseDown()
    {
        audioSource.Play();
        transform.Rotate(0,0,90,Space.Self);

        if (shape == 0)
        {
            if (transform.rotation.z == 0)
            {
                number += 100 / 16f;
            }
            else if (transform.eulerAngles.z == 90)
            {
                number -= 100 / 16f;
            }
        }
        else
        {
            if (transform.rotation.z == 0)
            {
                number += 100 / 16f;
            }
            else if (transform.eulerAngles.z == 90)
            {
                number -= 100 / 16f;
            }
            else if (transform.eulerAngles.z == 180)
            {
                number += 100 / 16f;
            }
            else if (transform.eulerAngles.z == 270)
            {
                number -= 100 / 16f;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
