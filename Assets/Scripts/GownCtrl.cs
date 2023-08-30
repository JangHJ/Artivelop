using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GownCtrl : MonoBehaviour
{
    private Animator gownAnim;
    SpriteRenderer renderer_g;
    public GameObject player;
    public SpriteRenderer player_;

    // Start is called before the first frame update
    void Start()
    {
        gownAnim = gameObject.GetComponent<Animator>();
        renderer_g = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = GameObject.Find("Pola").gameObject.transform.position;
        Move();
    }
    void Move()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            
            gownAnim.SetBool("isWalking", true);
            renderer_g.flipX = true;
            if (renderer_g.sprite.name == "Pola_IDle1")
            {
                renderer_g.transform.position = new Vector3(0.025f, 0.139f, 0f) + playerPosition;
                Debug.Log("Gown1");
            }
            else if (renderer_g.sprite.name == "Gown1")
            {
                renderer_g.transform.position = new Vector3(-0.027f, 0.18f, 0f) + playerPosition;
                Debug.Log("Gown1");
            }
            else if (renderer_g.sprite.name == "Gown2")
            {
                renderer_g.transform.position = new Vector3(-0.07f, 0.244f, 0f) + playerPosition;
                Debug.Log("Gown2");
            }
            else if (renderer_g.sprite.name == "Gown3")
            {
                renderer_g.transform.position = new Vector3(0.103f, 0.178f, 0f) + playerPosition;
                Debug.Log("Gown3");
            }
            else if (renderer_g.sprite.name == "Gown4")
            {
                renderer_g.transform.position = new Vector3(-0.025f, 0.178f, 0f) + playerPosition;
            }
            else if (renderer_g.sprite.name == "Gown5")
            {
                renderer_g.transform.position = new Vector3(-0.076f, 0.223f, 0f) + playerPosition;
            }
            else if (renderer_g.sprite.name == "Gown6")
            {
                renderer_g.transform.position = new Vector3(0.096f, 0.178f, 0f) + playerPosition;
            }

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            gownAnim.SetBool("isWalking", true);
            renderer_g.flipX = false;
            if (renderer_g.sprite.name == "Pola_IDle1")
            {
                renderer_g.transform.position = new Vector3(-0.024f, 0.126f, 0f) + playerPosition;
                Debug.Log("Gown1");
            }
            else if (renderer_g.sprite.name=="Gown1")
            {
              renderer_g.transform.position = new Vector3(0.028f,0.18f,0f)+playerPosition;
                Debug.Log("Gown1");
             }
            else if (renderer_g.sprite.name == "Gown2")
            {
              renderer_g.transform.position = new Vector3(0.069f, 0.226f, 0f) + playerPosition;
                Debug.Log("Gown2");
            }
            else if (renderer_g.sprite.name == "Gown3")
            {
                renderer_g.transform.position = new Vector3(-0.104f, 0.18f, 0f) + playerPosition;
                Debug.Log("Gown3");
            }
            else if (renderer_g.sprite.name == "Gown4")
            {
                renderer_g.transform.position = new Vector3(0.01f, 0.173f, 0f) + playerPosition;
            }
            else if (renderer_g.sprite.name == "Gown5")
            {
                renderer_g.transform.position = new Vector3(0.077f, 0.195f, 0f) + playerPosition;
            }
            else if (renderer_g.sprite.name == "Gown6")
            {
                renderer_g.transform.position = new Vector3(-0.103f, 0.179f, 0f) + playerPosition;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            renderer_g.transform.position = new Vector3(-0.024f, 0.126f, 0f) + playerPosition;
            gownAnim.SetBool("isWalking", false);

            if (player.GetComponent<SpriteRenderer>().flipX == true)
            {
                renderer_g.flipX = false;
            }
            else
            {
                renderer_g.flipX = true;
            }
            
        }

        
       
    }

}
