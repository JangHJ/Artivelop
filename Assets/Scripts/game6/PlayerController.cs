using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 defaultposition;
    int Speed;
    public Text coll;
    public Text success;
    public static int number = 0;
    public Text gameover;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    SpriteRenderer playerRenderer;
    float timer = 0f;
    float waitingtime = 0.5f;
    AudioSource audioSource;


   void Start()
    {

        playerRenderer = this.GetComponent<SpriteRenderer>();
        defaultposition = this.transform.position;
        Speed = 30;
        number = 0;
        audioSource = this.GetComponent<AudioSource>();
    }
    void white()
    {
        playerRenderer.color = Color.white;
    }
    void red() {
        playerRenderer.color = Color.red;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
        number++;
        Invoke("red", 0f);
        Invoke("white", 0.15f);
        Invoke("red", 0.3f);
        Invoke("white", 0.45f);
         coll.text="Hits : "+number;
        if (number == 1)
        {
            heart1.SetActive(false);
        }else if (number == 2)
        {
            heart2.SetActive(false);
        }
        if (number >= 3)
        {

            GameController.bulletMinigameFailed = true;

            heart3.SetActive(false);
            //coll.enabled = false;
            gameover.enabled = true;
            success.enabled = false;
            audioSource.Play();
            gameover.text = "FAILED";//½ÇÇè
            Invoke("scenechange", 3);
        }
        
    }

    void scenechange()
    {
        SceneManager.LoadScene("BulletDeadEnding");
    }
    
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        Vector3 PlayerPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(PlayerPosition.x, transform.position.y, transform.position.z);
        Debug.Log(Input.mousePosition);
    }    
         
    
    // Update is called once per frame
    void Update()
    {
       
        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 Position = transform.position;

        Position.x = (Position.x + Speed * horizontal * Time.deltaTime);
        Position.y = (Position.y + Speed * vertical * Time.deltaTime);

        transform.position = Position;
        */

        
    }
}
