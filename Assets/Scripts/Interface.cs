
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class Interface : MonoBehaviour
{
    public GameObject Streak;
    public static int PlayerHelth = 3;
    public int score;
    private Text _record;
    private Text _money;
    private Text _scoreNow;
    private Button resume;
    private bool _isFreeLife;
    private int _scoreRecord;
    public GameObject LoseTable;
    public Transform Player;
    public GameObject PresetTable;
    [SerializeField]
    private Text textAmountTarget = null;
    [SerializeField]
    private Text LvlNow = null;
    private GameObject LoseTableObject;
    public static int amountAdvertising = 1;
    string gameId = "3539559";
    bool testMode = false;
    public static bool isAlive;
    private static bool isWas = false;
    private PlayerWallet playerWallet;
    public static GameObject[] helth = new GameObject[3];
    private int i;
    [SerializeField]
    private int Lvl;
    public int SwipeAmount;
    public int AmountTarget;
    public newRecord _newRecord;
    public AudioSource Music;
    public static bool _isWasyRecord;
    public static bool _itWasWin;
    public GameObject WinTable;
    private bool _chanceDodge = false;

    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, testMode);
        }
        playerWallet = GameObject.Find("PlayerWallet").GetComponent<PlayerWallet>();
        helth[0] = GameObject.Find("Helth3");
        helth[1] = GameObject.Find("Helth2");
        helth[2] = GameObject.Find("Helth1");
        PlayerHelth = 3;

        if (PlayerPrefs.HasKey("ChanceDodge"))
        {
            _chanceDodge = true;
        }

        if (PlayerPrefs.HasKey("LVL"))
        {
            Lvl = PlayerPrefs.GetInt("LVL");
            AmountTarget = SetAmountTarget(Lvl);
        }
        else
        {
            Lvl = 1;
            AmountTarget = SetAmountTarget(Lvl);
        }
        LvlNow.text = "LVL" + Lvl.ToString();
        textAmountTarget.text = SwipeAmount.ToString() + "/" + AmountTarget.ToString();

        if (PlayerPrefs.HasKey("FreeLife"))
        {
            _isFreeLife = true;
        }     

    }

    private int SetAmountTarget(int lvl)
    {
        return lvl * 25;
    }

    public void StopAllBlots()
    {
        Blot[] blots = FindObjectsOfType<Blot>();


        foreach (Blot blot in blots)
        {
            blot.isStopMove = true;
        }
    }

    public void StartAllBlots()
    {
        Blot[] blots = FindObjectsOfType<Blot>();


        foreach (Blot blot in blots)
        {
            blot.isStopMove = false;
        }
    }

    public void StopAllPaper()
    {
        PaperMovesDown[] paperMove = FindObjectsOfType<PaperMovesDown>();


        foreach (PaperMovesDown paper in paperMove)
        {
            paper._isStopedGame = true;
        }
    }

    public void StartAllPaper()
    {
        PaperMovesDown[] paperMove = FindObjectsOfType<PaperMovesDown>();

        foreach (PaperMovesDown paper in paperMove)
        {
            paper._isStopedGame = false;
        }
    }

    private int Percents(int Number , int Amount)
    {
        return (Number / Amount) * 100; 
    }

    public void AddToSwipe() // добовляем коичество свайпов
    {
        SwipeAmount++;
        textAmountTarget.text = SwipeAmount.ToString() + "/" + AmountTarget.ToString();

        if (SwipeAmount > AmountTarget)
        {
            if (PlayerPrefs.HasKey("MoreScoreChance"))
            {
                if(Percents(UnityEngine.Random.Range(1,10),10) > 50)
                {
                    Lvl++;
                }
            }

            Lvl++;
            PlayerPrefs.SetInt("LVL" , Lvl);
            SwipeAmount = 0;
            StopAllBlots();
            StopAllPaper();
            Instantiate(WinTable, WinTable.transform.position, WinTable.transform.rotation); // создаю таблицу победы
            PlayerHelth = 3;
            AmountTarget = 0;
            PlayerPrefs.Save();

        }
    }

    public void SpawnCang() // спавн поздравлений
    { 
        var child = Instantiate(Streak, Player.position * new Vector2(100,100), Quaternion.identity);
        child.transform.SetParent(gameObject.transform, false);
    }

    public void HelthCheak() // проверяю хп
    {
        if (PlayerHelth == 3)
        {
            helth[0].SetActive(true);
            helth[1].SetActive(true);
            helth[2].SetActive(true);

        }
        else if (PlayerHelth == 2)
        {
            helth[0].SetActive(false);
            helth[1].SetActive(true);
            helth[2].SetActive(true);
        }
        else if (PlayerHelth == 1)
        {
            helth[0].SetActive(false);
            helth[1].SetActive(false);
            helth[2].SetActive(true);

        }
        else if (PlayerHelth <= 0)
        {

            if (_isFreeLife != true)
            {
                isWas = false;
                helth[2].SetActive(false);

                
                PlayerLose();
            }
            else
            {
                PlayerHelth = 3;
                helth[0].SetActive(true);
                helth[1].SetActive(true);
                helth[2].SetActive(true);
                _isFreeLife = false;
            }
        }
    }

    public void HelthMinus(bool isDegcrese) // отнимаю хп
    {
        if (isDegcrese)
        {
            if(_chanceDodge != true)
            {
                PlayerHelth--;
            }
            else
            {
                i = UnityEngine.Random.Range(1, 5);

                if(i < 3)
                {
                    PlayerHelth--;
                }
            }
        }
        else
        {
            PlayerHelth++;
        }

        HelthCheak();
    }




    public void ResumeGame()
    {
        PlayerHelth = 3;
        score = 0;
        ToiletPaperSpawner.paperSpeed = 5;
        Destroy(GameObject.Find("LoseTable(Clone)"));
        SceneManager.LoadScene("GameScence");

    }


    private void PlayerLose()
    {
        LoseTableObject = Instantiate(LoseTable, Vector3.zero, Quaternion.identity);
        PlayerController.isCanMove = false;
        StopAllBlots();
        StopAllPaper();
        Music.Stop();

        if (PlayerPrefs.HasKey("MoreScoreChance"))
        {
            if (Percents(UnityEngine.Random.Range(1, 10), 10) > 20)
            {
                Lvl--;
            }
        }
        else
        {
            Lvl--;
        }

        PlayerPrefs.SetInt("LVL", Lvl);

        if (amountAdvertising % 5 == 0)
        {
            Advertisement.Show();
        }

        PlayerPrefs.Save();

        if (LoseTableObject != null)
        {
            playerWallet.WalletAndRecord(1);

            resume = GameObject.Find("Rebut").GetComponent<Button>();
            resume.onClick.AddListener(ResumeGame);


            _record = GameObject.Find("Record").GetComponent<Text>();
            _record.text = Convert.ToString(_scoreRecord);

            _money = GameObject.Find("money").GetComponent<Text>();
            _money.text = Convert.ToString((score / 2) * 1);

            _scoreNow = GameObject.Find("scoreNow").GetComponent<Text>();
            _scoreNow.text = Convert.ToString(score);
            amountAdvertising++;
        }
    }

}
