using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{

    public GameObject one;
    public GameObject two;
    public Slider gauge;
    public GameObject test;
    //public GameObject canvas;
    public Text state;
    AudioSource audioSource;
    bool successSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        successSound = false;

    }

    // Update is called once per frame
    void Update()
    {
        float a = one.transform.position.y - two.transform.position.y;
        if((-0.6 < a) && (a < 0.6))
        {
            //anim.SetBool("action", true);
            gauge.value = gauge.value+ 0.002f;
        }
        else
        {
          //  anim.SetBool("action", false);

        }
        if (gauge.value >= 1)
        {
            if (successSound == false)
            {
                audioSource.Play();
                successSound = true;
            }
            TimeController.GameSuccess = true;
            state.text = "SUCCESS";

            DataManager.instance.game_temp[3] = true;
            DataManager.instance.item_temp[15] = true;
            DataManager.instance.item_i_temp[14] = true;
            DataManager.instance.item_s_temp[6] = true;
            Fungus.Flowchart.BroadcastFungusMessage("isMove_true");
            Invoke("sceneChange", 4);
            //test.SetActive(true);
            //canvas.SetActive(false);

        }
    }
    void sceneChange()
    {
        SceneManager.LoadScene("main");
    }
}
