using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class TimeController : MonoBehaviour
{
    //public GameObject gameEnd;
    static public bool info_=false;
    public Text UITIME;
    public Text State;
    AudioSource audiosource;
    public static bool GameSuccess;

    int sec;
    // Start is called before the first frame update
    void Start()
    {
        GameSuccess = false;

        sec = 30;
        InvokeRepeating("SetTime", 1f, 1f);
        audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetTime()
    {
        if (info_ == true)
        {

            if (GameSuccess == false)
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
            }
            if (sec == 0)
            {
                audiosource.Play();
                State.text = "FAILED";
                Fungus.Flowchart.BroadcastFungusMessage("isMove_true");
                Invoke("sceneChange", 4);
                UITIME.enabled = false;
            }
        }


    }
    void sceneChange()
    {
        SceneManager.LoadScene("main");
    }
}
