using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GoalController : MonoBehaviour
{
    public Flowchart fc;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        fc = GameObject.Find("Flowchart_chat").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fc.GetIntegerVariable("goal") == 0)
        {
            text.text = "[관리국을 구경해보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 1)
        {
            text.text = "[2층 숙소에서 룸메이트를 만나보자.]";
        }
        else if(fc.GetIntegerVariable("goal") == 2)
        {
            text.text = "[보안실에서 사만다의 도넛을 찾아주자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 3)
        {
            text.text = "[숙소에서 사만다가 남긴 증거를 찾아보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 4)
        {
            text.text = "[일기장 내용을 따라 관리국을 조사해보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 5)
        {
            text.text = "[두비움 다이닝을 조사해보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 6)
        {
            text.text = "[연구원 가방을 뒤져보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 7)
        {
            text.text = "[락커룸에서 연구실 카드키를 얻자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 8)
        {
            text.text = "[연구실을 조사해서 아이템을 획득하자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 9)
        {
            text.text = "[마을 식수대에서 검사를 위한 물을 얻자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 10)
        {
            text.text = "[제 2연구실에서 검사를 진행해보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 11)
        {
            text.text = "[관리국을 조사해 사만다 퀴즈를 풀어보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 12)
        {
            text.text = "[자료보관실 비밀번호를 알아내자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 13)
        {
            text.text = "[자료보관실을 조사해 빈칸을 채워보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 14)
        {
            text.text = "[마을로 나가 레지스탕스에 대한 정보를 찾아보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 15)
        {
            text.text = "[주점에서 부대장을 만나보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 16)
        {
            text.text = "[자료보관실에 있는 비밀의 방을 조사해보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 17)
        {
            text.text = "[엘레베이터 비밀번호를 맞춰보자.]";
        }
        else if (fc.GetIntegerVariable("goal") == 18)
        {
            text.text = "[엘레베이터 비밀번호를 맞춰보자.2]";
        }
    }
}
