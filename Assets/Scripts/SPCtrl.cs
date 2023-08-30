using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPCtrl : MonoBehaviour
{
    SpriteRenderer renderer_;
    public GameObject Savetab;
    public GameObject panel_bg;
    Animator TelephoneAnim;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        renderer_ = gameObject.GetComponent<SpriteRenderer>();

        TelephoneAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isEnter = true;

      

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isEnter = false;
            panel_bg.SetActive(false);
            Savetab.SetActive(false);
            if (TelephoneAnim)
                TelephoneAnim.SetBool("isEnter", false);
        }
    }
    



    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (TelephoneAnim)
                TelephoneAnim.SetBool("isEnter", true);

            if (Input.GetKey(KeyCode.E))
            {
                panel_bg.SetActive(true);
                Savetab.SetActive(true);
            }
        }
    }
}
