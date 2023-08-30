using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldController : MonoBehaviour
{
    static public bool info_ = false;
    public int number = 0;//mission1,2,3���� ��ȣ�� �ѱ�� ���� �ε��� ������ �ϴ� ��
    public Text txt; // inputfield�� text�κ� ������ ���� txt
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
                if (txt.text == "GR���������������Ѵ�" || txt.text =="GR�� �������� �����Ѵ�")
                {
                    //txt.text.Replace(str, "");

                    mission1.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";// ��ĭ���� ����� �Ϸ��� �ǵ��� text�� ��ĭ�� ����־����ϴ�. �̺κ��� �۵����� �ʴ� �� �����ϴ�.
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
                if (txt.text == "Ű�޶���ʴɷ��ڿ͵����ϵ��ϴ�" || txt.text =="Ű�޶�� �ʴɷ��ڿ� ������ ���ϴ�")
                {

                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//��ĭ���� ����� �Ϸ��� �ǵ��� text�� ��ĭ�� ����־����ϴ�. �̺κ��� �۵����� �ʴ� �� �����ϴ�.
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

                if (txt.text == "GR�ǹ濡��Ű�޶������̾�������ΰ��ִ�" || txt.text =="GR�� �濡�� Ű�޶� ����� �̾����� ��ΰ� �ִ�")
                {

                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//��ĭ���� ����� �Ϸ��� �ǵ��� text�� ��ĭ�� ����־����ϴ�. �̺κ��� �۵����� �ʴ� �� �����ϴ�.
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
