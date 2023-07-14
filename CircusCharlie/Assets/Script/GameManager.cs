using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance = null;

    //public static GameManager Instance{ get
    //    {
    //        return instance;
    //    }
    //}
    Player player;
    PlayerController playerController;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text bonusText;
    public GameObject stageUi;

    public AudioSource backgroundMusic;
    private float dieTimer = 0;
    private float dieRate = 3.5f;
    private int playerId = 0;

    private float stageTimer = 0f;
    private float stageRate = 5f;

    private float uiTimer = 0f;
    private float uiRate = 2f;
    public int score = 0;
    private int playerHpCount = 3;

    private float gameOverTimer = 0;
    private float gameOverRate = 5;
    private int playerMhp = 3;

    private bool loadScene = false;
    //private void Awake()
    //{
    //    if (instance)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }

    //    // instance를 유일 오브젝트로 만든다
    //    instance = this;

    //    // Scene 이동 시 삭제 되지 않도록 처리
    //    DontDestroyOnLoad(this.gameObject);

    //}

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        playerController = FindAnyObjectByType<PlayerController>();
        backgroundMusic = GetComponent<AudioSource>();
        if(playerController.isPlayerDie==false)
        {
        backgroundMusic.Play();

        }

    }
    // Update is called once per frame
    void Update()
    {
        playerMhp = PlayerInfo.playerHp;
        //if(SceneManager.GetActiveScene().name == ("Stage1")|| SceneManager.GetActiveScene().name == ("Stage2"))
        //{
        //if(playerController.isPlayerDie==true)
        //    {
        //    backgroundMusic.Stop();
        //}

        //}
        Debug.LogFormat("playerHp : {0}", playerMhp);

        if(SceneManager.GetActiveScene().name=="GameOver")
        {
            gameOverTimer += Time.deltaTime;
            if(gameOverTimer>=gameOverRate)
            {
                gameOverTimer = 0;
                PlayerInfo.playerHp = 3;
                PlayerInfo.score = 0;
                SceneManager.LoadScene("TitleScene");
            }

        }

        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Stage1Loading");
               
                
            }

        }

        if(SceneManager.GetActiveScene().name == "Stage1Loading")
        {
            uiTimer += Time.deltaTime;
            if(uiTimer>=uiRate)
            {
                uiTimer = 0f;
                SceneManager.LoadScene("Stage1");


            }
        }
        if (SceneManager.GetActiveScene().name == "Stage2Loading")
        {
            uiTimer += Time.deltaTime;
            if (uiTimer >= uiRate)
            {
                uiTimer = 0f;
                SceneManager.LoadScene("Stage2");


            }
        }


        if (SceneManager.GetActiveScene().name == ("Stage1"))
        {
            
            if (playerController.isPlayerDie == true)
            {
                dieTimer += Time.deltaTime;
                
            }
            if (dieTimer >= dieRate)
            {
                dieTimer = 0;
                if (playerMhp == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                SceneManager.LoadScene("Stage1Loading");

                }
                dieRate = 3.5f;
            }
            



            if (playerController.isGoal == true)
            {

                stageTimer += Time.deltaTime;

            }
            if (stageTimer >= stageRate)
            {
                stageTimer = 0;
               
               
                SceneManager.LoadScene("Stage2Loading");

                
            }
        }
        else if (SceneManager.GetActiveScene().name == ("Stage2"))
        {
            
           
            if (playerController.isPlayerDie == true)
            {
                dieTimer += Time.deltaTime;
               
            }
            if (dieTimer >= dieRate)
            {
                dieTimer = 0;
                if (playerMhp == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                SceneManager.LoadScene("Stage2Loading");

                }
                
            }
        }
        scoreText.text = string.Format("SCORE : {0}", PlayerInfo.score);
        float highScore = PlayerPrefs.GetFloat("HighScore");

        if (PlayerInfo.score > highScore)
        {
            highScore = PlayerInfo.score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        highscoreText.text = "HI :" + highScore;
    }//update()

   


}
