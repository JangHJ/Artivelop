using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Fungus;

public class PlayerData
{
    // ����� ��ġ, ������, ����ī��Ʈ
    public Vector2 pos = new Vector2(-13, 20f);
    public string saveTime = "";
    public int goal = 0;
    public bool[] item = new bool[26]; //����� ������ ȹ��+Ȯ�� ����Ʈ
    public bool[] game = new bool[7]; //�̴ϰ��� �������� Ȯ��
    public bool[] box = new bool[12];//�縸�� ���� �ڽ� ����
    public bool[] item_i = new bool[24];//�κ��丮�� ������� �ʴ� ������
    public bool[] item_s = new bool[12];
    public bool SRCard_USE = false;
    public bool KeypadON1 = false;

    //ȹ�� + Ȯ�� ����Ʈ item[]
    // 0 - ���� IDī��
    // 1 - �縸�� ����
    // 2 - 3�� ī��Ű
    // 3 - ���� �ϱ���
    // 4 - �縸�� ����
    // 5 - ���� �ϱ���
    // 6 - Ű�޶� �ν�ǥ
    // 7 - ������ ����
    // 8 - ��ǻ�� ȭ�� �� ���ó��� //Ȯ��
    // 9 - ��
    // 10 - ��Ŀ�� ī��Ű
    // 11 - ������ ī��Ű
    // 12 - ���躹
    // 13 - �ʴɷ� ���� ����
    // 14 - �˻�ü ��
    // 15 - �ʴɷ� �๰ ���� �˻� �����
    // 16 - ���� ������ ���� �Խù�  //Ȯ��
    // 17 - ���� ���� ����Ʈ
    // 18 - ���������� ����
    // 19 - 3041�⵵ ��� ������ ����
    // 20 - ���� ��ī��
    // 21 - ����� �� ī��Ű
    // 22 - GR ����ȸ�� ����
    // 23 - ������ Ű�޶� ���� ����
    // 24 - �ҿ� ź ���� ���μ�
    // 25 - ���Ƚ� ī��Ű (�߰� //�κ��丮 �������� �߰�X

    //ȹ�� ����Ʈ item_i[]
    // 0 - ���� IDī��
    // 1 - �縸�� ����
    // 2 - 3�� ī��Ű
    // 3 - ���� �ϱ���
    // 4 - �縸�� ����
    // 5 - ���� �ϱ���
    // 6 - Ű�޶� �ν�ǥ
    // 7 - ������ ����
    // 8 - ��
    // 9 - ��Ŀ�� ī��Ű
    // 10 - ������ ī��Ű
    // 11 - ���躹
    // 12 - �ʴɷ� ���� ����
    // 13 - �˻�ü ��
    // 14 - �ʴɷ� �๰ ���� �˻� �����
    // 15 - ���� ���� ����Ʈ
    // 16 - ���������� ����
    // 17 - 3041�⵵ ��� ������ ����
    // 18 - ���� ��ī��
    // 19 - ����� �� ī��Ű
    // 20 - GR ����ȸ�� ����
    // 21 - ������ Ű�޶� ���� ����
    // 22 - �ҿ� ź ���� ���μ�
    // 23 - ���Ƚ� ī��Ű

    //�縸�� ����Ʈ item_s[]
    // 0 - ���� IDī�� 0
    // 1 - Ű�޶� �ν�ǥ 6
    // 2 - ������ ���� 7
    // 3 - �� 9
    // 4 - ��Ŀ�� ī��Ű 10
    // 5 - �ʴɷ� ���� ���� 13
    // 6 - �ʴɷ� �๰ ���� �˻� ����� 15
    // 7 - ���� ���� ����Ʈ 17
    // 8 - ���������� ���� 18
    // 9 - 3041�⵵ ��� ������ ���� 19
    // 10 - GR ����ȸ�� ���� 22
    // 11 - ������ Ű�޶� ���� ���� 23 + 24
    
}

public class DataManager : MonoBehaviour
{
    // �̱��� ����
    public static DataManager instance;
    public Vector2 pos_temp = new Vector2(-13, 20f);
    public PlayerData nowPlayer = new PlayerData();
    
    public bool[] item_temp = new bool[26]; //������ �ӽ�����
    public bool[] game_temp = new bool[7]; //�̴ϰ��� �ӽ�����

    public bool[] box_temp = new bool[12];//�縸�� ���� �ڽ� ����
    public bool[] item_i_temp = new bool[24]; //�κ��丮 ������ �ӽ�����
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
