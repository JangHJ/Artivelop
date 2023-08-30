using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InputField : MonoBehaviour
{
    public int number = 0;//mission1,2,3���� ��ȣ�� �ѱ�� ���� �ε��� ������ �ϴ� ��
    public Text txt; // inputfield�� text�κ� ������ ���� txt
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
                if (txt.text == "GR���������������Ѵ�")
                {
                    //txt.text.Replace(str, "");
                   
                    mission1.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";// ��ĭ���� ����� �Ϸ��� �ǵ��� text�� ��ĭ�� ����־����ϴ�. �̺κ��� �۵����� �ʴ� �� �����ϴ�.
            } 
          
        }
        else if (number == 1)
        {
            mission2.color = Color.red;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                string str = txt.text;
                //txt.text.Replace(str, "");
                if (txt.text == "Ű�޶���ʴɷ��ڿ͵����ϵ��ϴ�") 
                {
                   
                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//��ĭ���� ����� �Ϸ��� �ǵ��� text�� ��ĭ�� ����־����ϴ�. �̺κ��� �۵����� �ʴ� �� �����ϴ�.
            }
           
        }
        else if (number == 2)
        {
            mission3.color = Color.red;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                string str = txt.text;
                //txt.text.Replace(str, "");

                if(txt.text =="GR�ǹ濡��Ű�޶������̾�������ΰ��ִ�")
                { 
                   
                    mission2.color = Color.black;
                    number++;
                }
                GetComponent<UnityEngine.UI.InputField>().text = "";//��ĭ���� ����� �Ϸ��� �ǵ��� text�� ��ĭ�� ����־����ϴ�. �̺κ��� �۵����� �ʴ� �� �����ϴ�.
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
