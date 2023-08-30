using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour
{
    public float volume;
    public int current;
    public int number;
    public int box;
    public GameObject noTitle;
    public GameObject Loadtab;
    public GameObject SettingTab;
    public GameObject background;

    //public static GameManager instance;

  /*  private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void NewStart()
    {
        SceneManager.LoadScene("main");
        DataManager.instance.DataClear();
        QuizController.current = 1;
        QuizController.number = 1;
        QuizController.box = 0;
        SetVolume.SliderValue = 0.5f;
        print(QuizController.current);
        print(QuizController.number);
        print(SetVolume.SliderValue);

        DataManager.instance.item_temp = new bool[26];
        DataManager.instance.game_temp = new bool[7];
        DataManager.instance.item_i_temp = new bool[24];
        DataManager.instance.box_temp = new bool[12];
        DataManager.instance.item_s_temp = new bool[12];
        DataManager.instance.item_i_temp[0] = true;
        DataManager.instance.item_s_temp[0] = true;
        DataManager.instance.item_temp[0] = true;

        DataManager.instance.DataClear();
        Fungus.Flowchart.BroadcastFungusMessage("reset_value");
    }

    public void LoadTab()
    {
        Loadtab.SetActive(true);
        background.SetActive(true);
        noTitle.SetActive(true);
    }

    public void Setting()
    {
        SettingTab.SetActive(true);
        background.SetActive(true);
        noTitle.SetActive(true);
    }
    public void ExitSetting()
    {
        SettingTab.SetActive(false);
        background.SetActive(false);
        noTitle.SetActive(false);
    }

    public void ExitTab()
    {
        Loadtab.SetActive(false);
        background.SetActive(false);
        noTitle.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Save1()
    {
        PlayerPrefs.SetFloat("Volume1", SetVolume.SliderValue);
        PlayerPrefs.SetInt("number1", QuizController.number);
        PlayerPrefs.SetInt("current1", QuizController.current);
        PlayerPrefs.SetInt("box1", QuizController.box);
    }
    public void Save2()
    {
        PlayerPrefs.SetFloat("Volume2", SetVolume.SliderValue);
        PlayerPrefs.SetInt("number2", QuizController.number);
        PlayerPrefs.SetInt("current2", QuizController.current);
        PlayerPrefs.SetInt("box2", QuizController.box);
    }
    public void Save3()
    {
        PlayerPrefs.SetFloat("Volume3", SetVolume.SliderValue);
        PlayerPrefs.SetInt("number3", QuizController.number);
        PlayerPrefs.SetInt("current3", QuizController.current);
        PlayerPrefs.SetInt("box3", QuizController.box);
    }

    public void Load1()
    {
        if (PlayerPrefs.HasKey("number1"))
        {
            SetVolume.SliderValue = PlayerPrefs.GetFloat("Volume1");
            QuizController.number = PlayerPrefs.GetInt("number1");
            QuizController.current = PlayerPrefs.GetInt("current1");
            QuizController.box = PlayerPrefs.GetInt("box1");
            print(QuizController.current);
            print(QuizController.number);
            print(SetVolume.SliderValue);

        }
    }
    public void Load2()
    {
        if (PlayerPrefs.HasKey("number2"))
        {
            SetVolume.SliderValue = PlayerPrefs.GetFloat("Volume2");
            QuizController.number = PlayerPrefs.GetInt("number2");
            QuizController.current = PlayerPrefs.GetInt("current2");
            QuizController.box = PlayerPrefs.GetInt("box2");
            print(QuizController.current);
            print(QuizController.number);
            print(SetVolume.SliderValue);

        }
    }
    public void Load3()
    {
        if (PlayerPrefs.HasKey("number3"))
        {
            SetVolume.SliderValue = PlayerPrefs.GetFloat("Volume3");
            QuizController.number = PlayerPrefs.GetInt("number3");
            QuizController.current = PlayerPrefs.GetInt("current3");
            QuizController.box = PlayerPrefs.GetInt("box3");
            print(QuizController.current);
            print(QuizController.number);
            print(SetVolume.SliderValue);

        }
    }
}
