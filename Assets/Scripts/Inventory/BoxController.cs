using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BoxController : MonoBehaviour
{
    public GameObject slotnumber;
    public GameObject colliderObject;
    public int itemNumber;
    public int boxNumber;
    public Flowchart fc_event;
    public Flowchart fc_chat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == colliderObject.name)
        {
            DataManager.instance.item_s_temp[itemNumber] = false;
            DataManager.instance.box_temp[boxNumber] = true;
            QuizController.box++;
            slotnumber.SetActive(false);
            colliderObject.SetActive(false);
            /*for(int i = 0; i < QuizController.box; i++)
            {
                DataManager.instance.box_temp[i] = false;
            }*/
            
            Debug.Log(QuizController.box - 1);
            
            if (QuizController.box - 1 == 0)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz1_check"); //Æú¶ó idÄ«µå ºóÄ­ Ã¤¿üÀ»¶§
            }

            else if (QuizController.box - 1 == 1)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz2_check1"); //Å°¸Þ¶óÀÎ½ÄÇ¥ ºóÄ­ Ã¤¿üÀ»¶§
            }

            else if (QuizController.box - 1 == 2)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz2_check2"); //¿µ¾çÁ¦º¸°í¼­ ºóÄ­ Ã¤¿üÀ»¶§
            }

            else if (QuizController.box - 1 == 3)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz3_check"); //¹° ºóÄ­ Ã¤¿üÀ»¶§
            }

            else if (QuizController.box - 1 == 4)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz4_check"); // ¶ôÄ¿·ë Ä«µåÅ° ºóÄ­ Ã¤¿üÀ» ¶§
            }

            else if (QuizController.box - 1 == 6)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz5_check"); // ÃÊ´É·Â ¾à¹° °ËÃâ °Ë»ç °á°úÁö ºóÄ­ Ã¤¿üÀ» ¶§
            }
            else if (QuizController.box - 1 == 7)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz6_check"); // ¿¬±¸¿ø °ü¸® ¸®½ºÆ® ºóÄ­ Ã¤¿üÀ» ¶§
            }

            else if (QuizController.box - 1 == 9)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz7_check"); // ·¹Áö½ºÅÁ½º »çÁø Ã¤¿üÀ» ¶§
            }
            else if (QuizController.box - 1 == 11)
            {
                Fungus.Flowchart.BroadcastFungusMessage("SamanthaQuiz8_check"); // °ü¸®±¹ Å°¸Þ¶ó º¸°í¼­ Ã¤¿üÀ» ¶§
            }
            /*
            else if (QuizController.box - 1 == 12)
            {
                if (fc_event.GetBooleanVariable("guard") == true)
                {
                    fc_chat.SetStringVariable("quarter1", "A");
                    Fungus.Flowchart.BroadcastFungusMessage("director_call");
                }
                else
                {
                    fc_chat.SetStringVariable("quarter1", "B");
                    Fungus.Flowchart.BroadcastFungusMessage("examine_village");

                }

            }*/
        }
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
}
