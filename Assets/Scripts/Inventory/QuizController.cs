using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class QuizController : MonoBehaviour
{
    public static int box = 0;
    public static int number = 1;
    public static int current = 1;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject[] Quiz = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(number);
        Debug.Log(current);
        if (current == number)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }

        if (current == 1)
        {
            leftArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(true);
        }

        if (current == 1)
        {
            for(int i = 0; i < 10; i++)
            {
                if (i != 0)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 1)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 3)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 2)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 4)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 3)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 5)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 4)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 6)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 5)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 7)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 6)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 8)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 7)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 9)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 8)
                {
                    Quiz[i].SetActive(false);
                }
            }
        }
        else if (current == 10)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i != 9)
                {
                    Quiz[i].SetActive(false);
                }
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (box == 1)//Quiz1
        {
            //DataManager.instance.box_temp[0] = false;
            number = 2;
        }else if(box == 2)
        {
            //DataManager.instance.box_temp[1]=false;
        }
        else if (box == 3)//Quiz2
        {
            //DataManager.instance.box_temp[2] = false;
            number = 3;
        }else if (box == 4)//Quiz3
        {
            //DataManager.instance.box_temp[3] = false;
            number = 4;
        }else if(box == 5)//Quiz4
        {
            //DataManager.instance.box_temp[4] = false;
            number = 5;
        }else if (box == 6)
        {
            //DataManager.instance.box_temp[5] = false;
        }
        else if(box == 7)//Quiz5-1,5-2
        {
            //DataManager.instance.box_temp[6] = false;
            number = 7;
        }else if(box == 8)//Quiz 6
        {
            //DataManager.instance.box_temp[7] = false;
            number = 8;
        }else if (box == 9)//Quiz 7
        {
           // DataManager.instance.box_temp[8] = false;
           
        }else if (box == 10)
        {
            //DataManager.instance.box_temp[9] = false;
            number = 9;
        }
        else if (box == 11)//Quiz 8
        {
            //DataManager.instance.box_temp[10] = false;
            
        }
        else if(box==12)
        {
            //DataManager.instance.box_temp[11] = false;
            number = 10;
        }


        if (current == number)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }

        if (current == 1)
        {
            leftArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(true);
        }

        if (current == 1)
        {
            Quiz[0].SetActive(true);
            Quiz[1].SetActive(false);

            //Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz1_check");
        }
        else if (current == 2)
        {
            Quiz[1].SetActive(true);
            Quiz[0].SetActive(false);
            Quiz[2].SetActive(false);

            /*
            if (DataManager.instance.item_temp[6] == false)
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz2_check1");
            else if (DataManager.instance.item_temp[7] == false)
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz2_check2");
                */
        }
        else if (current == 3)
        {
            Quiz[2].SetActive(true);
            Quiz[1].SetActive(false);
            Quiz[3].SetActive(false);


            //if (DataManager.instance.item_temp[14] == false)
            //    Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz3_check");
        }
        else if (current == 4)
        {
            Quiz[3].SetActive(true);
            Quiz[2].SetActive(false);
            Quiz[4].SetActive(false);

            //if (DataManager.instance.item_temp[10] == false)
             //   Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz4_check");
        }
        else if (current == 5)
        {
            Quiz[4].SetActive(true);
            Quiz[3].SetActive(false);
            Quiz[5].SetActive(false);


            //if (DataManager.instance.item_temp[13] == false || DataManager.instance.item_temp[15] == false)
            //    Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz5_check");
        }
        else if (current == 6)
        {
            Quiz[5].SetActive(true);
            Quiz[4].SetActive(false);
            Quiz[6].SetActive(false);
        }
        else if (current == 7)
        {
            Quiz[6].SetActive(true);
            Quiz[5].SetActive(false);
            Quiz[7].SetActive(false);
        }
        else if (current == 8)
        {
            Quiz[7].SetActive(true);
            Quiz[6].SetActive(false);
            Quiz[8].SetActive(false);
        }
        else if (current == 9)
        {
            Quiz[8].SetActive(true);
            Quiz[7].SetActive(false);
            Quiz[9].SetActive(false);
        }
        else if (current == 10)
        {
            Quiz[9].SetActive(true);
            Quiz[8].SetActive(false);
            
        }
    }
}
