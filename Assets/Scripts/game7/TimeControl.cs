using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeControl : MonoBehaviour
{
    static public bool info_ = false;
    //public GameObject gameEnd;
    public Text UITIME;
    public Text State;
    int sec;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        sec = 60;
        InvokeRepeating("SetTime", 1f, 1f);
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetTime()
    {
        if (info_ == true)
        {
            sec = sec - 1;
            if (sec < 10)
            {
                UITIME.text = "00:0" + sec;
            }
            else
            {
                UITIME.text = "00:" + sec;
            }

            if (sec == 0)
            {
                State.text = "FAILED";
                audioSource.Play();
                Invoke("scenechange", 4);
                UITIME.enabled = false;

            }
        }
        
    }
    void scenechange()
    {
        SceneManager.LoadScene("main");
    }
}

