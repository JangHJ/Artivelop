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
            text.text = "[�������� �����غ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 1)
        {
            text.text = "[2�� ���ҿ��� �����Ʈ�� ��������.]";
        }
        else if(fc.GetIntegerVariable("goal") == 2)
        {
            text.text = "[���Ƚǿ��� �縸���� ������ ã������.]";
        }
        else if (fc.GetIntegerVariable("goal") == 3)
        {
            text.text = "[���ҿ��� �縸�ٰ� ���� ���Ÿ� ã�ƺ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 4)
        {
            text.text = "[�ϱ��� ������ ���� �������� �����غ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 5)
        {
            text.text = "[�κ�� ���̴��� �����غ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 6)
        {
            text.text = "[������ ������ ��������.]";
        }
        else if (fc.GetIntegerVariable("goal") == 7)
        {
            text.text = "[��Ŀ�뿡�� ������ ī��Ű�� ����.]";
        }
        else if (fc.GetIntegerVariable("goal") == 8)
        {
            text.text = "[�������� �����ؼ� �������� ȹ������.]";
        }
        else if (fc.GetIntegerVariable("goal") == 9)
        {
            text.text = "[���� �ļ��뿡�� �˻縦 ���� ���� ����.]";
        }
        else if (fc.GetIntegerVariable("goal") == 10)
        {
            text.text = "[�� 2�����ǿ��� �˻縦 �����غ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 11)
        {
            text.text = "[�������� ������ �縸�� ��� Ǯ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 12)
        {
            text.text = "[�ڷẸ���� ��й�ȣ�� �˾Ƴ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 13)
        {
            text.text = "[�ڷẸ������ ������ ��ĭ�� ä������.]";
        }
        else if (fc.GetIntegerVariable("goal") == 14)
        {
            text.text = "[������ ���� ������������ ���� ������ ã�ƺ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 15)
        {
            text.text = "[�������� �δ����� ��������.]";
        }
        else if (fc.GetIntegerVariable("goal") == 16)
        {
            text.text = "[�ڷẸ���ǿ� �ִ� ����� ���� �����غ���.]";
        }
        else if (fc.GetIntegerVariable("goal") == 17)
        {
            text.text = "[���������� ��й�ȣ�� ���纸��.]";
        }
        else if (fc.GetIntegerVariable("goal") == 18)
        {
            text.text = "[���������� ��й�ȣ�� ���纸��.2]";
        }
    }
}
