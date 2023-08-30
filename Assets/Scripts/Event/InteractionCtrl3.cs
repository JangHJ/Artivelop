using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCtrl3 : MonoBehaviour
{
   public Animator InteractionAnim;
  

    private void OnTriggerEnter2D(Collider2D coll)
    {
        InteractionAnim.SetBool("isEnter", true);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        InteractionAnim.SetBool("isEnter", false);
    }
}
