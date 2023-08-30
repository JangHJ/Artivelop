using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InputField : MonoBehaviour
{
    public int number = 0;//mission1,2,3에서 번호를 넘기기 위한 인덱스 역할을 하는 수
    public Text txt; // inputfield의 text부분 접근을 위한 txt
    public Text mission1; 
    public Text mission2;
    public Text mission3;
    public GameObject gameEnd;
    public GameObject gameOver;
    public Text Time;
    int sec;

    // Start is called before the first frame update
    void Start()
    {
        sec = 60;
        InvokeRepeating("SetTime", 1f, 1f);

    }
    void SetTime()
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
            gameOver.SetActive(true);
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
                if (txt.text == "GR은가스등을좋아한다")
                {
                    //txt.text.Replace(str, "");
                   
                    mission1.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";// 빈칸으로 만들게 하려는 의도로 text에 빈칸을 집어넣었습니다. 이부분이 작동되지 않는 것 같습니다.
            } 
          
        }
        else if (number == 1)
        {
            mission2.color = Color.red;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                string str = txt.text;
                //txt.text.Replace(str, "");
                if (txt.text == "키메라는초능력자와동갑일듯하다") 
                {
                   
                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//빈칸으로 만들게 하려는 의도로 text에 빈칸을 집어넣었습니다. 이부분이 작동되지 않는 것 같습니다.
            }
           
        }
        else if (number == 2)
        {
            mission3.color = Color.red;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                string str = txt.text;
                //txt.text.Replace(str, "");

                if(txt.text =="GR의방에는키메라고향과이어지는통로가있다")
                { 
                   
                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//빈칸으로 만들게 하려는 의도로 text에 빈칸을 집어넣었습니다. 이부분이 작동되지 않는 것 같습니다.
            }
           
        }
        else
        {
            gameEnd.SetActive(true);
            mission1.color = Color.white;
            mission2.color = Color.white;

        }
    }

    
}
