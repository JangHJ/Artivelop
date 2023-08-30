using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Fungus;

public class PlayerData
{
    // 사용자 위치, 아이템, 데스카운트
    public Vector2 pos = new Vector2(-13, 20f);
    public string saveTime = "";
    public int goal = 0;
    public bool[] item = new bool[26]; //저장된 아이템 획득+확대 리스트
    public bool[] game = new bool[7]; //미니게임 성공여부 확인
    public bool[] box = new bool[12];//사만다 퀴즈 박스 저장
    public bool[] item_i = new bool[24];//인벤토리용 사라지지 않는 아이템
    public bool[] item_s = new bool[12];
    public bool SRCard_USE = false;
    public bool KeypadON1 = false;

    //획득 + 확대 리스트 item[]
    // 0 - 폴라 ID카드
    // 1 - 사만다 도넛
    // 2 - 3층 카드키
    // 3 - 폴라 일기장
    // 4 - 사만다 퀴즈
    // 5 - 벨라 일기장
    // 6 - 키메라 인식표
    // 7 - 영양제 보고서
    // 8 - 컴퓨터 화면 속 지시내용 //확대
    // 9 - 물
    // 10 - 락커룸 카드키
    // 11 - 연구실 카드키
    // 12 - 실험복
    // 13 - 초능력 지속 보고서
    // 14 - 검사체 물
    // 15 - 초능력 약물 검출 검사 결과지
    // 16 - 수석 연구원 선정 게시물  //확대
    // 17 - 직원 관리 리스트
    // 18 - 레지스탕스 사진
    // 19 - 3041년도 우수 연구원 사진
    // 20 - 붉은 스카프
    // 21 - 비밀의 방 카드키
    // 22 - GR 제약회사 보고서
    // 23 - 관리국 키메라 연구 보고서
    // 24 - 불에 탄 실험 승인서
    // 25 - 보안실 카드키 (추가 //인벤토리 아이템은 추가X

    //획득 리스트 item_i[]
    // 0 - 폴라 ID카드
    // 1 - 사만다 도넛
    // 2 - 3층 카드키
    // 3 - 폴라 일기장
    // 4 - 사만다 퀴즈
    // 5 - 벨라 일기장
    // 6 - 키메라 인식표
    // 7 - 영양제 보고서
    // 8 - 물
    // 9 - 락커룸 카드키
    // 10 - 연구실 카드키
    // 11 - 실험복
    // 12 - 초능력 지속 보고서
    // 13 - 검사체 물
    // 14 - 초능력 약물 검출 검사 결과지
    // 15 - 직원 관리 리스트
    // 16 - 레지스탕스 사진
    // 17 - 3041년도 우수 연구원 사진
    // 18 - 붉은 스카프
    // 19 - 비밀의 방 카드키
    // 20 - GR 제약회사 보고서
    // 21 - 관리국 키메라 연구 보고서
    // 22 - 불에 탄 실험 승인서
    // 23 - 보안실 카드키

    //사만다 리스트 item_s[]
    // 0 - 폴라 ID카드 0
    // 1 - 키메라 인식표 6
    // 2 - 영양제 보고서 7
    // 3 - 물 9
    // 4 - 락커룸 카드키 10
    // 5 - 초능력 지속 보고서 13
    // 6 - 초능력 약물 검출 검사 결과지 15
    // 7 - 직원 관리 리스트 17
    // 8 - 레지스탕스 사진 18
    // 9 - 3041년도 우수 연구원 사진 19
    // 10 - GR 제약회사 보고서 22
    // 11 - 관리국 키메라 연구 보고서 23 + 24
    
}

public class DataManager : MonoBehaviour
{
    // 싱글톤 설정
    public static DataManager instance;
    public Vector2 pos_temp = new Vector2(-13, 20f);
    public PlayerData nowPlayer = new PlayerData();
    
    public bool[] item_temp = new bool[26]; //아이템 임시저장
    public bool[] game_temp = new bool[7]; //미니게임 임시저장

    public bool[] box_temp = new bool[12];//사만다 퀴즈 박스 저장
    public bool[] item_i_temp = new bool[24]; //인벤토리 아이템 임시저장
    public bool[] item_s_temp = new bool[12];

    public string path;
    public int nowSlot;


    private void Awake()
    {

        path = Application.persistentDataPath + "/save";
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        DataManager.instance.item_temp = new bool[26];
        DataManager.instance.game_temp = new bool[7];
        DataManager.instance.item_i_temp = new bool[24];
        DataManager.instance.box_temp = new bool[12];
        DataManager.instance.item_s_temp = new bool[12];
        DataManager.instance.item_i_temp[0] = true;
        DataManager.instance.item_s_temp[0] = true;
        DataManager.instance.item_temp[0] = true;
        /*
        print(path);
        item_temp = nowPlayer.item;
        game_temp = nowPlayer.game;
        box_temp = nowPlayer.box;
        item_i_temp = nowPlayer.item_i;
        item_s_temp = nowPlayer.item_s;
        */
    }

    public void SaveData()
    {
        Fungus.Flowchart.BroadcastFungusMessage("SaveGame");
        string data = JsonUtility.ToJson(nowPlayer);
        //print(path);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }

}
