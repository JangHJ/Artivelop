using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameEndController : MonoBehaviour
{
    public Text success;
    public GameObject gameEnd;
    public GameObject turnoff;
    public Text State;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pieceController.number < 20)
        {
            success.text = "����� " + 0 + "%";
        }
        else if (pieceController.number < 40)
        {
            success.text = "����� " + 20 + "%";
        }
        else if (pieceController.number < 60)
        {
            success.text = "����� " + 40 + "%";

        }
        else if (pieceController.number < 80)
        {
            success.text = "����� " + 60 + "%";

        }
        else if (pieceController.number < 98)
        {
            success.text = "����� " + 80 + "%";

        }


        if (pieceController.number > 99)
        {
            success.text = "����� " + 100 + "%";
            State.text = "SUCCESS";
            turnoff.SetActive(false);
            gameEnd.SetActive(true);
            pieceController.number = 0;
            audioSource.Play();
            Invoke("scenechange", 2);
            DataManager.instance.game_temp[6] = true;
        }
    }
    void scenechange()
    {
        SceneManager.LoadScene("main");
    }
}
