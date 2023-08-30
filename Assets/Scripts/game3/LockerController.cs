using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LockerController : MonoBehaviour
{
    public GameObject locker1;
    public GameObject locker2;
    public GameObject locker3;
    bool Execution = true;
    public Text state;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (locker1.transform.rotation.eulerAngles.z > 90 && locker1.transform.rotation.eulerAngles.z < 120
            && locker2.transform.rotation.eulerAngles.z > 90 && locker2.transform.rotation.eulerAngles.z < 120
            && locker3.transform.rotation.eulerAngles.z > 90 && locker3.transform.rotation.eulerAngles.z < 120 && Execution==true)
        {
            state.text = "SUCCESS";
            TimeController.GameSuccess = true;
            Execution = false;
            Debug.Log("락커 열림");
            audioSource.Play();
            //Fungus.Flowchart.BroadcastFungusMessage("isMove_true");
            DataManager.instance.game_temp[2] = true;
            //DataManager.instance.pos_temp = new Vector2(74.5f, 9.5f);

            Invoke("sceneChange", 2);



        } 
        
    }
    void sceneChange()
    {
        SceneManager.LoadScene("main");
    }

    public void ClearGame()
    {
        DataManager.instance.game_temp[2] = true;
        
        DataManager.instance.pos_temp = new Vector2(74.5f, 9.5f);
        SceneManager.LoadScene("main");
    }
}
