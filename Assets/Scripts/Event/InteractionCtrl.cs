using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCtrl : MonoBehaviour
{
    Animator InteractionAnim;
    // Start is called before the first frame update
    void Start()
    {
        InteractionAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        InteractionAnim.SetBool("isEnter", true);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        InteractionAnim.SetBool("isEnter", false);
    }
}
