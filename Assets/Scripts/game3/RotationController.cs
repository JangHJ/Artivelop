using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public AudioClip beep1;
    public AudioClip beep2;
    float angle;
    Vector2 target, mouse;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        this.audioSource = GetComponent<AudioSource>();
        if (Input.GetMouseButton(0))
        {
            if (this.transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 120)

            {
                audioSource.clip = beep2;

                if (audioSource.isPlaying == false)
                    audioSource.Play();

            }
            else
            {
                audioSource.clip = beep1;
                if (audioSource.clip == beep1 && audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
        }
        
    }

    void Update()
    {
       
    }
}
