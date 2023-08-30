using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldController : MonoBehaviour
{
    static public bool info_ = false;
    public int number = 0;//mission1,2,3에서 번호를 넘기기 위한 인덱스 역할을 하는 수
    public Text txt; // inputfield의 text부분 접근을 위한 txt
    public Text mission1;
    public Text mission2;
    public Text mission3;
    //public GameObject gameEnd;
    //public GameObject gameOver;
    public Text Time;
    public Text State;
    public InputField inputField;
    int sec;
    AudioSource audioSource;
    public AudioClip successClip;
    bool success = false;

    // Start is called before the first frame update
    void Start()
    {
        sec = 60;
        InvokeRepeating("SetTime", 1f, 1f);
        audioSource = this.GetComponent<AudioSource>();

    }
    void SetTime()
    {
        if (info_ == true && success ==false)
        {
            sec = sec - 1;
            if (sec < 10)
            {
                Time.text = "00:0" + sec;
            }
            else
            {
                Time.text = "00:" + sec;
            }
            if (sec == 0)
            {
                State.text = "FAILED";
                audioSource.Play();
                //gameOver.SetActive(true);
                Invoke("failscene", 2);
                Time.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (number == 0)
        {
            mission1.color = Color.red;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                string str = txt.text;
            
                //txt.text.Replace(str, "");
                if (txt.text == "GR은가스등을좋아한다" || txt.text =="GR은 가스등을 좋아한다")
                {
                    //txt.text.Replace(str, "");

                    mission1.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";// 빈칸으로 만들게 하려는 의도로 text에 빈칸을 집어넣었습니다. 이부분이 작동되지 않는 것 같습니다.
                GetComponent<UnityEngine.UI.InputField>().ActivateInputField();
            }

        }
        else if (number == 1)
        {
            mission2.color = Color.red;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                string str = txt.text;
                //txt.text.Replace(str, "");
                if (txt.text == "키메라는초능력자와동갑일듯하다" || txt.text =="키메라는 초능력자와 동갑일 듯하다")
                {

                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//빈칸으로 만들게 하려는 의도로 text에 빈칸을 집어넣었습니다. 이부분이 작동되지 않는 것 같습니다.
                GetComponent<UnityEngine.UI.InputField>().ActivateInputField();
            }

        }
        else if (number == 2)
        {
            mission3.color = Color.red;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                string str = txt.text;
                //txt.text.Replace(str, "");

                if (txt.text == "GR의방에는키메라고향과이어지는통로가있다" || txt.text =="GR의 방에는 키메라 고향과 이어지는 통로가 있다")
                {

                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//빈칸으로 만들게 하려는 의도로 text에 빈칸을 집어넣었습니다. 이부분이 작동되지 않는 것 같습니다.
                GetComponent<UnityEngine.UI.InputField>().ActivateInputField();
            }

        }
        else
        {
            audioSource.clip = successClip;
            audioSource.Play();
            success = true;
            State.text = "SUCCESS";
            DataManager.instance.game_temp[4] = true; 
            //gameEnd.SetActive(true);
            mission1.color = Color.white;
            mission2.color = Color.white;
            //Fungus.Flowchart.BroadcastFungusMessage("isMove_true");
            Invoke("sceneChange", 2);
        }
    }

    void sceneChange()
    {
        SceneManager.LoadScene("main");
    }

    void failscene()
    {
        SceneManager.LoadScene("CodeEnding");
    }



}
