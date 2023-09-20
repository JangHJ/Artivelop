# Artivelop 아티벨롭

```
💡 가스라이팅에 대해 간접적으로 경험해볼 수 있는 2D 사이드뷰형 어드벤처 추리 게임
```

- **개발 기간** : 2021.08 ~ 2022.08
- **개발 인원** : 4명
    - 기획자 및 스토리담당 1명(팀장)
    - GUI 디자이너 1명
    - 프로그래머 2명
- **IDE/Language** : Unity - C#
- **게임 실행파일** 
    [Artivelop_실행폴더 - Google Drive](https://drive.google.com/drive/folders/1TIwxaLJvWlj7ru5-PTSukh-vXwm1i4IK)

<br>

### 🖥️ 구현한 기능 및 코드 설명

```
❓ 구현한 기능의 자세한 코드 내용과 그에 대한 설명이 첨부되어 있습니다
```

<br>

- **캐릭터/카메라 이동**

[https://github.com/JangHJ/Artivelop/blob/main/Assets/Scripts/CameraManager.cs]
```C#
//카메라 이동 (플레이어 따라가게 구현)
public class CameraManager : MonoBehaviour
{
    static public CameraManager instance; // instance의 값을 공유

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치

    // 박스 컬라이더 영역의 최소 최대값
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    // 카메라의 반넓이와 반높이의 값 변수
    private float halfWidth;
    private float halfHeight;

    // 반 높이를 구하기 위해 필요한 카메라 변수
    private Camera theCamera;
   
    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        target = GameObject.Find("Pola");
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Pola");
        // 대상이 있는지 체크
        if (target.gameObject && target.gameObject.transform.position.y > -50f)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 5.4f;
            // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, -3);

            // vectorA -> B까지 T의 속도로 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }
        else if(target.gameObject && target.gameObject.transform.position.y < -60f)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 9.5f;
            // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
            targetPosition.Set(target.transform.position.x, target.transform.position.y + 5, -3);

            // vectorA -> B까지 T의 속도로 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }

    }

    public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }
}
```
[https://github.com/JangHJ/Artivelop/blob/main/Assets/Scripts/PlayerCtrl.cs]
```C#
//플레이어 이동
void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            moveVelocity = Vector3.left;
            polaAnim.SetBool("isWalking", true);
            renderer_.flipX = false;
            idle_bool = false;

            if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
            {
                Linda.GetComponent<Animator>().SetBool("isWalking", true);
                Linda.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            moveVelocity = Vector3.right;
            polaAnim.SetBool("isWalking", true);
            renderer_.flipX = true;
            idle_bool = true;

            if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
            {
                Linda.GetComponent<Animator>().SetBool("isWalking", true);
                Linda.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            if (Linda.activeSelf == true)
            {
                Linda.GetComponent<Animator>().SetBool("isWalking", false);
                Linda.GetComponent<SpriteRenderer>().flipX = false;
            }

            polaAnim.SetBool("isWalking", false);
            
            if (idle_bool == true)
            {
                renderer_.flipX = true;
                Linda.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                renderer_.flipX = false;
                Linda.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        transform.position += moveVelocity * moveForce * Time.deltaTime;
    }
```

<br>

- **Fungus Asset 사용**
- 
[https://github.com/snozbot/fungus/wiki]


  <br>
  
- **게임 내 이벤트 발생**
```Trigger 충돌체크로 아이템과 상호작용```

[https://github.com/JangHJ/Artivelop/blob/main/Assets/Scripts/SPCtrl.cs]
```C#
//이벤트 발생 예시 : 세이브포인트 스크립트
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
```

  <br>
  
- **세이브/로드 기능**

[https://github.com/JangHJ/Artivelop/blob/main/Assets/Scripts/SlotManager2.cs]

```C#
//세이브 기능
public class SlotManager2 : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    public Text[] timeText;
    public Flowchart fc;

    public GameObject Player;
    public GameObject Camera;
    public GameObject Savetab;
    public GameObject Panel_bg;
    bool[] savefile = new bool[3];

    public void Rewrite()
    {
        // 슬롯별로 저장된 데이터가 있는지 판단
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = "저장 파일" + $"{i + 1}";
                timeText[i].text = DataManager.instance.nowPlayer.saveTime;
            }
            else
            {
                slotText[i].text = "";
                timeText[i].text = "";
            }
        }
        DataManager.instance.DataClear();
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pola");
        Camera = GameObject.Find("Main Camera");
        Rewrite();
    }

    public void Slot(int number)
    {
        fc.SetIntegerVariable("slot", number+1);
        DataManager.instance.nowSlot = number;
        DataManager.instance.nowPlayer.pos = Player.transform.position;
        DataManager.instance.nowPlayer.saveTime = DateTime.Now.ToString("yyyy-MM-dd \n hh : mm");

        for (int i = 0; i < 7; i++)
        {
            if (DataManager.instance.game_temp[i] == true)
            {
                DataManager.instance.nowPlayer.game[i] = DataManager.instance.game_temp[i];
            }
        }

        for (int i = 0; i < 26; i++)
        {
            if (DataManager.instance.item_temp[i] == true)
            {
                DataManager.instance.nowPlayer.item[i] = DataManager.instance.item_temp[i];
            }
        }

        for (int i = 0; i < 12; i++)
        {
            if (DataManager.instance.box_temp[i] == true)
            {
                DataManager.instance.nowPlayer.box[i] = DataManager.instance.box_temp[i];
            }
        }

        for (int i = 0; i < 24; i++)
        {
            if (DataManager.instance.item_i_temp[i] == true)
            {
                DataManager.instance.nowPlayer.item_i[i] = DataManager.instance.item_i_temp[i];
            }
        }
        for (int i = 0; i < 12; i++)
        {
            if (DataManager.instance.item_s_temp[i] == true)
            {
                DataManager.instance.nowPlayer.item_s[i] = DataManager.instance.item_s_temp[i];
            }
        }

        DataManager.instance.nowPlayer.goal = fc.GetIntegerVariable("goal");
        DataManager.instance.pos_temp = new Vector2(0, -1.5f);
        Fungus.Flowchart.BroadcastFungusMessage("SaveGame");
        DataManager.instance.SaveData();
        Panel_bg.SetActive(false);
        Savetab.SetActive(false);
        print("저장되었습니다.");

        Rewrite();
    }

    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
}
```

[https://github.com/JangHJ/Artivelop/blob/main/Assets/Scripts/SlotManager.cs]

```C#
//로드 기능
public class SlotManager : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    public Text[] timeText;

    bool[] savefile = new bool[3];


    // Start is called before the first frame update
    void Start()
    {
        // 슬롯별로 저장된 데이터가 있는지 판단
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = "저장 파일" + $"{i + 1}";
                timeText[i].text = DataManager.instance.nowPlayer.saveTime;
            }
            else
            {
                slotText[i].text = "";
                timeText[i].text = "";
            }
        }
        DataManager.instance.DataClear();
    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        //저장된 데이터가 있을 때
        if (savefile[number])
        {
            DataManager.instance.LoadData();
            GoGame();
        }
        else
            print("저장된 데이터가 없습니다.");
    }

    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
}
```

<br>

### 🖥️ 회고

```
😣 추가되면 좋을 것 같은 기능 + 아쉬운 점
```

- 멀티 엔딩 게임이기 때문에 이미 본 장면은 빠르게 스킵할 수 있는 기능을 넣으면 더 좋았을 것 같다.
- 컷씬 연출이 들어갔다면 좀 더 게임 몰입도를 높일 수 있었을 것 같다.
- PC 기반 게임이기 때문에 가능하다면 모바일 환경에서도 이용 가능하도록 개선해봐도 좋을 것 같다. 

<br><br>
